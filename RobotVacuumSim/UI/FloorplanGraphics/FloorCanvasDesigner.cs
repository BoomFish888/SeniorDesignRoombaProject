using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VacuumSim.Sim;
using VacuumSim.UI.Floorplan;
using VacuumSim.Components;

/// <summary>
/// Includes anything graphics-related that gets applied to the floorplan
/// </summary>
namespace VacuumSim.UI.FloorplanGraphics
{
    public class FloorCanvasDesigner
    {
        public static bool editingFloorplan = true; // Is the user currently editing the floorplan?
        public static bool settingVacuumAttributes = false; // Is the user in the vacuum attribute editing stage?
        public static bool currentlyPlacingVacuum = false; // Is the user currently placing the vacuum?
        public static bool currentlyAddingDoorway = false; // Is the user currently being forced to add a doorway?
        public static bool justPlacedDoorway = false; // Did the user just successfully place a doorway during the current mouse click?
        public static bool vacuumPlacingLocationIsValid = true; // Is the vacuum currently being placed in a valid location?
        public static bool successPlacingVacuum = false; // Was the previous attempt at placing the vacuum onto the floorplan successful?
        public static bool eraserModeOn = false; // Is the user currently drawing in eraser mode?
        public static bool chairTableDrawingModeOn = false; // Is the user currently in chair/table drawing mode?
        public static bool currentlyAddingObstacle = false; // Is the user currently adding an obstacle?
        public static bool successAddingObstacle = true; // Was the previous attempt at adding an obstacle successful?
        public static bool displayingHeatMap = false; // Are we currently displaying the heatmap?
        public static ObstacleType currentObstacleBeingAdded; // Current obstacle being added
        public static int[] currentIndicesOfSelectedTile = { -1, -1 }; // col, row indices of tile currently selected
        public static FloorplanLayout FloorplanHouseDesigner; // Floorplan that gets used when adding obstacle

