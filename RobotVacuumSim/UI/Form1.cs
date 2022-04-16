using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using VacuumSim.Sim;
using VacuumSim.UI.FloorplanGraphics;
using VacuumSim.Components;
using System.Diagnostics;
using VacuumSim.UI.Floorplan;
using System.IO;
using System.Text.Json;

namespace VacuumSim
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Describes the different pathing algorithm types the robot can use.
        /// </summary>
        /// Not certain an enum is right for this task, but I think it could work.
        private enum PathAlgorithm
        {
            Random,
            Spiral,
            Snaking,
            WallFollow
        }

        private List<string> SimulationSpeeds = new List<string> { "1x", "5x", "50x" };
        private FloorplanLayout HouseLayout;
        private VacuumDisplay VacDisplay;
        private VacuumController vc;
        private Vacuum ActualVacuumData = new Vacuum();
        private FloorCleaner floorCleaner = new FloorCleaner();
        private CollisionHandler collisionHandler = new CollisionHandler();

        /// <summary>
        /// Initializes the algorithm selector to allow for choosing an algorithm type as specified by the PathAlgorithm enum.
        /// </summary>
        private void InitAlgorithmSelector()
        {
            // Set the data source of the dropdown box to be the values of our PathAlgorithm enum.
            RobotPathAlgorithmSelector.DataSource = Enum.GetValues(typeof(PathAlgorithm));
            // Set the default value to the PathAlgorithm.Random value.
            RobotPathAlgorithmSelector.SelectedItem = PathAlgorithm.Random;
        }

        private void RobotPathAlgorithmSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vacuum.VacuumAlgorithm.Clear();
        }

        private void InitFloorTileSelector()
        {
            // Set the data source of the dropdown box to be the values of our ObstacleType enum
            //ObstacleSelector.DataSource = Enum.GetValues(typeof(ObstacleType));
            // Set the default value to the ObstacleType.WALL;
            ObstacleSelector.SelectedIndex = 0;
            Vacuum.VacuumAlgorithm.Clear();
        }

        private void InitSimulationSpeedSelector()
        {
            SimulationSpeedSelector.DataSource = SimulationSpeeds;
            ActualVacuumData.VacuumSpeed = (int)RobotSpeedSelector.Value;
        }

        public Form1()
        {
            InitializeComponent();
            InitAlgorithmSelector();
            InitSimulationSpeedSelector();
            InitFloorTileSelector();

            // Create objects needed for drawing to FloorCanvas
            HouseLayout = new FloorplanLayout();
            FloorCanvasDesigner.FloorplanHouseDesigner = new FloorplanLayout();
            VacDisplay = new VacuumDisplay();
            ActualVacuumData = new Vacuum();

            // Enable double buffering for FloorCanvas
            this.DoubleBuffered = true;
            FloorCanvas.EnableDoubleBuffering();
        }

        /// <summary>
        /// Callback for clicking the 'Run All Algorithms' checkbox
        /// TODO: Currently just disables the algorithm selector, should tell the robot to run each algorithm.
        /// </summary>
        ///
        private void RunAllAlgorithmsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (RunAllAlgorithmsCheckbox.Checked)
            {
                RobotPathAlgorithmSelector.Enabled = false;
            }
            else
            {
                RobotPathAlgorithmSelector.Enabled = true;
            }
        }

        private void ObstacleSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            FloorCanvasDesigner.eraserModeOn = false;
            EraserModeButton.Text = FloorCanvasDesigner.eraserModeOn ? "Eraser Mode: ON" : "Eraser Mode: OFF";

            if (ObstacleSelector.SelectedItem.ToString() == "Room")
            {
                RoomDimensionsGroupBox.Enabled = true;
                ChairTableDimensionsGroupBox.Enabled = false;
            }
            else if (ObstacleSelector.SelectedItem.ToString() == "Chair" || ObstacleSelector.SelectedItem.ToString() == "Table")
            {
                ChairTableDimensionsGroupBox.Enabled = true;
                RoomDimensionsGroupBox.Enabled = false;
                FloorCanvasDesigner.chairTableDrawingModeOn = true;
            }
            else // Chest is selected
            {
                ChairTableDimensionsGroupBox.Enabled = false;
                RoomDimensionsGroupBox.Enabled = false;
                FloorCanvasDesigner.chairTableDrawingModeOn = false;
            }
        }

        private void HouseWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)HouseWidthSelector.Value % 2 == 1) // Prevent non-even entries
                HouseWidthSelector.Value += 1; // Round up

            int prevNumTilesPerRow = HouseLayout.numTilesPerRow; // Number of tiles in a row before the width was changed
            HouseLayout.numTilesPerRow = ((int)HouseWidthSelector.Value + 4) / 2; // Get number of tiles per row based on house width chosen by user
            FloorCanvasDesigner.UpdateFloorplanAfterHouseWidthChanged(HouseLayout, prevNumTilesPerRow);

            // Update selected obstacle widths if necessary
            RoomWidthSelector.Value = Math.Min(RoomWidthSelector.Value, HouseWidthSelector.Value);
            ChairTableWidthSelector.Value = Math.Min(ChairTableWidthSelector.Value, HouseWidthSelector.Value);

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house width
        }

        private void HouseHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)HouseHeightSelector.Value % 2 == 1) // Prevent non-even entries
                HouseHeightSelector.Value += 1;

            int prevNumTilesPerCol = HouseLayout.numTilesPerCol; // Number of tiles in a column before the height was changed
            HouseLayout.numTilesPerCol = ((int)HouseHeightSelector.Value + 4) / 2; // Get number of tiles per column based on house height chosen by user
            FloorCanvasDesigner.UpdateFloorplanAfterHouseHeightChanged(HouseLayout, prevNumTilesPerCol);

            // Update selected obstacle heights if necessary
            RoomHeightSelector.Value = Math.Min(RoomHeightSelector.Value, HouseHeightSelector.Value);
            ChairTableHeightSelector.Value = Math.Min(ChairTableHeightSelector.Value, HouseHeightSelector.Value);

            FloorCanvas.Invalidate(); // Re-draw canvas to reflect change in house height
        }

        private void RoomWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)RoomWidthSelector.Value % 2 == 1) // Prevent non-even entries
                RoomWidthSelector.Value += 1;

            RoomWidthSelector.Value = Math.Min(RoomWidthSelector.Value, HouseWidthSelector.Value);
        }

        private void RoomHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)RoomHeightSelector.Value % 2 == 1) // Prevent non-even entries
                RoomHeightSelector.Value += 1;

            RoomHeightSelector.Value = Math.Min(RoomHeightSelector.Value, HouseHeightSelector.Value);
        }

        private void ChairTableWidthSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)ChairTableWidthSelector.Value % 2 == 1) // Prevent non-even entries
                ChairTableWidthSelector.Value += 1;

            ChairTableWidthSelector.Value = Math.Min(ChairTableWidthSelector.Value, HouseWidthSelector.Value);
        }

        private void ChairTableHeightSelector_ValueChanged(object sender, EventArgs e)
        {
            if ((int)ChairTableHeightSelector.Value % 2 == 1) // Prevent non-even entries
                ChairTableHeightSelector.Value += 1;

            ChairTableHeightSelector.Value = Math.Min(ChairTableHeightSelector.Value, HouseHeightSelector.Value);
        }

        private void SimulationSpeedSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation.simSpeed = Int32.Parse(SimulationSpeedSelector.SelectedItem.ToString().TrimEnd('x'));

            // Set the vacuum timer to update every 1000 / (simulation speed) / (frames per simulation second)
            VacAlgorithmTimer.Interval = 1000 / Simulation.simSpeed / FloorCanvasCalculator.framesPerSimSecond;
        }

        private void RobotSpeedSelector_ValueChanged(object sender, EventArgs e)
        {
            VacDisplay.vacuumSpeed = (int)RobotSpeedSelector.Value;
            ActualVacuumData.VacuumSpeed = (int)RobotSpeedSelector.Value;
        }

        private void RobotBatteryLifeSelector_ValueChanged(object sender, EventArgs e)
        {
            BatteryLeftLabel.Text = "" + RobotBatteryLifeSelector.Value + " minutes";
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
            ActualVacuumData.VacuumBattery = (int)RobotBatteryLifeSelector.Value;
        }

        private void InitialVacuumHeadingSelector_ValueChanged(object sender, EventArgs e)
        {
            VacDisplay.vacuumHeading = (int)InitialVacuumHeadingSelector.Value;
            ActualVacuumData.heading = (int)InitialVacuumHeadingSelector.Value;

            FloorCanvas.Invalidate(); // Re-draw canvas to show new whiskers display
        }

        private void FloorTypeControlChanged(object sender, EventArgs e)
        {
            // Update the default vacuum efficiency based on the selected floor covering
            if (HardWoodRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 90;
                ActualVacuumData.VacuumEfficiency = 90.0f / 100.0f;
            }
            else if (LoopPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 75;
                ActualVacuumData.VacuumEfficiency = 75.0f / 100.0f;
            }
            else if (CutPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 70;
                ActualVacuumData.VacuumEfficiency = 70.0f / 100.0f;
            }
            else if (FriezeCutPileRadioButton.Checked)
            {
                VacuumEfficiencySlider.Value = 65;
                ActualVacuumData.VacuumEfficiency = 65.0f / 100.0f;
            }

            VacuumEfficiencyValueLabel.Text = VacuumEfficiencySlider.Value + "%";

            FloorCanvas.Invalidate();
        }

        private void VacuumEfficiencySlider_Scroll(object sender, EventArgs e)
        {
            VacuumEfficiencyValueLabel.Text = VacuumEfficiencySlider.Value + "%";
            ActualVacuumData.VacuumEfficiency = VacuumEfficiencySlider.Value / 100.0f;
        }

        private void WhiskerEfficiencySlider_Scroll(object sender, EventArgs e)
        {
            WhiskersEfficiencyValueLabel.Text = WhiskersEfficiencySlider.Value + "%";
            ActualVacuumData.WhiskerEfficiency = WhiskersEfficiencySlider.Value / 100.0f;
        }

        private void ShowInstructionsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Robot Vacuum Simulator. Below is a short guide on how to use this software:\n\n" +
                "The first step is to create a floor plan. You can either start from scratch or start from a pre-loaded floor plan.\n" +
                "There are two types of pre-loaded floor plans. A floor plan that you have created and saved, and a default floor plan\n" +
                "created by us, the developers. You can then add/remove obstacles onto the floor plan. This can be achieved by selecting\n" +
                "an obstacle (i.e. room, chair, table, chest) and then clicking-and-dragging the obstacle onto the floor plan. To remove obstacles,\n" +
                "click on the \"Eraser Mode\" button to turn on eraser mode. Then, you can click on obstacles on the floor plan to remove them.\n" +
                "Once you are satisfied with your floor plan, press \"Finish Floor Plan\". You can always go back to editing the floor plan by\n" +
                "pressing \"Edit Floor Plan\". Pressing \"Finish Floor Plan\" will allow you to start setting the vacuum's attributes.\n\n" +
                "Customize the vacuum's attributes by utilizing the different options in the \"Vacuum Attributes\" section. Place the vacuum\n" +
                "onto the floor plan by clicking-and-dragging the vacuum onto a valid position. Once the vacuum is placed, you can set the simulation\n" +
                "speed and start the simulation. Note that if you choose to run all algorithms, four full simulations will run for each algorithm.\n\n" +
                "Stop the simulation at any time by pressing \"Stop Simulation\". The simulation will automatically stop when the vacuum's battery runs out.\n" +
                "As the simulation is running, a trail will be shown behind the vacuum showing what areas of the house have been cleaned so far by the vacuum.\n\n" +
                "Once the simulation has ended, the results will get saved and can be reviewed at any time. Also, after the simulation has ended, a heat map will get displayed\n" +
                "showing how well each area of the house was cleaned by the vacuum. The more red a spot is, the better the vacuum cleaned it. The more blue\n" +
                "a spot is, the worse the vacuum cleaned it.\n\n" +
                "You can then proceed to run another simulation by pressing \"Yes\" when prompted.\n");
        }

        private void FinishOrEditFloorplanButton_Click(object sender, EventArgs e)
        {
            FloorCanvasDesigner.editingFloorplan = !FloorCanvasDesigner.editingFloorplan;

            if (!FloorCanvasDesigner.editingFloorplan) // User just finished editing the floorplan
            {
                // Move to vacuum attribute setting stage
                FloorCanvasDesigner.settingVacuumAttributes = true;
                FloorCanvasDesigner.editingFloorplan = false;

                // Floorplan widget attributes
                FloorplanDesignLabel.Enabled = false;
                FloorTypeGroupBox.Enabled = false;
                HouseDimensionsGroupBox.Enabled = false;
                RoomDimensionsGroupBox.Enabled = false;
                ChairTableDimensionsGroupBox.Enabled = false;
                ObstaclesGroupBox.Enabled = false;
                FloorCanvasDesigner.eraserModeOn = false;
                EraserModeButton.Text = "Eraser Mode: OFF";
                FinishOrEditFloorplanButton.Text = "Edit Floor Plan";
                LoadSaveFloorplanGroupBox.Enabled = false;

                // Vacuum widget attributes
                VacuumAttributesLabel.Enabled = true;
                VacuumEfficiencyTitleLabel.Enabled = true;
                VacuumEfficiencyValueLabel.Enabled = true;
                VacuumEfficiencySlider.Enabled = true;
                WhiskersEfficiencyTitleLabel.Enabled = true;
                WhiskersEfficiencyValueLabel.Enabled = true;
                WhiskersEfficiencySlider.Enabled = true;
                RobotBatteryLifeLabel.Enabled = true;
                RobotBatteryLifeSelector.Enabled = true;
                RobotSpeedLabel.Enabled = true;
                RobotSpeedSelector.Enabled = true;
                RobotPathAlgorithmLabel.Enabled = true;
                RobotPathAlgorithmSelector.Enabled = true;
                RunAllAlgorithmsCheckbox.Enabled = true;
                InitialVacuumHeadingLabel.Enabled = true;
                InitialVacuumHeadingSelector.Enabled = true;
                PlaceVacuumInstructionsLabel.Visible = true;
            }
            else // User just returned to editing the floorplan
            {
                // Move back to floorplan editing stage
                FloorCanvasDesigner.settingVacuumAttributes = false;
                FloorCanvasDesigner.editingFloorplan = true;
                FloorCanvasDesigner.successPlacingVacuum = false;
                FloorCanvasDesigner.currentlyPlacingVacuum = false;

                // Floorplan widget attributes
                FloorplanDesignLabel.Enabled = true;
                FloorTypeGroupBox.Enabled = true;
                HouseDimensionsGroupBox.Enabled = true;
                ObstaclesGroupBox.Enabled = true;
                RoomDimensionsGroupBox.Enabled = ObstacleSelector.SelectedIndex == 0;
                ChairTableDimensionsGroupBox.Enabled = ObstacleSelector.SelectedIndex == 1 || ObstacleSelector.SelectedIndex == 2;
                LoadSaveFloorplanGroupBox.Enabled = true;
                FinishOrEditFloorplanButton.Text = "Finish Floor Plan";

                // Vacuum widget attributes
                VacuumAttributesLabel.Enabled = false;
                VacuumEfficiencyTitleLabel.Enabled = false;
                VacuumEfficiencyValueLabel.Enabled = false;
                VacuumEfficiencySlider.Enabled = false;
                WhiskersEfficiencyTitleLabel.Enabled = false;
                WhiskersEfficiencyValueLabel.Enabled = false;
                WhiskersEfficiencySlider.Enabled = false;
                RobotBatteryLifeLabel.Enabled = false;
                RobotBatteryLifeSelector.Enabled = false;
                RobotSpeedLabel.Enabled = false;
                RobotSpeedSelector.Enabled = false;
                RobotPathAlgorithmLabel.Enabled = false;
                RobotPathAlgorithmSelector.Enabled = false;
                RunAllAlgorithmsCheckbox.Enabled = false;
                InitialVacuumHeadingLabel.Enabled = false;
                InitialVacuumHeadingSelector.Enabled = false;
                PlaceVacuumInstructionsLabel.Visible = false;

                // Simulation widget attributes
                SimulationControlLabel.Enabled = false;
                SimulationSpeedLabel.Enabled = false;
                SimulationSpeedSelector.Enabled = false;
                StartSimulationButton.Enabled = false;
                StopSimulationButton.Enabled = false;
            }

            FloorCanvas.Invalidate();
        }

        private void SaveFloorplanButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFloorplanDialog = new SaveFileDialog();
            saveFloorplanDialog.Filter = "Text files (*.txt)|*.txt";
            saveFloorplanDialog.Title = "Save Floorplan";
            saveFloorplanDialog.ShowDialog();

            string outFilePath;

            if (saveFloorplanDialog.FileName != "")
            {
                outFilePath = saveFloorplanDialog.FileName;
            }
            else
            {
                // If the path fails then tell the user to try again.
                MessageBox.Show("Invalid file path passed, please try again.");
                return;
            }

            FloorplanFileWriter.SaveTileGridData(outFilePath, HouseLayout);
        }

        private void LoadDefaultFloorplanButton_Click(object sender, EventArgs e)
        {
            HouseWidthSelector.Value = 50; // 25 tiles wide (excluding boundary walls)
            HouseHeightSelector.Value = 40; // 20 tiles high (excluding boundary walls)

            FloorplanFileReader.LoadTileGridData(Properties.Resources.DefaultFloorPlan.Split("\n"), HouseLayout);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void LoadSavedFloorplanButton_Click(object sender, EventArgs e)
        {
            string inFilePath;
            // This handy bit of code gets the current user's desktop directory.
            // We use this as the default directory for the load dialog.
            string usrDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            OpenFileDialog openFloorplanDialog = new OpenFileDialog();
            openFloorplanDialog.Title = "Open Floorplan";
            openFloorplanDialog.Filter = "Text files (*.txt)|*.txt|Report Files (*.json)|*.json";
            openFloorplanDialog.InitialDirectory = usrDesktopPath;
            openFloorplanDialog.RestoreDirectory = true;

            if (openFloorplanDialog.ShowDialog() == DialogResult.OK)
            {
                inFilePath = openFloorplanDialog.FileName;
            }
            else
            {
                // If the user closes the dialog without opening anything, just exit out.
                return;
            }
            // Load floorplan from report file
            if (inFilePath.Contains(".json"))
            {
                string simReport = File.ReadAllText(inFilePath);
                SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

                FloorplanFileReader.LoadTileGridData(inreport.FloorplanData, HouseLayout);
            }
            // Load floorplan from saved floorplan
            else
            {
                FloorplanFileReader.LoadTileGridData(inFilePath, HouseLayout);
            }

            // Set the house width and height selector values to the size of the newly-loaded floorplan
            HouseWidthSelector.Value = HouseLayout.numTilesPerRow * 2 - 4;
            HouseHeightSelector.Value = HouseLayout.numTilesPerCol * 2 - 4;

            FloorCanvas.Invalidate();
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            // Need to save simulation data right here
            GenerateReport();
            ResetValuesAfterSimEnd();

            FloorCanvas.Invalidate();
        }

        private void YesRunAnotherSimulationButton_Click(object sender, EventArgs e)
        {
            ResetValuesAfterExitingHeatMap();

            FloorCanvas.Invalidate();
        }

        private void NoRunAnotherSimulationButton_Click(object sender, EventArgs e)
        {
            this.Close(); // User is finished running the program
        }

        private void EraserModeButton_Click(object sender, EventArgs e)
        {
            // Alternate between drawing and eraser modes
            FloorCanvasDesigner.eraserModeOn = !FloorCanvasDesigner.eraserModeOn;

            // Update eraser mode button text
            EraserModeButton.Text = FloorCanvasDesigner.eraserModeOn ? "Eraser Mode: ON" : "Eraser Mode: OFF";
        }

        private void FloorCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvasEditor = e.Graphics;

            var SelectedFloorType = FloorTypeGroupBox.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked).Name;

            if (FloorCanvasDesigner.displayingHeatMap)
            {
                FloorCanvasDesigner.DrawHeatMap(canvasEditor, HouseLayout);
            }
            else
            {
                FloorCanvasDesigner.SetAntiAliasing(canvasEditor);
                FloorCanvasDesigner.DisplayFloorCovering(canvasEditor, HouseLayout, SelectedFloorType);
                FloorCanvasDesigner.PaintChairAndTableBackgrounds(canvasEditor, HouseLayout);
                FloorCanvasDesigner.DisplayCleanedTiles(canvasEditor, HouseLayout);
                FloorCanvasDesigner.DrawVacuum(canvasEditor, VacDisplay);
                // if (Simulation.simStarted) FloorCanvasDesigner.PaintVacuumHitboxInnerTiles(canvasEditor, HouseLayout, VacDisplay);
                // if (Simulation.simStarted) FloorCanvasDesigner.PaintInnerTilesGettingCleaned(canvasEditor, HouseLayout, VacDisplay); // testing purposes
                //FloorCanvasDesigner.DrawInnerTileGridLines(canvasEditor, HouseLayout); // testing purposes
                FloorCanvasDesigner.DrawFloorplan(canvasEditor, HouseLayout, VacDisplay);
            }
        }

        /// <summary>
        /// FloorCanvas_Click is the handler for both the MouseClick and the MouseMove events for FloorCanvas.
        /// This allows us to draw a tile from a single click, as well as a click-and-drag.
        /// Maybe a little bit crude, but it does indeed work.
        /// </summary>
        private void FloorCanvas_Click(object sender, MouseEventArgs e)
        {
            // Prevent drawing while simulation is running and if left click wasn't pressed
            if (Simulation.simStarted || e.Button != MouseButtons.Left)
                return;

            // Get coordinates and indices of selected tile
            PointF canvasCoords = FloorCanvas.PointToClient(Cursor.Position);
            int[] selectedTileIndices = FloorplanLayout.GetTileIndices((int)canvasCoords.X, (int)canvasCoords.Y);

            // Make sure we don't re-draw the canvas if the user is still selecting the same tile while in floorplan drawing mode (efficiency concerns)
            // Also, prevent drawing on the canvas based on various other conditions
            if (FloorCanvasDesigner.justPlacedDoorway || FloorCanvasDesigner.displayingHeatMap || !FloorCanvasDesigner.eraserModeOn && !FloorCanvasDesigner.currentlyAddingDoorway && !FloorCanvasDesigner.settingVacuumAttributes &&
                selectedTileIndices[0] == FloorCanvasDesigner.currentIndicesOfSelectedTile[0] && selectedTileIndices[1] == FloorCanvasDesigner.currentIndicesOfSelectedTile[1])
                return;
            else
            {
                // Set the indices of currently selected tile
                FloorCanvasDesigner.currentIndicesOfSelectedTile[0] = selectedTileIndices[0];
                FloorCanvasDesigner.currentIndicesOfSelectedTile[1] = selectedTileIndices[1];
            }

            // Make sure user clicked within the grid
            if (canvasCoords.X >= HouseLayout.numTilesPerRow * FloorplanLayout.tileSideLength ||
                (canvasCoords.X <= 0 ||
                canvasCoords.Y >= HouseLayout.numTilesPerCol * FloorplanLayout.tileSideLength) ||
                canvasCoords.Y <= 0)
                return;

            // Get currently obstacle selected from combo box and obstacle located at selected tile
            ObstacleType selectedObstacle = FloorplanLayout.GetObstacleTypeFromString(ObstacleSelector.SelectedItem.ToString());
            ObstacleType curObstacleAtTile = HouseLayout.floorLayout[selectedTileIndices[0], selectedTileIndices[1]].obstacle;

            if (FloorCanvasDesigner.settingVacuumAttributes) // User is in vacuum placing stage
            {
                FloorCanvasDesigner.currentlyPlacingVacuum = true;

                // Set the current vacuum coordinates to the coordinates clicked by the user
                ActualVacuumData.VacuumCoords[0] = canvasCoords.X;
                ActualVacuumData.VacuumCoords[1] = canvasCoords.Y;

                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout); // Also, center the vacuum display within the correct inner tile

                FloorCanvasDesigner.AttemptPlaceVacuum(HouseLayout, ActualVacuumData);
            }
            else if (FloorCanvasDesigner.currentlyAddingDoorway) // User currently needs to add a doorway to the room they just placed
            {
                // Process attempt to add doorway to the room
                bool success = FloorCanvasDesigner.AttemptAddDoorwayToRoom(selectedTileIndices[0], selectedTileIndices[1]);

                if (success) // Doorway was just successfully placed
                {
                    HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner);
                    EnableFloorplanWidgets(true);
                }
            }
            else if (FloorCanvasDesigner.eraserModeOn) // If eraser mode is on, remove item that is at this tile
            {
                // Process attempt to remove room from floorplan
                if (curObstacleAtTile == ObstacleType.Wall)
                {
                    FloorCanvasDesigner.RemoveRoomFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
                else if (curObstacleAtTile == ObstacleType.Chair || curObstacleAtTile == ObstacleType.Table) // Process attempt to add chair/table to floorplan
                {
                    FloorCanvasDesigner.RemoveChairOrTableFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
                else if (curObstacleAtTile == ObstacleType.Chest) // Process attempt to add chest to floorplan
                {
                    FloorCanvasDesigner.RemoveChestFromFloorplan(HouseLayout, selectedTileIndices[0], selectedTileIndices[1]);
                }
            }
            else // Otherwise, in drawing mode. Draw room/obstacle
            {
                FloorCanvasDesigner.currentlyAddingObstacle = true;
                FloorCanvasDesigner.FloorplanHouseDesigner.DeepCopyFloorplan(HouseLayout); // Copy the actual house layout into the designer house layout

                // Process attempt to add room to floorplan
                if (selectedObstacle == ObstacleType.Room)
                {
                    FloorCanvasDesigner.AttemptAddRoomToFloorplan(selectedTileIndices[0], selectedTileIndices[1], (int)RoomWidthSelector.Value, (int)RoomHeightSelector.Value);
                }
                else if (selectedObstacle == ObstacleType.Chair || selectedObstacle == ObstacleType.Table) // Process attempt to add chair/table to floorplan
                {
                    FloorCanvasDesigner.AttemptAddChairOrTableToFloorplan(selectedObstacle, selectedTileIndices[0], selectedTileIndices[1], (int)ChairTableWidthSelector.Value, (int)ChairTableHeightSelector.Value);
                }
                else if (selectedObstacle == ObstacleType.Chest) // Process attempt to add chest to floorplan
                {
                    FloorCanvasDesigner.AttemptAddChestToFloorplan(selectedTileIndices[0], selectedTileIndices[1]);
                }
            }

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void FloorCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            // Prevent event when simulation is running or if left mouse button was not pressed
            if (Simulation.simStarted || e.Button != MouseButtons.Left)
                return;

            if (FloorCanvasDesigner.currentlyPlacingVacuum) // Process mouse up event when placing vacuum
            {
                if (FloorCanvasDesigner.vacuumPlacingLocationIsValid) // Vacuum was dropped in valid location
                {
                    FloorCanvasDesigner.successPlacingVacuum = true;
                    EnableSimulationWidgets(true);
                }
                else // Vacuum was dropped in invalid location
                {
                    FloorCanvasDesigner.successPlacingVacuum = false;
                    EnableSimulationWidgets(false);
                }
            }
            else if (FloorCanvasDesigner.successAddingObstacle && !FloorCanvasDesigner.eraserModeOn && !FloorCanvasDesigner.settingVacuumAttributes)
            {
                FloorCanvasDesigner.ChangeSuccessTilesToCurrentObstacle(); // Change success tiles in FloorplanHouseDesigner to be the same obstacle type that was just added
                HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner); // Copy the designer mode house layout to now be the actual house layout

                if (FloorCanvasDesigner.currentObstacleBeingAdded == ObstacleType.Room || FloorCanvasDesigner.currentObstacleBeingAdded == ObstacleType.Wall) // Just placed room, now need to add doorway
                {
                    FloorCanvasDesigner.FloorplanHouseDesigner.DeepCopyFloorplan(HouseLayout); // Back to using the designer mode house layout
                    FloorCanvasDesigner.currentlyAddingDoorway = FloorCanvasDesigner.ShowPossibleDoorwayTiles();

                    if (FloorCanvasDesigner.currentlyAddingDoorway) // Disable all floorplan widgets until user adds the doorway
                    {
                        EnableFloorplanWidgets(false);
                    }
                }
                else
                {
                    FloorCanvasDesigner.ChangeSuccessTilesToCurrentObstacle(); // Change success tiles in FloorplanHouseDesigner to be the same obstacle type that was just added
                    HouseLayout.DeepCopyFloorplan(FloorCanvasDesigner.FloorplanHouseDesigner); // Copy the designer mode house layout to now be the actual house layout
                }
            }

            FloorCanvasDesigner.currentlyPlacingVacuum = false;
            FloorCanvasDesigner.currentlyAddingObstacle = false;
            FloorCanvasDesigner.justPlacedDoorway = false;
            FloorCanvasDesigner.successAddingObstacle = false;

            FloorCanvas.Invalidate();
        }

        private void VacAlgorithmTimer_Tick(object sender, EventArgs e)
        {
            vc.ExecVPath(VacDisplay, HouseLayout, collisionHandler, floorCleaner, ActualVacuumData, sender, e);

            // Decrement the battery
            BatteryLeftLabel.Text = FloorCanvasCalculator.GetBatteryRemainingText(VacDisplay);
            SimTimeElapsedLabel.Text = FloorCanvasCalculator.GetTimeElapsedText();

            // Save and reset simulation data if battery just ran out
            if (VacDisplay.batterySecondsRemaining <= 0)
                ResetValuesAfterSimEnd();
            FloorCanvas.Invalidate();
        }

        private void VacuumWhiskersTimer_Tick(object sender, EventArgs e)
        {
            FloorCanvasCalculator.CalculateWhiskerCoordinates(VacDisplay);

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            SetInitialSimulationValues();
            if (Vacuum.VacuumAlgorithm[0] == 0)
            {
                vc = new VRandAlgorithm();
                VacAlgorithmTimer.Enabled = true;
                Debug.WriteLine("Running " + vc.getVer());
            }
            else if (Vacuum.VacuumAlgorithm[0] == 1)
            {
                vc = new VSpiralAlgorithm();
                VacAlgorithmTimer.Enabled = true;
                Debug.WriteLine("Running " + vc.getVer());
            }
            else if (Vacuum.VacuumAlgorithm[0] == 2)
            {
                vc = new VSnakeAlgorithm();
                VacAlgorithmTimer.Enabled = true;
                Debug.WriteLine("Running " + vc.getVer());
            }
            else if (Vacuum.VacuumAlgorithm[0] == 3)
            {
                vc = new VWallFollowAlgorithm();
                VacAlgorithmTimer.Enabled = true;
                Debug.WriteLine("Running " + vc.getVer());
            }
        }

        /// <summary>
        /// Enables floorplan widgets if value is true, disables them if value is false
        /// </summary>
        /// <param name="value"> A value of true means enable, false means disable </param>
        private void EnableFloorplanWidgets(bool value)
        {
            CreateDoorwayInstructionsLabel.Visible = !value;
            FloorTypeGroupBox.Enabled = value;
            HouseDimensionsGroupBox.Enabled = value;
            ObstaclesGroupBox.Enabled = value;
            RoomDimensionsGroupBox.Enabled = ObstacleSelector.Text.ToString() == "Room" && !FloorCanvasDesigner.currentlyAddingDoorway;
            ChairTableDimensionsGroupBox.Enabled = ObstacleSelector.Text.ToString() == "Chair" || ObstacleSelector.Text.ToString() == "Table";
            LoadSaveFloorplanGroupBox.Enabled = value;
            FinishOrEditFloorplanButton.Enabled = value;
        }

        /// <summary>
        /// Enables simulation widgets if value is true, disables them if value is false
        /// </summary>
        /// <param name="value"> A value of true means enable, false means disable </param>
        private void EnableSimulationWidgets(bool value)
        {
            SimulationControlLabel.Enabled = value;
            SimulationSpeedLabel.Enabled = value;
            SimulationSpeedSelector.Enabled = value;
            StartSimulationButton.Enabled = value;
        }

        /// <summary>
        /// Setting initial UI, vacuum, and simulation data for when simulation starts running
        /// </summary>
        private void SetInitialSimulationValues()
        {
            VacuumWhiskersTimer.Enabled = true;
            HouseLayout.gridLinesOn = false;
            StartSimulationButton.Enabled = false;
            StopSimulationButton.Enabled = true;
            FinishOrEditFloorplanButton.Enabled = false;
            ControlsPane.Panel1.Enabled = false;
            LoadDefaultFloorplanButton.Enabled = false;
            LoadSavedFloorplanButton.Enabled = false;
            SaveFloorplanButton.Enabled = false;
            EraserModeButton.Enabled = false;
            ChairTableWidthSelector.Enabled = false;
            ChairTableHeightSelector.Enabled = false;
            ObstacleSelector.Enabled = false;
            FloorTypeGroupBox.Enabled = false;
            Simulation.simStarted = true;
            Simulation.simTimeElapsed = 0;
            Simulation.simulationStartTime = DateTime.Now.ToString("G");
            FloorCanvasCalculator.frameCount = 0;
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;

            VacuumController.allAlgFinish = false;
            if (RunAllAlgorithmsCheckbox.Checked == true)
            {
                Vacuum.VacuumAlgorithm.Clear();
                for (int i = 0; i < 4; i++)
                    Vacuum.VacuumAlgorithm.Add(i);
            }
            else
            {
                Vacuum.VacuumAlgorithm.Add(RobotPathAlgorithmSelector.SelectedIndex);
            }
            RunAllAlgorithmsCheckbox.Enabled = false;
            ObstacleSelector.Enabled = false;

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);
            VacDisplay.vacuumHeading = (int)InitialVacuumHeadingSelector.Value;

            HouseLayout.SetInnerTileObstacles();
            HouseLayout.PerformAreaCalculations();
        }

        /// <summary>
        /// Resetting UI, vacuum, and simulation data after simulation finishes
        /// </summary>
        private void ResetValuesAfterSimEnd()
        {
            FloorCanvasDesigner.displayingHeatMap = true;
            VacuumWhiskersTimer.Enabled = false;
            VacAlgorithmTimer.Enabled = false;
            HouseLayout.gridLinesOn = true;
            StartSimulationButton.Enabled = true;
            StopSimulationButton.Enabled = false;
            Simulation.simStarted = false;
            Simulation.simTimeElapsed = 0;
            FloorCanvasCalculator.frameCount = 0;
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
            InitialVacuumHeadingSelector.Value = VacDisplay.vacuumHeading;
            YesRunAnotherSimulationButton.Visible = true;
            NoRunAnotherSimulationButton.Visible = true;
            RunAnotherSimulationLabel.Visible = true;

            FloorCanvas.Invalidate(); // Re-trigger paint event
        }

        /// <summary>
        /// Resetting values after the user chooses to return to designing a floor plan after seeing the heat map for their previous run
        /// </summary>
        private void ResetValuesAfterExitingHeatMap()
        {
            FloorCanvasDesigner.displayingHeatMap = false;
            FinishOrEditFloorplanButton.Enabled = true;
            ControlsPane.Panel1.Enabled = true;
            LoadDefaultFloorplanButton.Enabled = true;
            LoadSavedFloorplanButton.Enabled = true;
            SaveFloorplanButton.Enabled = true;
            EraserModeButton.Enabled = true;
            ChairTableWidthSelector.Enabled = true;
            ChairTableHeightSelector.Enabled = true;
            ObstacleSelector.Enabled = true;
            FloorTypeGroupBox.Enabled = true;
            Simulation.simStarted = false;
            Simulation.simTimeElapsed = 0;
            FloorCanvasCalculator.frameCount = 0;
            VacDisplay.batterySecondsRemaining = (int)RobotBatteryLifeSelector.Value * 60;
            RunAllAlgorithmsCheckbox.Enabled = true;

            FloorCanvas.Invalidate(); // Re-trigger paint event
            StartSimulationButton.Enabled = true;
            StopSimulationButton.Enabled = false;
            YesRunAnotherSimulationButton.Visible = false;
            NoRunAnotherSimulationButton.Visible = false;
            RunAnotherSimulationLabel.Visible = false;

            HouseLayout.ResetInnerTiles();
            HouseLayout.totalFloorplanArea = 0;
            HouseLayout.totalNonCleanableFloorplanArea = 0;

            FloorCanvas.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void GenerateReport()
        {
            SimulationReport rep = new SimulationReport
            {
                FloorplanID = HouseLayout.GetFloorPlanID(),
                NumberOfRooms = HouseLayout.numRooms,
                HouseWidthFeet = (int)HouseWidthSelector.Value,
                HouseHeightFeet = (int)HouseHeightSelector.Value,
                HouseFloorType = FloorTypeGroupBox.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked).Name.Replace("RadioButton", "", ignoreCase: true, culture: System.Globalization.CultureInfo.InvariantCulture),
                RobotBatteryLifeMinutes = (int)RobotBatteryLifeSelector.Value,
                RobotEfficiency = VacuumEfficiencySlider.Value,
                //RobotPathingAlgorithm = RobotPathAlgorithmSelector.Text,
                RobotPathingAlgorithm = vc.getVer(),
                RobotSpeedInchesPerSecond = (int)RobotSpeedSelector.Value,
                SimulatedSeconds = Simulation.simTimeElapsed,
                SimulationStartTime = Simulation.simulationStartTime,
                CoveragePercentage = Math.Round(100.0 - HouseLayout.GetFloorplanDirtiness(), 2),
                FloorplanData = FloorplanFileWriter.TileGridDataAsString(HouseLayout),
            };

            // Save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file|*.json";
            saveFileDialog.Title = "Save Simulation Report";
            saveFileDialog.ShowDialog();

            string filename = "SimulationResults.json";

            if (saveFileDialog.FileName != "")
            {
                filename = saveFileDialog.FileName;
            }

            var JSONOpts = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(rep, JSONOpts);
            File.WriteAllText(filename, jsonString);
        }
    }

    /// <summary>
    /// This extension class class just exists to enable double buffering for the FloorCanvas picture box.
    /// </summary>
    public static class Extensions
    {
        public static void EnableDoubleBuffering(this Control control)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(control, true, null);
        }
    }

    /// <summary>
    /// A simulation report to be stored/loaded.
    /// </summary>
    public class SimulationReport
    {
        public string FloorplanID { get; set; }
        public string SimulationStartTime { get; set; }
        public int SimulatedSeconds { get; set; }
        public int HouseWidthFeet { get; set; }
        public int HouseHeightFeet { get; set; }
        public string HouseFloorType { get; set; }
        public int NumberOfRooms { get; set; }
        public int RobotBatteryLifeMinutes { get; set; }
        public int RobotSpeedInchesPerSecond { get; set; }
        public float RobotEfficiency { get; set; }
        public string RobotPathingAlgorithm { get; set; }
        public double CoveragePercentage { get; set; }
        public string[] FloorplanData { get; set; }
        /*
         Simulation ID
        Simulation start time
        Amount of simulated time (simulation clock)
        House size
        House floor type
        Number of rooms (pending room implementation)
        Robot battery life
        Robot speed
        Robot efficiency (should determine a way to calculate this)
        Pathing algorithm used
        Floorplan file (optional?)
        */
    }
}