        /// <summary>
        /// Turns on anti-aliasing
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void SetAntiAliasing(Graphics CanvasEditor)
        {
            CanvasEditor.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public static void DisplayFloorCovering(Graphics CanvasEditor, FloorplanLayout HouseLayout, string SelectedFloorType)
        {
            FloorplanLayout CurrentLayout = currentlyAddingObstacle || currentlyAddingDoorway ? FloorplanHouseDesigner : HouseLayout;
            TextureBrush FloorTextureBrush;

            switch (SelectedFloorType)
            {
                case "LoopPileRadioButton":
                    FloorTextureBrush = new TextureBrush(Properties.Resources.looppile);
                    break;

                case "CutPileRadioButton":
                    FloorTextureBrush = new TextureBrush(Properties.Resources.cutpile);
                    break;

                case "FriezeCutPileRadioButton":
                    FloorTextureBrush = new TextureBrush(Properties.Resources.frieze);
                    break;

                default:
                case "HardWoodRadioButton":
                    FloorTextureBrush = new TextureBrush(Properties.Resources.wood);
                    break;
            }

            FloorTextureBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            for (int i = 0; i < CurrentLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < CurrentLayout.numTilesPerCol; j++)
                {
                    if ((CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Floor))//CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Doorway)) // Blank tile
                    {
                        PaintTile(i, j, FloorTextureBrush, CanvasEditor);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the floorplan to FloorCanvas based on HouseLayout's 2D array of tiles
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The current floor plan layout </param>
        public static void DrawFloorplan(Graphics CanvasEditor, FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            // Get the current layout, depending on if we're in design mode or just displaying the floorplan
            FloorplanLayout CurrentLayout = currentlyAddingObstacle || currentlyAddingDoorway ? FloorplanHouseDesigner : HouseLayout;

            for (int i = 0; i < CurrentLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < CurrentLayout.numTilesPerCol; j++)
                {
                    if ((CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Floor) && CurrentLayout.gridLinesOn) // Blank tile
                    {
                        DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Wall) // Wall tile
                    {
                        if (IsBoundaryWallTile(HouseLayout, HouseLayout.floorLayout[i, j]))
                            PaintTile(i, j, new SolidBrush(Color.Black), CanvasEditor);
                        else
                            PaintTile(i, j, new SolidBrush(Color.FromArgb(54, 69, 79)), CanvasEditor); // Room walls are charcoal gray
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chest) // Chest tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Sienna), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chair) // Chair tile
                    {
                        if (CurrentLayout.gridLinesOn)
                            DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);

                        DrawChairOrTable(i, j, CurrentLayout, new SolidBrush(Color.DarkSlateBlue), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Table) // Table tile
                    {
                        if (CurrentLayout.gridLinesOn)
                            DrawTileOutline(i, j, new Pen(Color.Black), CanvasEditor);

                        DrawChairOrTable(i, j, CurrentLayout, new SolidBrush(Color.Tomato), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Success) // Success tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.LimeGreen), CanvasEditor);
                    }
                    else if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Error) // Error tile
                    {
                        PaintTile(i, j, new SolidBrush(Color.Red), CanvasEditor);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the heatmap showing what locations the vacuum cleaned well and not so well.
        /// Gets displayed after a simulation ends. Disappears after the user returns to editing the floorplan
        /// </summary>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floor plan layout </param>
        public static void DrawHeatMap(Graphics canvasEditor, FloorplanLayout HouseLayout)
        {
            Brush heatMapPainter;
            Color innerTileColor;

            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    for (int k = 0; k < Tile.numInnerTilesInRowAndCol; k++)
                    {
                        for (int l = 0; l < Tile.numInnerTilesInRowAndCol; l++)
                        {
                            Tile theTile = HouseLayout.floorLayout[i, j];
                            InnerTile theInnerTile = HouseLayout.GetInnerTileFromCoordinates(theTile.x + k * InnerTile.innerTileSideLength, theTile.y + l * InnerTile.innerTileSideLength);

                            float blueIntensity = theInnerTile.dirtiness / 100.0f * 110.0f;
                            float redIntensity = 110.0f - (theInnerTile.dirtiness / 100.0f * 110.0f);
                            innerTileColor = Color.FromArgb((int)redIntensity, 0, (int)blueIntensity);
                            heatMapPainter = new SolidBrush(innerTileColor);

                            canvasEditor.FillRectangle(heatMapPainter, theTile.x + k * InnerTile.innerTileSideLength, theTile.y + l * InnerTile.innerTileSideLength, InnerTile.innerTileSideLength, InnerTile.innerTileSideLength);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows a trail of where the vacuum has cleaned during the running simulation
        /// </summary>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floor plan layout </param>
        public static void DisplayCleanedTiles(Graphics canvasEditor, FloorplanLayout HouseLayout)
        {
            Brush heatMapPainter;
            Color innerTileColor;

            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    for (int k = 0; k < Tile.numInnerTilesInRowAndCol; k++)
                    {
                        for (int l = 0; l < Tile.numInnerTilesInRowAndCol; l++)
                        {
                            Tile theTile = HouseLayout.floorLayout[i, j];
                            InnerTile theInnerTile = HouseLayout.GetInnerTileFromCoordinates(theTile.x + k * InnerTile.innerTileSideLength, theTile.y + l * InnerTile.innerTileSideLength);

                            // Only paint an inner tile that has been cleaned at least once
                            if (theInnerTile.dirtiness < 100)
                            {
                                float redIntensity = 200.0f - (theInnerTile.dirtiness / 100.0f * 200.0f);
                                innerTileColor = Color.FromArgb((int)redIntensity, 0, 0);
                                heatMapPainter = new SolidBrush(innerTileColor);

                                canvasEditor.FillRectangle(heatMapPainter, theTile.x + k * InnerTile.innerTileSideLength, theTile.y + l * InnerTile.innerTileSideLength, InnerTile.innerTileSideLength, InnerTile.innerTileSideLength);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draws gridlines showing all inner tiles.
        /// Just used for testing purposes. Wouldn't recommend using because it slows down things a lot.
        /// That's probably because there's a maximum of 72,000 inner tiles (that'll do it)
        /// </summary>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floor plan layout display </param>
        public static void DrawInnerTileGridLines(Graphics canvasEditor, FloorplanLayout HouseLayout)
        {
            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    for (int k = 0; k < Tile.numInnerTilesInRowAndCol; k++)
                    {
                        for (int l = 0; l < Tile.numInnerTilesInRowAndCol; l++)
                        {
                            DrawInnerTileOutline(i, j, k, l, new Pen(Color.Aqua), canvasEditor);
                        }
                    }    
                }
            }
        }

        /// <summary>
        /// Paints tiles being cleaned by the vacuum whiskers yellow, and paints the tile being cleaned by the vacuum aqua blue.
        /// Just used for testing purposes. Will probably be pretty useful for debugging collision detection and vacuum cleaning.
        /// </summary>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floor plan layout display </param>
        /// <param name="VacDisplay"> The display of the vacuum used in the simulation </param>
        public static void PaintInnerTilesGettingCleaned(Graphics canvasEditor, FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            int vacuumX = (int)VacDisplay.vacuumCoords[0];
            int vacuumY = (int)VacDisplay.vacuumCoords[1];
            InnerTile centerInnerTile = HouseLayout.GetInnerTileFromCoordinates(vacuumX, vacuumY);

            SolidBrush brush = new SolidBrush(Color.Yellow);
            List<InnerTile> tilesCleanedByWhiskers = HouseLayout.GetInnerTilesBeingCleanedByWhiskers(VacDisplay);

            foreach (InnerTile iTile in tilesCleanedByWhiskers)
            {
                canvasEditor.FillRectangle(brush, iTile.x, iTile.y, InnerTile.innerTileSideLength, InnerTile.innerTileSideLength);
            }

            brush = new SolidBrush(Color.Aqua);
            canvasEditor.FillRectangle(brush, centerInnerTile.x, centerInnerTile.y, InnerTile.innerTileSideLength, InnerTile.innerTileSideLength);
        }

        /// <summary>
        /// Paints tiles containing the vacuum display orange.
        /// </summary>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="HouseLayout"> The floor plan layout display </param>
        /// <param name="VacDisplay"> The display of the vacuum used in the simulation </param>
        public static void PaintVacuumHitboxInnerTiles(Graphics canvasEditor, FloorplanLayout HouseLayout, VacuumDisplay VacDisplay)
        {
            List<InnerTile> vacuumHitboxInnerTiles = HouseLayout.GetVacuumHitboxInnerTiles(VacDisplay, HouseLayout);
            SolidBrush brush = new SolidBrush(Color.Orange);

            foreach (InnerTile iTile in vacuumHitboxInnerTiles)
            {
                canvasEditor.FillRectangle(brush, iTile.x, iTile.y, InnerTile.innerTileSideLength, InnerTile.innerTileSideLength);
            }
        }

        /// <summary>
        /// Fills in a tile on the floor plan grid
        /// </summary>
        /// <param name="rowIndex"> Index of chosen row </param>
        /// <param name="colIndex"> Index of chosen column </param>
        /// <param name="brush"> Brush chosen to fill in the tile </param>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void PaintTile(int rowIndex, int colIndex, Brush brush, Graphics canvasEditor)
        {
            canvasEditor.FillRectangle(brush, FloorplanLayout.tileSideLength * rowIndex, FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength);
        }

        /// <summary>
        /// Paints a light sky blue background behind every chair/table tile
        /// Might remove in future once we actually use a visual display of the floor covering being used.
        /// </summary>
        /// <param name="CurrentLayout"> The active FloorplanLayout object </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void PaintChairAndTableBackgrounds(Graphics CanvasEditor, FloorplanLayout CurrentLayout)
        {
            for (int i = 0; i < CurrentLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < CurrentLayout.numTilesPerCol; j++)
                {
                    if (CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Chair || CurrentLayout.floorLayout[i, j].obstacle == ObstacleType.Table)
                        PaintTile(i, j, new SolidBrush(Color.LightSkyBlue), CanvasEditor);
                }
            }
        }

        /// <summary>
        /// Draw a tile (just the outline, no fill) using a Pen */
        /// </summary>
        /// <param name="colIndex"> Index of column </param>
        /// <param name="rowIndex"> Index of row </param>
        /// <param name="penColor"> Pen color </param>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void DrawTileOutline(int colIndex, int rowIndex, Pen penColor, Graphics canvasEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength * rowIndex);
            Point p2 = new Point(FloorplanLayout.tileSideLength * colIndex, FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength);
            Point p3 = new Point(FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * rowIndex + FloorplanLayout.tileSideLength);
            Point p4 = new Point(FloorplanLayout.tileSideLength * colIndex + FloorplanLayout.tileSideLength, FloorplanLayout.tileSideLength * rowIndex);

            // Draw the tile
            canvasEditor.DrawLine(penColor, p1, p2);
            canvasEditor.DrawLine(penColor, p2, p3);
            canvasEditor.DrawLine(penColor, p3, p4);
            canvasEditor.DrawLine(penColor, p4, p1);
        }

        /// <summary>
        /// Draws an inner tile.
        /// Just used for testing purposes.
        /// </summary>
        /// <param name="parentColIndex"> Index of column </param>
        /// <param name="parentRowIndex"> Index of row </param>
        /// <param name="innerColIndex"> Index of inner tile column </param>
        /// <param name="innerRowIndex"> Index of inner tile row </param>
        /// <param name="penColor"> Pen color </param>
        /// <param name="canvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void DrawInnerTileOutline(int parentColIndex, int parentRowIndex, int innerColIndex, int innerRowIndex, Pen penColor, Graphics canvasEditor)
        {
            // Get the coordinates of each tile corner
            Point p1 = new Point(FloorplanLayout.tileSideLength * parentColIndex + InnerTile.innerTileSideLength * innerColIndex, FloorplanLayout.tileSideLength * parentRowIndex + InnerTile.innerTileSideLength * innerRowIndex);
            Point p2 = new Point(FloorplanLayout.tileSideLength * parentColIndex + InnerTile.innerTileSideLength * innerColIndex + InnerTile.innerTileSideLength, FloorplanLayout.tileSideLength * parentRowIndex + InnerTile.innerTileSideLength * innerRowIndex);
            Point p3 = new Point(FloorplanLayout.tileSideLength * parentColIndex + InnerTile.innerTileSideLength * innerColIndex + InnerTile.innerTileSideLength, FloorplanLayout.tileSideLength * parentRowIndex + InnerTile.innerTileSideLength * innerRowIndex + InnerTile.innerTileSideLength);
            Point p4 = new Point(FloorplanLayout.tileSideLength * parentColIndex + InnerTile.innerTileSideLength * innerColIndex, FloorplanLayout.tileSideLength * parentRowIndex + InnerTile.innerTileSideLength * innerRowIndex + InnerTile.innerTileSideLength);

            // Draw the tile
            canvasEditor.DrawLine(penColor, p1, p2);
            canvasEditor.DrawLine(penColor, p2, p3);
            canvasEditor.DrawLine(penColor, p3, p4);
            canvasEditor.DrawLine(penColor, p4, p1);
        }


        /// <summary>
        /// Updates floorplan after the user changes the house width.
        ///
        /// If the width was increased, the only change that happens is
        /// more house boundary walls get drawn and rooms connected to
        /// the boundary wall get their own boundary wall.
        ///
        /// If the width was decreased, the affected boundary walls will get set to floor tiles
        /// and any affected obstacle will be removed, with the exception of rooms. Rooms will just be
        /// decreased in size. However, if a room is reduced to a single column of wall tiles or is
        /// completely obfuscated, the room gets removed.
        /// </summary>
        /// <param name="HouseLayout"> The floor plan layout </param>
        /// <param name="prevNumTilesPerRow"> Number of tiles per row before the user changed the house width </param>
        public static void UpdateFloorplanAfterHouseWidthChanged(FloorplanLayout HouseLayout, int prevNumTilesPerRow)
        {
            if (prevNumTilesPerRow < HouseLayout.numTilesPerRow) // House width was increased
            {
                // Remove previous boundary wall on right side of house
                for (int y = 1; y < HouseLayout.numTilesPerCol - 1; y++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(prevNumTilesPerRow - 1, y, ObstacleType.Floor);
                }

                // Add new boundary wall tiles on bottom and top sides of house
                for (int x = prevNumTilesPerRow; x < HouseLayout.numTilesPerRow; x++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(x, 0, ObstacleType.Wall); // Add top boundary wall tile
                    HouseLayout.ModifyTileBasedOnIndices(x, HouseLayout.numTilesPerCol - 1, ObstacleType.Wall); // Add bottom boundary wall tile
                }

                // Add new boundary wall on right side of house
                for (int y = 0; y < HouseLayout.numTilesPerCol; y++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(HouseLayout.numTilesPerRow - 1, y, ObstacleType.Wall);
                }
            }
            else if (prevNumTilesPerRow > HouseLayout.numTilesPerRow) // House width was decreased
            {
                // Iterate through all of the affected columns
                for (int x = HouseLayout.numTilesPerRow - 1; x < prevNumTilesPerRow; x++)
                {
                    // Iterate through each tile in this column and destroy/alter the affected obstacles
                    for (int y = 0; y < HouseLayout.numTilesPerCol; y++)
                    {
                        Tile affectedTile = HouseLayout.floorLayout[x, y];

                        if (affectedTile.obstacle == ObstacleType.Chest || (affectedTile.obstacle == ObstacleType.Wall && affectedTile.groupID == -1))
                            HouseLayout.ModifyTileBasedOnIndices(x, y, ObstacleType.Floor, -1);
                        else if (affectedTile.obstacle == ObstacleType.Wall && affectedTile.groupID != -1) // Room wall
                            RemoveRoomFromFloorplan(HouseLayout, x, y);
                        else if (affectedTile.obstacle == ObstacleType.Chair || affectedTile.obstacle == ObstacleType.Table)
                            RemoveChairOrTableFromFloorplan(HouseLayout, x, y);
                    }
                }

                // Add new boundary wall on right side of house
                for (int y = 0; y < HouseLayout.numTilesPerCol; y++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(HouseLayout.numTilesPerRow - 1, y, ObstacleType.Wall, -1);
                }
            }
            else // House width stayed the same - no actions necessary
                return;
        }

        /// <summary>
        /// Updates floorplan after the user changes the house height.
        ///
        /// If the height was increased, the only change that happens is
        /// more house boundary walls get drawn and rooms previously connected to
        /// the boundary wall will now get their own boundary wall.
        ///
        /// If the height was decreased, the affected boundary walls will get set to floor tiles
        /// and any affected obstacle will be removed, with the exception of rooms. Rooms will just be
        /// decreased in size. However, if a room is reduced to a single row of wall tiles or is
        /// completely obfuscated, the room gets removed.
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout </param>
        /// <param name="prevNumTilesPerRow"> Number of tiles per row before the user changed the house height </param>
        public static void UpdateFloorplanAfterHouseHeightChanged(FloorplanLayout HouseLayout, int prevNumTilesPerCol)
        {
            if (prevNumTilesPerCol < HouseLayout.numTilesPerCol) // House height was increased
            {
                // Remove previous boundary wall on bottom side of house
                for (int x = 1; x < HouseLayout.numTilesPerRow - 1; x++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(x, prevNumTilesPerCol - 1, ObstacleType.Floor);
                }

                // Add new boundary wall tiles on left and right sides of house
                for (int y = prevNumTilesPerCol; y < HouseLayout.numTilesPerCol; y++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(0, y, ObstacleType.Wall); // Add left boundary wall tile
                    HouseLayout.ModifyTileBasedOnIndices(HouseLayout.numTilesPerRow - 1, y, ObstacleType.Wall); // Add right boundary wall tile
                }

                // Add new boundary wall on bottom side of house
                for (int x = 0; x < HouseLayout.numTilesPerRow; x++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(x, HouseLayout.numTilesPerCol - 1, ObstacleType.Wall);
                }
            }
            else if (prevNumTilesPerCol > HouseLayout.numTilesPerCol) // House height was decreased
            {
                // Iterate through all of the affected rows
                for (int y = HouseLayout.numTilesPerCol - 1; y < prevNumTilesPerCol; y++)
                {
                    // Iterate through each non-boundary tile in this row and destroy/alter the affected obstacles
                    for (int x = 0; x < HouseLayout.numTilesPerRow; x++)
                    {
                        Tile affectedTile = HouseLayout.floorLayout[x, y];

                        if (affectedTile.obstacle == ObstacleType.Chest || (affectedTile.obstacle == ObstacleType.Wall && affectedTile.groupID == -1))
                            HouseLayout.ModifyTileBasedOnIndices(x, y, ObstacleType.Floor, -1);
                        else if (affectedTile.obstacle == ObstacleType.Wall && affectedTile.groupID != -1) // Room wall
                            RemoveRoomFromFloorplan(HouseLayout, x, y);
                        else if (affectedTile.obstacle == ObstacleType.Chair || affectedTile.obstacle == ObstacleType.Table)
                            RemoveChairOrTableFromFloorplan(HouseLayout, x, y);
                    }
                }

                // Add the new boundary wall on bottom side of house
                for (int x = 0; x < HouseLayout.numTilesPerRow; x++)
                {
                    HouseLayout.ModifyTileBasedOnIndices(x, HouseLayout.numTilesPerCol - 1, ObstacleType.Wall, -1);
                }
            }
            else // House height stayed the same - no actions necessary
                return;
        }

        /// <summary>
        /// Draws the vacuum onto FloorCanvas
        /// </summary>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        public static void DrawVacuum(Graphics CanvasEditor, VacuumDisplay VacDisplay)
        {
            if (!Simulation.simStarted && !successPlacingVacuum && !currentlyPlacingVacuum) // Don't draw vacuum if none of these cases are true
                return;

            Pen whiskersPen;
            SolidBrush vacuumBrush;

            // Determine brush and pen color
            if (!currentlyPlacingVacuum) // Not currently placing the vacuum. Draw it magenta and its whiskers medium spring green
            {
                whiskersPen = new Pen(Color.MediumSpringGreen);
                vacuumBrush = new SolidBrush(Color.Magenta);
            }
            else // Currently placing the vacuum. Will be red or lime green depending on if vacuum is in valid location or not
            {
                if (vacuumPlacingLocationIsValid)
                {
                    whiskersPen = new Pen(Color.LimeGreen);
                    vacuumBrush = new SolidBrush(Color.LimeGreen);
                }
                else
                {
                    whiskersPen = new Pen(Color.Red);
                    vacuumBrush = new SolidBrush(Color.Red);
                }
            }

            FloorCanvasCalculator.CalculateWhiskerCoordinates(VacDisplay);

            // Draw vacuum whiskers
            PointF leftWhiskersStart = new PointF(VacDisplay.leftWhiskersStartingCoords[0], VacDisplay.leftWhiskersStartingCoords[1]);
            PointF leftWhiskersEnd = new PointF(VacDisplay.leftWhiskersEndingCoords[0], VacDisplay.leftWhiskersEndingCoords[1]);
            PointF rightWhiskersStart = new PointF(VacDisplay.rightWhiskersStartingCoords[0], VacDisplay.rightWhiskersStartingCoords[1]);
            PointF rightWhiskersEnd = new PointF(VacDisplay.rightWhiskersEndingCoords[0], VacDisplay.rightWhiskersEndingCoords[1]);
            CanvasEditor.DrawLine(whiskersPen, leftWhiskersStart, leftWhiskersEnd);
            CanvasEditor.DrawLine(whiskersPen, rightWhiskersStart, rightWhiskersEnd);

            // Draw vacuum body
            FillCircle(vacuumBrush, VacuumDisplay.vacuumDiameter / 2, VacDisplay.vacuumCoords[0], VacDisplay.vacuumCoords[1], CanvasEditor);
        }

        /// <summary>
        /// Draws a chair or table, which consists of 4 circles for legs.
        /// </summary>
        /// <param name="rowIndex"> Index of selected row </param>
        /// <param name="colIndex"> Index of selected column </param>
        /// <param name="CurrentLayout"> The active layout (either the normal house or the designer mode house) </param>
        /// <param name="brush"> Brush to draw the chair/table </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        public static void DrawChairOrTable(int rowIndex, int colIndex, FloorplanLayout CurrentLayout, SolidBrush brush, Graphics CanvasEditor)
        {
            // Get the coordinates of each leg of the chair/table
            float[,] chairOrTableCoordinates = CurrentLayout.GetChairOrTableLegCoordinates(CurrentLayout.floorLayout[rowIndex, colIndex]);

            // Prevent drawing the chair/table legs again if we've already drawn them once
            // We know we've already drawn them if we are not currently checking the upper left tile associated with the table/chair
            if ((rowIndex != (int)chairOrTableCoordinates[FloorplanLayout.UL, 0] / FloorplanLayout.tileSideLength || colIndex != (int)chairOrTableCoordinates[FloorplanLayout.UL, 1] / FloorplanLayout.tileSideLength) && !currentlyAddingObstacle)
                return;

            // Draw the chair/table legs (unless they are being covered up as the user is adding an obstacle)
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.LL, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.LL, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.LL, 0], chairOrTableCoordinates[FloorplanLayout.LL, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.LR, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.LR, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.LR, 0], chairOrTableCoordinates[FloorplanLayout.LR, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.UR, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.UR, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.UR, 0], chairOrTableCoordinates[FloorplanLayout.UR, 1], CanvasEditor);
            if (CurrentLayout.floorLayout[(int)chairOrTableCoordinates[FloorplanLayout.UL, 0] / FloorplanLayout.tileSideLength, (int)chairOrTableCoordinates[FloorplanLayout.UL, 1] / FloorplanLayout.tileSideLength].obstacle != ObstacleType.Error)
                FillCircle(brush, FloorplanLayout.chairAndTableLegRadius, chairOrTableCoordinates[FloorplanLayout.UL, 0], chairOrTableCoordinates[FloorplanLayout.UL, 1], CanvasEditor);
        }

        /// <summary>
        /// Helper function to draw a filled circle
        /// </summary>
        /// <param name="brush"> Brush chosen to fill in the tile </param>
        /// <param name="radius"> Radius of the circle to be drawn </param>
        /// <param name="centerX"> X coordinate of circle on FloorCanvas </param>
        /// <param name="centerY"> Y coordinate of circle on FloorCanvas </param>
        /// <param name="CanvasEditor"> Graphics object to edit FloorCanvas </param>
        private static void FillCircle(SolidBrush brush, float radius, float centerX, float centerY, Graphics CanvasEditor)
        {
            CanvasEditor.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        /// <summary>
        /// This gets called as user is clicking and dragging the vacuum around.
        /// It sets the "vacuumPlacingLocationIsValid" flag to true or false depending on if the vacuum was placed in a valid location or not.
        /// Then, in "FloorCanvas_MouseUp" in Form1.cs, it is decided if the vacuum can be placed or not, depending on if it was placed in a valid location or not
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="ActualVacuumData"> The vacuum data </param>
        public static void AttemptPlaceVacuum(FloorplanLayout HouseLayout, Vacuum ActualVacuumData)
        {
            vacuumPlacingLocationIsValid = true; // Initially set to true, could get changed if vacuum is in invalid position

            // Get center tile and its (x, y) indices
            Tile tileContainingVacuumCenter = HouseLayout.GetTileFromCoordinates((int)ActualVacuumData.VacuumCoords[0], (int)ActualVacuumData.VacuumCoords[1]);

            int[] centerTileIndices = FloorplanLayout.GetTileIndices(tileContainingVacuumCenter.x, tileContainingVacuumCenter.y);

            // If tile containing vacuum center is a chest or wall tile, this is for sure invalid
            if (tileContainingVacuumCenter.obstacle == ObstacleType.Chest || tileContainingVacuumCenter.obstacle == ObstacleType.Wall)
            {
                vacuumPlacingLocationIsValid = false;
                return;
            }

            List<Tile> tilesVacuumCouldBeIn = new List<Tile>();

            // Get all tiles surrounding the center tile (including tiles connected by a corner)
            for (int i = centerTileIndices[0] - 1; i <= centerTileIndices[0] + 1; i++)
            {
                for (int j = centerTileIndices[1] - 1; j <= centerTileIndices[1] + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < HouseLayout.numTilesPerRow && j < HouseLayout.numTilesPerCol) // Make sure tile index is within grid
                    {
                        tilesVacuumCouldBeIn.Add(HouseLayout.floorLayout[i, j]);
                    }
                }
            }

            // Iterate through each possible tile and detect if the vacuum is touching any obstacles
            foreach (Tile tile in tilesVacuumCouldBeIn)
            {
                if (tile.obstacle == ObstacleType.Floor)
                    continue; // Vacuum can touch any part of this tile with no issues

                float vacRadius = VacuumDisplay.vacuumDiameter / 2.0f;
                float chairAndTableLegRadius = FloorplanLayout.chairAndTableLegRadius;
                int lenTile = FloorplanLayout.tileSideLength;

                if (tile.obstacle == ObstacleType.Wall || tile.obstacle == ObstacleType.Chest) // Check for circle intersection with line
                {
                    // Will get set to the coordinates of an edge or stay the same
                    float testX = ActualVacuumData.VacuumCoords[0];
                    float testY = ActualVacuumData.VacuumCoords[1];

                    if (ActualVacuumData.VacuumCoords[0] < tile.x) // Vacuum's center is to the left of the left vertical tile line
                        testX = tile.x;
                    else if (ActualVacuumData.VacuumCoords[0] > tile.x + lenTile) // Vacuum's center is to the right of the right vertical tile line
                        testX = tile.x + lenTile;

                    if (ActualVacuumData.VacuumCoords[1] < tile.y) // Vacuum's center is above the top horizontal tile line
                        testY = tile.y;
                    else if (ActualVacuumData.VacuumCoords[1] > tile.y + lenTile) // Vacuum's center is below the bottom horizontal line
                        testY = tile.y + lenTile;

                    float distX = ActualVacuumData.VacuumCoords[0] - testX;
                    float distY = ActualVacuumData.VacuumCoords[1] - testY;
                    float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

                    if (distance <= vacRadius)
                        vacuumPlacingLocationIsValid = false;
                }
                else if (tile.obstacle == ObstacleType.Chair || tile.obstacle == ObstacleType.Table) // Check for circle intersection with circle or circle enveloping circle
                {
                    float[,] chairOrTableLegCoords = HouseLayout.GetChairOrTableLegCoordinates(tile);

                    // Iterate through each chair/table leg coordinate pair and check for collision with any of the legs
                    for (int i = 0; i < 4; i++)
                    {
                        double sumCircleCenterDistSquared = Math.Pow(ActualVacuumData.VacuumCoords[0] - chairOrTableLegCoords[i, 0], 2) + Math.Pow(ActualVacuumData.VacuumCoords[1] - chairOrTableLegCoords[i, 1], 2);

                        // Check if distance between circle centers is between the sum and difference of their radii
                        // If so, the circles intersect
                        if (sumCircleCenterDistSquared >= Math.Pow(vacRadius - chairAndTableLegRadius, 2) && sumCircleCenterDistSquared <= Math.Pow(vacRadius + chairAndTableLegRadius, 2))
                            vacuumPlacingLocationIsValid = false;
                        // Check if vacuum completely envelopes a chair/table leg without intersecting along the edge
                        // This would still be a collision
                        else if (vacRadius >= Math.Sqrt(sumCircleCenterDistSquared) + chairAndTableLegRadius)
                            vacuumPlacingLocationIsValid = false;
                    }
                }
            }
        }

        /// <summary>
        /// Edits the "designer mode" floorplan to mark room (aka wall) tiles as "Success" or "Error" if they can/cannot be placed here
        /// </summary>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        /// <param name="roomWidth"> Width of room in feet </param>
        /// <param name="roomHeight"> Width of room in feet </param>
        public static void AttemptAddRoomToFloorplan(int xTileIndex, int yTileIndex, int roomWidth, int roomHeight)
        {
            currentObstacleBeingAdded = ObstacleType.Room;
            int roomWidthInTiles = Math.Min(roomWidth / 2, FloorplanHouseDesigner.numTilesPerRow - 2);
            int roomHeightInTiles = Math.Min(roomHeight / 2, FloorplanHouseDesigner.numTilesPerCol - 2);
            successAddingObstacle = true; // Initially set to true, could get changed if obstacle is in invalid position

            // Check for out of bounds on or past the room's boundary walls. If there are some, can't place room here
            if (xTileIndex <= 0 || xTileIndex + roomWidthInTiles + 1 >= FloorplanHouseDesigner.numTilesPerRow - 1 ||
                yTileIndex <= 0 || yTileIndex + roomHeightInTiles + 1 >= FloorplanHouseDesigner.numTilesPerCol - 1)
                successAddingObstacle = false;
            else // All tiles are within the house boundaries. Now make sure they're not obstructing any obstacles
            {
                // Check if room's upper and lower boundary walls can be placed here
                for (int i = xTileIndex; i <= xTileIndex + roomWidthInTiles + 1; i++)
                {
                    Tile upperTile = FloorplanHouseDesigner.floorLayout[i, yTileIndex];
                    Tile lowerTile = FloorplanHouseDesigner.floorLayout[i, yTileIndex + roomHeightInTiles + 1];

                    if (upperTile.obstacle != ObstacleType.Floor || lowerTile.obstacle != ObstacleType.Floor)
                        successAddingObstacle = false;
                }

                // Check if room's left and right boundary walls can be placed here
                for (int j = yTileIndex; j < yTileIndex + roomHeightInTiles + 1; j++)
                {
                    Tile leftTile = FloorplanHouseDesigner.floorLayout[xTileIndex, j];
                    Tile rightTile = FloorplanHouseDesigner.floorLayout[xTileIndex + roomWidthInTiles + 1, j];

                    if (leftTile.obstacle != ObstacleType.Floor || rightTile.obstacle != ObstacleType.Floor)
                        successAddingObstacle = false;
                }
            }

            ObstacleType ob = successAddingObstacle ? ObstacleType.Success : ObstacleType.Error;

            // Mark the tiles that the room's upper and lower boundary walls are covering as success/error tiles
            for (int i = xTileIndex; i <= xTileIndex + roomWidthInTiles + 1 && i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                Tile upperTile = FloorplanHouseDesigner.floorLayout[i, yTileIndex];
                Tile lowerTile;

                if (i < FloorplanHouseDesigner.numTilesPerRow)
                    upperTile.obstacle = ob;
                if (yTileIndex + roomHeightInTiles + 1 < FloorplanHouseDesigner.numTilesPerCol)
                {
                    lowerTile = FloorplanHouseDesigner.floorLayout[i, yTileIndex + roomHeightInTiles + 1];

                    lowerTile.obstacle = ob;
                }
            }

            // Mark the tiles that the room's left and right boundary walls are covering as success/error tiles
            for (int j = yTileIndex; j <= yTileIndex + roomHeightInTiles + 1 && j < FloorplanHouseDesigner.numTilesPerCol; j++)
            {
                Tile leftTile = FloorplanHouseDesigner.floorLayout[xTileIndex, j];
                Tile rightTile;

                if (j < FloorplanHouseDesigner.numTilesPerCol)
                    leftTile.obstacle = ob;

                if (xTileIndex + roomWidthInTiles + 1 < FloorplanHouseDesigner.numTilesPerRow)
                {
                    rightTile = FloorplanHouseDesigner.floorLayout[xTileIndex + roomWidthInTiles + 1, j];
                    rightTile.obstacle = ob;
                }
            }
            // Increment number of rooms
            FloorplanHouseDesigner.numRooms++;
        }

        /// <summary>
        /// Processes user's attempt to add a doorway to the floor plan
        /// </summary>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        /// <returns> Whether or not a doorway was successfully added </returns>
        public static bool AttemptAddDoorwayToRoom(int xTileIndex, int yTileIndex)
        {
            if (FloorplanHouseDesigner.floorLayout[xTileIndex, yTileIndex].obstacle == ObstacleType.Success) // User can add doorway here
            {
                FloorplanHouseDesigner.ModifyTileBasedOnIndices(xTileIndex, yTileIndex, ObstacleType.Floor); // Add the doorway
                ChangeSuccessTilesToCurrentObstacle(); // Change the other success tiles to wall tiles
                ChangeErrorTilesToCurrentObstacle(); // Change the error tiles to wall tiles

                justPlacedDoorway = true;
                currentlyAddingDoorway = false;

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Marks every tile where the user can place the doorway for the previously added room as a green "Success" tile.
        /// Marks every invalid doorway tile for the previously added room as a red "Error" tile
        /// </summary>
        /// <returns> A boolean for if a doorway is needed for the room just added </returns>
        public static bool ShowPossibleDoorwayTiles()
        {
            bool doorwayNeeded = false;
            int roomGroupID = FloorplanFileWriter.currentObstacleGroupNumber - 1; // Get the group ID of the room just added

            // First, add segwaying doorway if necessary
            for (int i = 0; i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                for (int j = 0; j < FloorplanHouseDesigner.numTilesPerCol; j++)
                {
                    if (FloorplanHouseDesigner.floorLayout[i, j].groupID == roomGroupID) // This tile is part of the room we just added
                    {
                        if (IsAdjacentToDoorwayTile(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]) &&
                            GetGroupIDOfConnectedDoorway(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]) != FloorplanHouseDesigner.floorLayout[i, j].groupID &&
                            !IsRoomCornerTile(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]))
                        {
                            FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, ObstacleType.Floor);
                        }
                    }
                }
            }

            // Now, mark the possible doorway tiles as success (door can be placed here) or error (door can't be placed here)
            for (int i = 0; i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                for (int j = 0; j < FloorplanHouseDesigner.numTilesPerCol; j++)
                {
                    if (FloorplanHouseDesigner.floorLayout[i, j].groupID == roomGroupID && FloorplanHouseDesigner.floorLayout[i, j].obstacle != ObstacleType.Floor) // This tile is part of the room we just added
                    {
                        // If doorway can be placed here, mark the tile as a Success tile
                        if (!IsRoomCornerTile(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]) &&
                            !IsAgainstHouseBoundaryWall(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]) &&
                            !IsAdjacentToThreeOrMoreWallTiles(FloorplanHouseDesigner, FloorplanHouseDesigner.floorLayout[i, j]))
                        {
                            FloorplanHouseDesigner.floorLayout[i, j].obstacle = ObstacleType.Success;
                            doorwayNeeded = true; // This room needs a doorway
                        }
                        else // Doorway can't be placed here - mark it as an Error tile
                            FloorplanHouseDesigner.floorLayout[i, j].obstacle = ObstacleType.Error;
                    }
                }
            }

            return doorwayNeeded;
        }

        /// <summary>
        /// Edits the "designer mode" floorplan to mark chair/table tiles as "Success" or "Error" if they can/cannot be placed here
        /// </summary>
        /// <param name="selectedObstacle"> Chair or Table being added </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        /// <param name="widthInFeet"> Obstacle width in feet </param>
        /// <param name="heightInFeet"> Obstacle height in feet </param>
        public static void AttemptAddChairOrTableToFloorplan(ObstacleType selectedObstacle, int xTileIndex, int yTileIndex, int widthInFeet, int heightInFeet)
        {
            currentObstacleBeingAdded = selectedObstacle;
            int chairTableWidthInTiles = widthInFeet / 2;
            int chairTableHeightInTiles = heightInFeet / 2;
            successAddingObstacle = true; // Initially set to true, could get changed if obstacle is in invalid position

            // Check if chair/table can be placed at this location
            for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles; i++)
            {
                for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles; j++)
                {
                    // Check if tile is out of bounds or non-floor obstacle already present at this tile
                    if ((i >= FloorplanHouseDesigner.numTilesPerRow || j >= FloorplanHouseDesigner.numTilesPerCol) ||
                        FloorplanHouseDesigner.floorLayout[i, j].obstacle != ObstacleType.Floor || FloorplanHouseDesigner.floorLayout[i, j].groupID != -1)
                        successAddingObstacle = false;
                }
            }

            // If chair/table can't be placed here, mark the tiles that the chair/table is covering as error tiles
            if (!successAddingObstacle)
            {
                for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles && i < FloorplanHouseDesigner.numTilesPerRow; i++)
                {
                    for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles && j < FloorplanHouseDesigner.numTilesPerCol; j++)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, ObstacleType.Error);
                    }
                }
            }
            else // Chair/table can be placed here. Mark the associated tiles as success tiles
            {
                for (int i = xTileIndex; i < xTileIndex + chairTableWidthInTiles && i < FloorplanHouseDesigner.numTilesPerRow; i++)
                {
                    for (int j = yTileIndex; j < yTileIndex + chairTableHeightInTiles && j < FloorplanHouseDesigner.numTilesPerCol; j++)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, ObstacleType.Success);
                    }
                }
            }
        }

        /// <summary>
        /// Edits the "designer mode" floorplan to mark chest tile as "Success" or "Error" if it can/cannot be placed here
        /// </summary>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void AttemptAddChestToFloorplan(int xTileIndex, int yTileIndex)
        {
            currentObstacleBeingAdded = ObstacleType.Chest;
            successAddingObstacle = true; // Initially set to true, could get changed if obstacle is in invalid position

            // Check if chest can be placed at this location
            if ((xTileIndex >= FloorplanHouseDesigner.numTilesPerRow || yTileIndex >= FloorplanHouseDesigner.numTilesPerCol) ||
                FloorplanHouseDesigner.floorLayout[xTileIndex, yTileIndex].obstacle != ObstacleType.Floor || FloorplanHouseDesigner.floorLayout[xTileIndex, yTileIndex].groupID != -1)
                successAddingObstacle = false;

            // If chest can't be placed here, mark the tile that the chest is covering as an error tile
            if (!successAddingObstacle)
                FloorplanHouseDesigner.ModifyTileBasedOnIndices(xTileIndex, yTileIndex, ObstacleType.Error);
            else // Chest can be placed here. Mark the associated tile as a success tile
                FloorplanHouseDesigner.ModifyTileBasedOnIndices(xTileIndex, yTileIndex, ObstacleType.Success);
        }

        /// <summary>
        /// Removes a room from the floorplan.
        /// </summary>
        /// <param name="HouseLayout"> The floor plan layout </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void RemoveRoomFromFloorplan(FloorplanLayout HouseLayout, int xTileIndex, int yTileIndex)
        {
            if (IsBoundaryWallTile(HouseLayout, HouseLayout.floorLayout[xTileIndex, yTileIndex]))
                return;

            int roomGID = HouseLayout.floorLayout[xTileIndex, yTileIndex].groupID; // Get group ID of this room

            // Remove every tile with the same group ID as this room
            for (int i = 0; i < HouseLayout.numTilesPerRow; i++)
            {
                for (int j = 0; j < HouseLayout.numTilesPerCol; j++)
                {
                    if (HouseLayout.floorLayout[i, j].groupID == roomGID)
                    {
                        HouseLayout.ModifyTileBasedOnIndices(i, j, ObstacleType.Floor);
                        HouseLayout.floorLayout[i, j].groupID = -1;
                    }
                }
            }
        }

        /// <summary>
        /// Removes all tiles making up a chair/table from the floorplan
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void RemoveChairOrTableFromFloorplan(FloorplanLayout HouseLayout, int xTileIndex, int yTileIndex)
        {
            int[,] legIndices = HouseLayout.GetChairOrTableLegIndices(HouseLayout.floorLayout[xTileIndex, yTileIndex]);

            // Iterate through each affected tile and set them to floor tiles
            for (int i = legIndices[FloorplanLayout.UL, 0]; i <= legIndices[FloorplanLayout.UR, 0]; i++)
            {
                for (int j = legIndices[FloorplanLayout.UL, 1]; j <= legIndices[FloorplanLayout.LL, 1]; j++)
                {
                    HouseLayout.floorLayout[i, j].obstacle = ObstacleType.Floor;
                    HouseLayout.floorLayout[i, j].groupID = -1;
                }
            }
        }

        /// <summary>
        /// Removes the tile making up a chest from the floorplan
        /// </summary>
        /// <param name="HouseLayout"> The floorplan layout for the actual house </param>
        /// <param name="xTileIndex"> The selected column </param>
        /// <param name="yTileIndex"> The selected row </param>
        public static void RemoveChestFromFloorplan(FloorplanLayout HouseLayout, int xTileIndex, int yTileIndex)
        {
            // Set the tile to be a floor tile
            HouseLayout.floorLayout[xTileIndex, yTileIndex].obstacle = ObstacleType.Floor;
            HouseLayout.floorLayout[xTileIndex, yTileIndex].groupID = -1;
        }

        /// <summary>
        /// Changes every tile in the "design mode" house layout with a Success obstacle to contain the obstacle currently selected
        /// </summary>
        public static void ChangeSuccessTilesToCurrentObstacle()
        {
            if (currentObstacleBeingAdded == ObstacleType.Room)
                currentObstacleBeingAdded = ObstacleType.Wall; // So we know to create wall tiles

            for (int i = 0; i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                for (int j = 0; j < FloorplanHouseDesigner.numTilesPerCol; j++)
                {
                    if (FloorplanHouseDesigner.floorLayout[i, j].obstacle == ObstacleType.Success)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, currentObstacleBeingAdded);

                        if (!currentlyAddingDoorway)
                            FloorplanHouseDesigner.floorLayout[i, j].groupID = FloorplanFileWriter.currentObstacleGroupNumber; // Assign group ID
                    }
                }
            }

            if (!currentlyAddingDoorway)
                FloorplanFileWriter.currentObstacleGroupNumber++; // Obstacle was successfully placed, assign its corresponding tiles a group ID
        }

        /// <summary>
        /// /// Changes every tile in the "design mode" house layout with a Error obstacle to contain the obstacle currently selected
        /// </summary>
        public static void ChangeErrorTilesToCurrentObstacle()
        {
            if (currentObstacleBeingAdded == ObstacleType.Room)
                currentObstacleBeingAdded = ObstacleType.Wall; // So we know to create wall tiles

            for (int i = 0; i < FloorplanHouseDesigner.numTilesPerRow; i++)
            {
                for (int j = 0; j < FloorplanHouseDesigner.numTilesPerCol; j++)
                {
                    if (FloorplanHouseDesigner.floorLayout[i, j].obstacle == ObstacleType.Error)
                    {
                        FloorplanHouseDesigner.ModifyTileBasedOnIndices(i, j, currentObstacleBeingAdded);
                    }
                }
            }
        }

        private static bool IsBoundaryWallTile(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            return tile.obstacle == ObstacleType.Wall && tile.groupID == -1;
        }

        private static bool IsAgainstHouseBoundaryWall(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            return IsBoundaryWallTile(CurrentLayout, CurrentLayout.floorLayout[x - 1, y]) || IsBoundaryWallTile(CurrentLayout, CurrentLayout.floorLayout[x + 1, y]) || // Left and right
                   IsBoundaryWallTile(CurrentLayout, CurrentLayout.floorLayout[x, y - 1]) || IsBoundaryWallTile(CurrentLayout, CurrentLayout.floorLayout[x, y + 1]); // Above and below
        }

        private static bool IsAdjacentToThreeOrMoreWallTiles(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            int adjCount = 0;

            if (CurrentLayout.floorLayout[x - 1, y].obstacle == ObstacleType.Wall || CurrentLayout.floorLayout[x - 1, y].obstacle == ObstacleType.Error || CurrentLayout.floorLayout[x - 1, y].obstacle == ObstacleType.Success)
                adjCount++;
            if (CurrentLayout.floorLayout[x + 1, y].obstacle == ObstacleType.Wall || CurrentLayout.floorLayout[x + 1, y].obstacle == ObstacleType.Error || CurrentLayout.floorLayout[x + 1, y].obstacle == ObstacleType.Success)
                adjCount++;
            if (CurrentLayout.floorLayout[x, y - 1].obstacle == ObstacleType.Wall || CurrentLayout.floorLayout[x, y - 1].obstacle == ObstacleType.Error || CurrentLayout.floorLayout[x, y - 1].obstacle == ObstacleType.Success)
                adjCount++;
            if (CurrentLayout.floorLayout[x, y + 1].obstacle == ObstacleType.Wall || CurrentLayout.floorLayout[x, y + 1].obstacle == ObstacleType.Error || CurrentLayout.floorLayout[x, y + 1].obstacle == ObstacleType.Success)
                adjCount++;

            return adjCount >= 3;
        }

        private static bool IsRoomCornerTile(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            Tile leftTile = CurrentLayout.floorLayout[x - 1, y];
            Tile rightTile = CurrentLayout.floorLayout[x + 1, y];
            Tile belowTile = CurrentLayout.floorLayout[x, y + 1];
            Tile aboveTile = CurrentLayout.floorLayout[x, y - 1];

            return (leftTile.groupID != -1 && aboveTile.groupID != -1 && !IsDoorwayTile(leftTile) && !IsDoorwayTile(aboveTile)) || // Left and above
            (leftTile.groupID != -1 && belowTile.groupID != -1 && !IsDoorwayTile(leftTile) && !IsDoorwayTile(belowTile)) || // Left and below
            (rightTile.groupID != -1 && aboveTile.groupID != -1 && !IsDoorwayTile(rightTile) && !IsDoorwayTile(aboveTile)) || // Right and above
            (rightTile.groupID != -1 && belowTile.groupID != -1 && !IsDoorwayTile(rightTile) && !IsDoorwayTile(belowTile)); // Right and below
        }

        private static bool IsDoorwayTile(Tile tile)
        {
            return tile.obstacle == ObstacleType.Floor && tile.groupID != -1;
        }

        private static bool IsAdjacentToDoorwayTile(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            return IsDoorwayTile(CurrentLayout.floorLayout[x - 1, y]) || IsDoorwayTile(CurrentLayout.floorLayout[x + 1, y]) ||
                   IsDoorwayTile(CurrentLayout.floorLayout[x, y - 1]) || IsDoorwayTile(CurrentLayout.floorLayout[x, y + 1]);
        }

        private static int GetGroupIDOfConnectedDoorway(FloorplanLayout CurrentLayout, Tile tile)
        {
            int x = tile.x / FloorplanLayout.tileSideLength;
            int y = tile.y / FloorplanLayout.tileSideLength;

            if (IsDoorwayTile(CurrentLayout.floorLayout[x - 1, y]))
                return CurrentLayout.floorLayout[x - 1, y].groupID;
            else if (IsDoorwayTile(CurrentLayout.floorLayout[x + 1, y]))
                return CurrentLayout.floorLayout[x + 1, y].groupID;
            else if (IsDoorwayTile(CurrentLayout.floorLayout[x, y - 1]))
                return CurrentLayout.floorLayout[x, y - 1].groupID;
            else if (IsDoorwayTile(CurrentLayout.floorLayout[x, y + 1]))
                return CurrentLayout.floorLayout[x, y + 1].groupID;

            return -1;
        }
    }
}