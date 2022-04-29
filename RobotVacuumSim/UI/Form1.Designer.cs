using VacuumSim.Components;

namespace VacuumSim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LeftPane = new System.Windows.Forms.SplitContainer();
            this.CreateDoorwayInstructionsLabel = new System.Windows.Forms.Label();
            this.ObstaclesGroupBox = new System.Windows.Forms.GroupBox();
            this.ObstacleSelectorLabel = new System.Windows.Forms.Label();
            this.ObstacleSelector = new System.Windows.Forms.ComboBox();
            this.EraserModeButton = new System.Windows.Forms.Button();
            this.FinishOrEditFloorplanButton = new System.Windows.Forms.Button();
            this.ChairTableDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ChairTableHeightLabel = new System.Windows.Forms.Label();
            this.ChairTableWidthLabel = new System.Windows.Forms.Label();
            this.ChairTableHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.ChairTableWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.RoomDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.RoomWidthLabel = new System.Windows.Forms.Label();
            this.RoomHeightLabel = new System.Windows.Forms.Label();
            this.RoomWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.RoomHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.LoadSaveFloorplanGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveFloorplanButton = new System.Windows.Forms.Button();
            this.LoadDefaultFloorplanButton = new System.Windows.Forms.Button();
            this.LoadSavedFloorplanButton = new System.Windows.Forms.Button();
            this.HouseDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.HouseWidthLabel = new System.Windows.Forms.Label();
            this.HouseHeightLabel = new System.Windows.Forms.Label();
            this.HouseWidthSelector = new System.Windows.Forms.NumericUpDown();
            this.HouseHeightSelector = new System.Windows.Forms.NumericUpDown();
            this.FloorTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.FriezeCutPileRadioButton = new System.Windows.Forms.RadioButton();
            this.CutPileRadioButton = new System.Windows.Forms.RadioButton();
            this.LoopPileRadioButton = new System.Windows.Forms.RadioButton();
            this.HardWoodRadioButton = new System.Windows.Forms.RadioButton();
            this.FloorplanDesignLabel = new System.Windows.Forms.Label();
            this.ControlsPane = new System.Windows.Forms.SplitContainer();
            this.PlaceVacuumInstructionsLabel = new System.Windows.Forms.Label();
            this.InitialVacuumHeadingLabel = new System.Windows.Forms.Label();
            this.InitialVacuumHeadingSelector = new System.Windows.Forms.NumericUpDown();
            this.VacuumEfficiencyValueLabel = new System.Windows.Forms.Label();
            this.WhiskersEfficiencyTitleLabel = new System.Windows.Forms.Label();
            this.VacuumEfficiencyTitleLabel = new System.Windows.Forms.Label();
            this.WhiskersEfficiencySlider = new System.Windows.Forms.TrackBar();
            this.VacuumEfficiencySlider = new System.Windows.Forms.TrackBar();
            this.RunAllAlgorithmsCheckbox = new System.Windows.Forms.CheckBox();
            this.RobotPathAlgorithmLabel = new System.Windows.Forms.Label();
            this.RobotPathAlgorithmSelector = new System.Windows.Forms.ComboBox();
            this.RobotSpeedLabel = new System.Windows.Forms.Label();
            this.RobotSpeedSelector = new System.Windows.Forms.NumericUpDown();
            this.VacuumAttributesLabel = new System.Windows.Forms.Label();
            this.RobotBatteryLifeLabel = new System.Windows.Forms.Label();
            this.RobotBatteryLifeSelector = new System.Windows.Forms.NumericUpDown();
            this.WhiskersEfficiencyValueLabel = new System.Windows.Forms.Label();
            this.RunAnotherSimulationLabel = new System.Windows.Forms.Label();
            this.NoRunAnotherSimulationButton = new System.Windows.Forms.Button();
            this.YesRunAnotherSimulationButton = new System.Windows.Forms.Button();
            this.LoadSaveSimSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadSimulationButton = new System.Windows.Forms.Button();
            this.SimulationControlLabel = new System.Windows.Forms.Label();
            this.SimulationSpeedLabel = new System.Windows.Forms.Label();
            this.StartSimulationButton = new System.Windows.Forms.Button();
            this.SimulationSpeedSelector = new System.Windows.Forms.ComboBox();
            this.StopSimulationButton = new System.Windows.Forms.Button();
            this.ShowInstructionsButton = new System.Windows.Forms.Button();
            this.CenterSplitPane = new System.Windows.Forms.SplitContainer();
            this.CurrentAlgorithmLabel = new System.Windows.Forms.Label();
            this.SimTimeElapsedLabel = new System.Windows.Forms.Label();
            this.SimTimeElapsedTitleLabel = new System.Windows.Forms.Label();
            this.BatteryLeftLabel = new System.Windows.Forms.Label();
            this.BatteryLeftTitleLabel = new System.Windows.Forms.Label();
            this.FloorCanvas = new System.Windows.Forms.PictureBox();
            this.VacDisplayTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).BeginInit();
            this.LeftPane.Panel1.SuspendLayout();
            this.LeftPane.Panel2.SuspendLayout();
            this.LeftPane.SuspendLayout();
            this.ObstaclesGroupBox.SuspendLayout();
            this.ChairTableDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableHeightSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableWidthSelector)).BeginInit();
            this.RoomDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).BeginInit();
            this.LoadSaveFloorplanGroupBox.SuspendLayout();
            this.HouseDimensionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HouseWidthSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouseHeightSelector)).BeginInit();
            this.FloorTypeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsPane)).BeginInit();
            this.ControlsPane.Panel1.SuspendLayout();
            this.ControlsPane.Panel2.SuspendLayout();
            this.ControlsPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InitialVacuumHeadingSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiskersEfficiencySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VacuumEfficiencySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotSpeedSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotBatteryLifeSelector)).BeginInit();
            this.LoadSaveSimSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).BeginInit();
            this.CenterSplitPane.Panel1.SuspendLayout();
            this.CenterSplitPane.Panel2.SuspendLayout();
            this.CenterSplitPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPane
            // 
            this.LeftPane.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.LeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPane.IsSplitterFixed = true;
            this.LeftPane.Location = new System.Drawing.Point(0, 0);
            this.LeftPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftPane.Name = "LeftPane";
            // 
            // LeftPane.Panel1
            // 
            this.LeftPane.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.LeftPane.Panel1.Controls.Add(this.CreateDoorwayInstructionsLabel);
            this.LeftPane.Panel1.Controls.Add(this.ObstaclesGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.FinishOrEditFloorplanButton);
            this.LeftPane.Panel1.Controls.Add(this.ChairTableDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.RoomDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.LoadSaveFloorplanGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.HouseDimensionsGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.FloorTypeGroupBox);
            this.LeftPane.Panel1.Controls.Add(this.FloorplanDesignLabel);
            this.LeftPane.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LeftPane.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // LeftPane.Panel2
            // 
            this.LeftPane.Panel2.Controls.Add(this.ControlsPane);
            this.LeftPane.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LeftPane.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftPane.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LeftPane.Size = new System.Drawing.Size(950, 809);
            this.LeftPane.SplitterDistance = 467;
            this.LeftPane.TabIndex = 1;
            // 
            // CreateDoorwayInstructionsLabel
            // 
            this.CreateDoorwayInstructionsLabel.AutoSize = true;
            this.CreateDoorwayInstructionsLabel.Font = new System.Drawing.Font("Elephant", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateDoorwayInstructionsLabel.ForeColor = System.Drawing.Color.Navy;
            this.CreateDoorwayInstructionsLabel.Location = new System.Drawing.Point(41, 659);
            this.CreateDoorwayInstructionsLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.CreateDoorwayInstructionsLabel.Name = "CreateDoorwayInstructionsLabel";
            this.CreateDoorwayInstructionsLabel.Size = new System.Drawing.Size(387, 36);
            this.CreateDoorwayInstructionsLabel.TabIndex = 22;
            this.CreateDoorwayInstructionsLabel.Text = "Click on one of the green tiles to create the doorway to the room you just placed" +
    ".";
            this.CreateDoorwayInstructionsLabel.Visible = false;
            // 
            // ObstaclesGroupBox
            // 
            this.ObstaclesGroupBox.Controls.Add(this.ObstacleSelectorLabel);
            this.ObstaclesGroupBox.Controls.Add(this.ObstacleSelector);
            this.ObstaclesGroupBox.Controls.Add(this.EraserModeButton);
            this.ObstaclesGroupBox.Location = new System.Drawing.Point(270, 172);
            this.ObstaclesGroupBox.Name = "ObstaclesGroupBox";
            this.ObstaclesGroupBox.Size = new System.Drawing.Size(184, 125);
            this.ObstaclesGroupBox.TabIndex = 18;
            this.ObstaclesGroupBox.TabStop = false;
            this.ObstaclesGroupBox.Text = "Obstacles";
            // 
            // ObstacleSelectorLabel
            // 
            this.ObstacleSelectorLabel.Location = new System.Drawing.Point(6, 27);
            this.ObstacleSelectorLabel.Name = "ObstacleSelectorLabel";
            this.ObstacleSelectorLabel.Size = new System.Drawing.Size(108, 19);
            this.ObstacleSelectorLabel.TabIndex = 14;
            this.ObstacleSelectorLabel.Text = "Selected Obstacle";
            // 
            // ObstacleSelector
            // 
            this.ObstacleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObstacleSelector.FormattingEnabled = true;
            this.ObstacleSelector.Items.AddRange(new object[] {
            "Room",
            "Chair",
            "Table",
            "Chest"});
            this.ObstacleSelector.Location = new System.Drawing.Point(6, 48);
            this.ObstacleSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ObstacleSelector.Name = "ObstacleSelector";
            this.ObstacleSelector.Size = new System.Drawing.Size(112, 23);
            this.ObstacleSelector.TabIndex = 11;
            this.ObstacleSelector.SelectedIndexChanged += new System.EventHandler(this.ObstacleSelector_SelectedIndexChanged);
            // 
            // EraserModeButton
            // 
            this.EraserModeButton.Location = new System.Drawing.Point(51, 94);
            this.EraserModeButton.Name = "EraserModeButton";
            this.EraserModeButton.Size = new System.Drawing.Size(127, 25);
            this.EraserModeButton.TabIndex = 15;
            this.EraserModeButton.Text = "Eraser Mode: OFF";
            this.EraserModeButton.UseVisualStyleBackColor = true;
            this.EraserModeButton.Click += new System.EventHandler(this.EraserModeButton_Click);
            // 
            // FinishOrEditFloorplanButton
            // 
            this.FinishOrEditFloorplanButton.Location = new System.Drawing.Point(346, 414);
            this.FinishOrEditFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FinishOrEditFloorplanButton.Name = "FinishOrEditFloorplanButton";
            this.FinishOrEditFloorplanButton.Size = new System.Drawing.Size(108, 22);
            this.FinishOrEditFloorplanButton.TabIndex = 17;
            this.FinishOrEditFloorplanButton.Text = "Finish Floor Plan";
            this.FinishOrEditFloorplanButton.UseVisualStyleBackColor = true;
            this.FinishOrEditFloorplanButton.Click += new System.EventHandler(this.FinishOrEditFloorplanButton_Click);
            // 
            // ChairTableDimensionsGroupBox
            // 
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableHeightLabel);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableWidthLabel);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableHeightSelector);
            this.ChairTableDimensionsGroupBox.Controls.Add(this.ChairTableWidthSelector);
            this.ChairTableDimensionsGroupBox.Location = new System.Drawing.Point(276, 305);
            this.ChairTableDimensionsGroupBox.Name = "ChairTableDimensionsGroupBox";
            this.ChairTableDimensionsGroupBox.Size = new System.Drawing.Size(178, 100);
            this.ChairTableDimensionsGroupBox.TabIndex = 15;
            this.ChairTableDimensionsGroupBox.TabStop = false;
            this.ChairTableDimensionsGroupBox.Text = "Chair/Table Dimensions";
            // 
            // ChairTableHeightLabel
            // 
            this.ChairTableHeightLabel.AutoSize = true;
            this.ChairTableHeightLabel.Location = new System.Drawing.Point(97, 29);
            this.ChairTableHeightLabel.Name = "ChairTableHeightLabel";
            this.ChairTableHeightLabel.Size = new System.Drawing.Size(62, 15);
            this.ChairTableHeightLabel.TabIndex = 3;
            this.ChairTableHeightLabel.Text = "Height (ft)";
            // 
            // ChairTableWidthLabel
            // 
            this.ChairTableWidthLabel.AutoSize = true;
            this.ChairTableWidthLabel.Location = new System.Drawing.Point(15, 29);
            this.ChairTableWidthLabel.Name = "ChairTableWidthLabel";
            this.ChairTableWidthLabel.Size = new System.Drawing.Size(58, 15);
            this.ChairTableWidthLabel.TabIndex = 2;
            this.ChairTableWidthLabel.Text = "Width (ft)";
            // 
            // ChairTableHeightSelector
            // 
            this.ChairTableHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Location = new System.Drawing.Point(97, 47);
            this.ChairTableHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.Name = "ChairTableHeightSelector";
            this.ChairTableHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.ChairTableHeightSelector.TabIndex = 1;
            this.ChairTableHeightSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableHeightSelector.ValueChanged += new System.EventHandler(this.ChairTableHeightSelector_ValueChanged);
            // 
            // ChairTableWidthSelector
            // 
            this.ChairTableWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.Location = new System.Drawing.Point(13, 47);
            this.ChairTableWidthSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.Name = "ChairTableWidthSelector";
            this.ChairTableWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.ChairTableWidthSelector.TabIndex = 0;
            this.ChairTableWidthSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ChairTableWidthSelector.ValueChanged += new System.EventHandler(this.ChairTableWidthSelector_ValueChanged);
            // 
            // RoomDimensionsGroupBox
            // 
            this.RoomDimensionsGroupBox.AutoSize = true;
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomWidthLabel);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomHeightLabel);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomWidthSelector);
            this.RoomDimensionsGroupBox.Controls.Add(this.RoomHeightSelector);
            this.RoomDimensionsGroupBox.Location = new System.Drawing.Point(6, 305);
            this.RoomDimensionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDimensionsGroupBox.Name = "RoomDimensionsGroupBox";
            this.RoomDimensionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDimensionsGroupBox.Size = new System.Drawing.Size(174, 100);
            this.RoomDimensionsGroupBox.TabIndex = 12;
            this.RoomDimensionsGroupBox.TabStop = false;
            this.RoomDimensionsGroupBox.Text = "Room Dimensions";
            // 
            // RoomWidthLabel
            // 
            this.RoomWidthLabel.Location = new System.Drawing.Point(7, 29);
            this.RoomWidthLabel.Name = "RoomWidthLabel";
            this.RoomWidthLabel.Size = new System.Drawing.Size(64, 15);
            this.RoomWidthLabel.TabIndex = 9;
            this.RoomWidthLabel.Text = "Width (ft)";
            // 
            // RoomHeightLabel
            // 
            this.RoomHeightLabel.Location = new System.Drawing.Point(90, 29);
            this.RoomHeightLabel.Name = "RoomHeightLabel";
            this.RoomHeightLabel.Size = new System.Drawing.Size(68, 15);
            this.RoomHeightLabel.TabIndex = 10;
            this.RoomHeightLabel.Text = "Height (ft)";
            // 
            // RoomWidthSelector
            // 
            this.RoomWidthSelector.BackColor = System.Drawing.SystemColors.Window;
            this.RoomWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.Location = new System.Drawing.Point(6, 50);
            this.RoomWidthSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RoomWidthSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.Name = "RoomWidthSelector";
            this.RoomWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.RoomWidthSelector.TabIndex = 7;
            this.RoomWidthSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomWidthSelector.ValueChanged += new System.EventHandler(this.RoomWidthSelector_ValueChanged);
            // 
            // RoomHeightSelector
            // 
            this.RoomHeightSelector.BackColor = System.Drawing.SystemColors.Window;
            this.RoomHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.Location = new System.Drawing.Point(90, 50);
            this.RoomHeightSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.RoomHeightSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.Name = "RoomHeightSelector";
            this.RoomHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.RoomHeightSelector.TabIndex = 8;
            this.RoomHeightSelector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.RoomHeightSelector.ValueChanged += new System.EventHandler(this.RoomHeightSelector_ValueChanged);
            // 
            // LoadSaveFloorplanGroupBox
            // 
            this.LoadSaveFloorplanGroupBox.AutoSize = true;
            this.LoadSaveFloorplanGroupBox.Controls.Add(this.SaveFloorplanButton);
            this.LoadSaveFloorplanGroupBox.Controls.Add(this.LoadDefaultFloorplanButton);
            this.LoadSaveFloorplanGroupBox.Controls.Add(this.LoadSavedFloorplanButton);
            this.LoadSaveFloorplanGroupBox.Location = new System.Drawing.Point(4, 722);
            this.LoadSaveFloorplanGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSaveFloorplanGroupBox.Name = "LoadSaveFloorplanGroupBox";
            this.LoadSaveFloorplanGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSaveFloorplanGroupBox.Size = new System.Drawing.Size(465, 103);
            this.LoadSaveFloorplanGroupBox.TabIndex = 13;
            this.LoadSaveFloorplanGroupBox.TabStop = false;
            this.LoadSaveFloorplanGroupBox.Text = "Load/Save";
            // 
            // SaveFloorplanButton
            // 
            this.SaveFloorplanButton.Location = new System.Drawing.Point(342, 61);
            this.SaveFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveFloorplanButton.Name = "SaveFloorplanButton";
            this.SaveFloorplanButton.Size = new System.Drawing.Size(108, 22);
            this.SaveFloorplanButton.TabIndex = 13;
            this.SaveFloorplanButton.Text = "Save Floor Plan";
            this.SaveFloorplanButton.UseVisualStyleBackColor = true;
            this.SaveFloorplanButton.Click += new System.EventHandler(this.SaveFloorplanButton_Click);
            // 
            // LoadDefaultFloorplanButton
            // 
            this.LoadDefaultFloorplanButton.Location = new System.Drawing.Point(9, 31);
            this.LoadDefaultFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadDefaultFloorplanButton.Name = "LoadDefaultFloorplanButton";
            this.LoadDefaultFloorplanButton.Size = new System.Drawing.Size(152, 22);
            this.LoadDefaultFloorplanButton.TabIndex = 12;
            this.LoadDefaultFloorplanButton.Text = "Load Default Floor Plan";
            this.LoadDefaultFloorplanButton.UseVisualStyleBackColor = true;
            this.LoadDefaultFloorplanButton.Click += new System.EventHandler(this.LoadDefaultFloorplanButton_Click);
            // 
            // LoadSavedFloorplanButton
            // 
            this.LoadSavedFloorplanButton.Location = new System.Drawing.Point(9, 57);
            this.LoadSavedFloorplanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSavedFloorplanButton.Name = "LoadSavedFloorplanButton";
            this.LoadSavedFloorplanButton.Size = new System.Drawing.Size(152, 22);
            this.LoadSavedFloorplanButton.TabIndex = 16;
            this.LoadSavedFloorplanButton.Text = "Load Saved Floor Plan";
            this.LoadSavedFloorplanButton.UseVisualStyleBackColor = true;
            this.LoadSavedFloorplanButton.Click += new System.EventHandler(this.LoadSavedFloorplanButton_Click);
            // 
            // HouseDimensionsGroupBox
            // 
            this.HouseDimensionsGroupBox.AutoSize = true;
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseWidthLabel);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseHeightLabel);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseWidthSelector);
            this.HouseDimensionsGroupBox.Controls.Add(this.HouseHeightSelector);
            this.HouseDimensionsGroupBox.Location = new System.Drawing.Point(7, 172);
            this.HouseDimensionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseDimensionsGroupBox.Name = "HouseDimensionsGroupBox";
            this.HouseDimensionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseDimensionsGroupBox.Size = new System.Drawing.Size(181, 125);
            this.HouseDimensionsGroupBox.TabIndex = 11;
            this.HouseDimensionsGroupBox.TabStop = false;
            this.HouseDimensionsGroupBox.Text = "House Dimensions";
            // 
            // HouseWidthLabel
            // 
            this.HouseWidthLabel.Location = new System.Drawing.Point(6, 27);
            this.HouseWidthLabel.Name = "HouseWidthLabel";
            this.HouseWidthLabel.Size = new System.Drawing.Size(64, 15);
            this.HouseWidthLabel.TabIndex = 9;
            this.HouseWidthLabel.Text = "Width (ft)";
            // 
            // HouseHeightLabel
            // 
            this.HouseHeightLabel.Location = new System.Drawing.Point(89, 27);
            this.HouseHeightLabel.Name = "HouseHeightLabel";
            this.HouseHeightLabel.Size = new System.Drawing.Size(68, 15);
            this.HouseHeightLabel.TabIndex = 10;
            this.HouseHeightLabel.Text = "Height (ft)";
            // 
            // HouseWidthSelector
            // 
            this.HouseWidthSelector.BackColor = System.Drawing.SystemColors.Window;
            this.HouseWidthSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HouseWidthSelector.Location = new System.Drawing.Point(6, 50);
            this.HouseWidthSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.HouseWidthSelector.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.HouseWidthSelector.Name = "HouseWidthSelector";
            this.HouseWidthSelector.Size = new System.Drawing.Size(65, 23);
            this.HouseWidthSelector.TabIndex = 7;
            this.HouseWidthSelector.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.HouseWidthSelector.ValueChanged += new System.EventHandler(this.HouseWidthSelector_ValueChanged);
            // 
            // HouseHeightSelector
            // 
            this.HouseHeightSelector.BackColor = System.Drawing.SystemColors.Window;
            this.HouseHeightSelector.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HouseHeightSelector.Location = new System.Drawing.Point(89, 50);
            this.HouseHeightSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HouseHeightSelector.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.HouseHeightSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HouseHeightSelector.Name = "HouseHeightSelector";
            this.HouseHeightSelector.Size = new System.Drawing.Size(65, 23);
            this.HouseHeightSelector.TabIndex = 8;
            this.HouseHeightSelector.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.HouseHeightSelector.ValueChanged += new System.EventHandler(this.HouseHeightSelector_ValueChanged);
            // 
            // FloorTypeGroupBox
            // 
            this.FloorTypeGroupBox.AutoSize = true;
            this.FloorTypeGroupBox.Controls.Add(this.FriezeCutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.CutPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.LoopPileRadioButton);
            this.FloorTypeGroupBox.Controls.Add(this.HardWoodRadioButton);
            this.FloorTypeGroupBox.Location = new System.Drawing.Point(6, 42);
            this.FloorTypeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FloorTypeGroupBox.Name = "FloorTypeGroupBox";
            this.FloorTypeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FloorTypeGroupBox.Size = new System.Drawing.Size(187, 127);
            this.FloorTypeGroupBox.TabIndex = 6;
            this.FloorTypeGroupBox.TabStop = false;
            this.FloorTypeGroupBox.Text = "Floor Types";
            // 
            // FriezeCutPileRadioButton
            // 
            this.FriezeCutPileRadioButton.AutoSize = true;
            this.FriezeCutPileRadioButton.Location = new System.Drawing.Point(6, 88);
            this.FriezeCutPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FriezeCutPileRadioButton.Name = "FriezeCutPileRadioButton";
            this.FriezeCutPileRadioButton.Size = new System.Drawing.Size(101, 19);
            this.FriezeCutPileRadioButton.TabIndex = 3;
            this.FriezeCutPileRadioButton.Text = "Frieze-Cut Pile";
            this.FriezeCutPileRadioButton.UseVisualStyleBackColor = true;
            this.FriezeCutPileRadioButton.CheckedChanged += new System.EventHandler(this.FloorTypeControlChanged);
            // 
            // CutPileRadioButton
            // 
            this.CutPileRadioButton.AutoSize = true;
            this.CutPileRadioButton.Location = new System.Drawing.Point(5, 65);
            this.CutPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CutPileRadioButton.Name = "CutPileRadioButton";
            this.CutPileRadioButton.Size = new System.Drawing.Size(66, 19);
            this.CutPileRadioButton.TabIndex = 2;
            this.CutPileRadioButton.Text = "Cut Pile";
            this.CutPileRadioButton.UseVisualStyleBackColor = true;
            this.CutPileRadioButton.CheckedChanged += new System.EventHandler(this.FloorTypeControlChanged);
            // 
            // LoopPileRadioButton
            // 
            this.LoopPileRadioButton.AutoSize = true;
            this.LoopPileRadioButton.Location = new System.Drawing.Point(6, 43);
            this.LoopPileRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoopPileRadioButton.Name = "LoopPileRadioButton";
            this.LoopPileRadioButton.Size = new System.Drawing.Size(74, 19);
            this.LoopPileRadioButton.TabIndex = 1;
            this.LoopPileRadioButton.Text = "Loop Pile";
            this.LoopPileRadioButton.UseVisualStyleBackColor = true;
            this.LoopPileRadioButton.CheckedChanged += new System.EventHandler(this.FloorTypeControlChanged);
            // 
            // HardWoodRadioButton
            // 
            this.HardWoodRadioButton.AutoSize = true;
            this.HardWoodRadioButton.Checked = true;
            this.HardWoodRadioButton.Location = new System.Drawing.Point(6, 20);
            this.HardWoodRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardWoodRadioButton.Name = "HardWoodRadioButton";
            this.HardWoodRadioButton.Size = new System.Drawing.Size(86, 19);
            this.HardWoodRadioButton.TabIndex = 0;
            this.HardWoodRadioButton.TabStop = true;
            this.HardWoodRadioButton.Text = "Hard Wood";
            this.HardWoodRadioButton.UseVisualStyleBackColor = true;
            this.HardWoodRadioButton.CheckedChanged += new System.EventHandler(this.FloorTypeControlChanged);
            // 
            // FloorplanDesignLabel
            // 
            this.FloorplanDesignLabel.BackColor = System.Drawing.Color.Transparent;
            this.FloorplanDesignLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FloorplanDesignLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.FloorplanDesignLabel.Location = new System.Drawing.Point(0, 0);
            this.FloorplanDesignLabel.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.FloorplanDesignLabel.Name = "FloorplanDesignLabel";
            this.FloorplanDesignLabel.Size = new System.Drawing.Size(467, 24);
            this.FloorplanDesignLabel.TabIndex = 5;
            this.FloorplanDesignLabel.Text = "Floor Plan Design";
            this.FloorplanDesignLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ControlsPane
            // 
            this.ControlsPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlsPane.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.ControlsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsPane.IsSplitterFixed = true;
            this.ControlsPane.Location = new System.Drawing.Point(0, 0);
            this.ControlsPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ControlsPane.Name = "ControlsPane";
            this.ControlsPane.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ControlsPane.Panel1
            // 
            this.ControlsPane.Panel1.Controls.Add(this.PlaceVacuumInstructionsLabel);
            this.ControlsPane.Panel1.Controls.Add(this.InitialVacuumHeadingLabel);
            this.ControlsPane.Panel1.Controls.Add(this.InitialVacuumHeadingSelector);
            this.ControlsPane.Panel1.Controls.Add(this.VacuumEfficiencyValueLabel);
            this.ControlsPane.Panel1.Controls.Add(this.WhiskersEfficiencyTitleLabel);
            this.ControlsPane.Panel1.Controls.Add(this.VacuumEfficiencyTitleLabel);
            this.ControlsPane.Panel1.Controls.Add(this.WhiskersEfficiencySlider);
            this.ControlsPane.Panel1.Controls.Add(this.VacuumEfficiencySlider);
            this.ControlsPane.Panel1.Controls.Add(this.RunAllAlgorithmsCheckbox);
            this.ControlsPane.Panel1.Controls.Add(this.RobotPathAlgorithmLabel);
            this.ControlsPane.Panel1.Controls.Add(this.RobotPathAlgorithmSelector);
            this.ControlsPane.Panel1.Controls.Add(this.RobotSpeedLabel);
            this.ControlsPane.Panel1.Controls.Add(this.RobotSpeedSelector);
            this.ControlsPane.Panel1.Controls.Add(this.VacuumAttributesLabel);
            this.ControlsPane.Panel1.Controls.Add(this.RobotBatteryLifeLabel);
            this.ControlsPane.Panel1.Controls.Add(this.RobotBatteryLifeSelector);
            this.ControlsPane.Panel1.Controls.Add(this.WhiskersEfficiencyValueLabel);
            this.ControlsPane.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ControlsPane.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ControlsPane.Panel2
            // 
            this.ControlsPane.Panel2.Controls.Add(this.RunAnotherSimulationLabel);
            this.ControlsPane.Panel2.Controls.Add(this.NoRunAnotherSimulationButton);
            this.ControlsPane.Panel2.Controls.Add(this.YesRunAnotherSimulationButton);
            this.ControlsPane.Panel2.Controls.Add(this.LoadSaveSimSettingsGroupBox);
            this.ControlsPane.Panel2.Controls.Add(this.SimulationControlLabel);
            this.ControlsPane.Panel2.Controls.Add(this.SimulationSpeedLabel);
            this.ControlsPane.Panel2.Controls.Add(this.StartSimulationButton);
            this.ControlsPane.Panel2.Controls.Add(this.SimulationSpeedSelector);
            this.ControlsPane.Panel2.Controls.Add(this.StopSimulationButton);
            this.ControlsPane.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ControlsPane.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ControlsPane.Size = new System.Drawing.Size(479, 809);
            this.ControlsPane.SplitterDistance = 498;
            this.ControlsPane.SplitterWidth = 3;
            this.ControlsPane.TabIndex = 0;
            // 
            // PlaceVacuumInstructionsLabel
            // 
            this.PlaceVacuumInstructionsLabel.AutoSize = true;
            this.PlaceVacuumInstructionsLabel.Font = new System.Drawing.Font("Elephant", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlaceVacuumInstructionsLabel.ForeColor = System.Drawing.Color.Navy;
            this.PlaceVacuumInstructionsLabel.Location = new System.Drawing.Point(40, 432);
            this.PlaceVacuumInstructionsLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.PlaceVacuumInstructionsLabel.Name = "PlaceVacuumInstructionsLabel";
            this.PlaceVacuumInstructionsLabel.Size = new System.Drawing.Size(380, 54);
            this.PlaceVacuumInstructionsLabel.TabIndex = 21;
            this.PlaceVacuumInstructionsLabel.Text = "Click and drag on the floor plan to place the vacuum. Once the vacuum is successf" +
    "ully placed, you can start the simulation.";
            this.PlaceVacuumInstructionsLabel.Visible = false;
            // 
            // InitialVacuumHeadingLabel
            // 
            this.InitialVacuumHeadingLabel.AutoSize = true;
            this.InitialVacuumHeadingLabel.Enabled = false;
            this.InitialVacuumHeadingLabel.Location = new System.Drawing.Point(313, 171);
            this.InitialVacuumHeadingLabel.Name = "InitialVacuumHeadingLabel";
            this.InitialVacuumHeadingLabel.Size = new System.Drawing.Size(137, 15);
            this.InitialVacuumHeadingLabel.TabIndex = 20;
            this.InitialVacuumHeadingLabel.Text = "Initial Heading (Degrees)";
            // 
            // InitialVacuumHeadingSelector
            // 
            this.InitialVacuumHeadingSelector.Enabled = false;
            this.InitialVacuumHeadingSelector.Location = new System.Drawing.Point(315, 189);
            this.InitialVacuumHeadingSelector.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.InitialVacuumHeadingSelector.Name = "InitialVacuumHeadingSelector";
            this.InitialVacuumHeadingSelector.Size = new System.Drawing.Size(120, 23);
            this.InitialVacuumHeadingSelector.TabIndex = 19;
            this.InitialVacuumHeadingSelector.ValueChanged += new System.EventHandler(this.InitialVacuumHeadingSelector_ValueChanged);
            // 
            // VacuumEfficiencyValueLabel
            // 
            this.VacuumEfficiencyValueLabel.AutoSize = true;
            this.VacuumEfficiencyValueLabel.Enabled = false;
            this.VacuumEfficiencyValueLabel.Location = new System.Drawing.Point(102, 72);
            this.VacuumEfficiencyValueLabel.Name = "VacuumEfficiencyValueLabel";
            this.VacuumEfficiencyValueLabel.Size = new System.Drawing.Size(29, 15);
            this.VacuumEfficiencyValueLabel.TabIndex = 17;
            this.VacuumEfficiencyValueLabel.Text = "90%";
            // 
            // WhiskersEfficiencyTitleLabel
            // 
            this.WhiskersEfficiencyTitleLabel.AutoSize = true;
            this.WhiskersEfficiencyTitleLabel.Enabled = false;
            this.WhiskersEfficiencyTitleLabel.Location = new System.Drawing.Point(7, 105);
            this.WhiskersEfficiencyTitleLabel.Name = "WhiskersEfficiencyTitleLabel";
            this.WhiskersEfficiencyTitleLabel.Size = new System.Drawing.Size(108, 15);
            this.WhiskersEfficiencyTitleLabel.TabIndex = 16;
            this.WhiskersEfficiencyTitleLabel.Text = "Whiskers Efficiency";
            // 
            // VacuumEfficiencyTitleLabel
            // 
            this.VacuumEfficiencyTitleLabel.AutoSize = true;
            this.VacuumEfficiencyTitleLabel.Enabled = false;
            this.VacuumEfficiencyTitleLabel.Location = new System.Drawing.Point(7, 43);
            this.VacuumEfficiencyTitleLabel.Name = "VacuumEfficiencyTitleLabel";
            this.VacuumEfficiencyTitleLabel.Size = new System.Drawing.Size(104, 15);
            this.VacuumEfficiencyTitleLabel.TabIndex = 15;
            this.VacuumEfficiencyTitleLabel.Text = "Vacuum Efficiency";
            // 
            // WhiskersEfficiencySlider
            // 
            this.WhiskersEfficiencySlider.Enabled = false;
            this.WhiskersEfficiencySlider.Location = new System.Drawing.Point(2, 123);
            this.WhiskersEfficiencySlider.Maximum = 50;
            this.WhiskersEfficiencySlider.Minimum = 10;
            this.WhiskersEfficiencySlider.Name = "WhiskersEfficiencySlider";
            this.WhiskersEfficiencySlider.Size = new System.Drawing.Size(104, 45);
            this.WhiskersEfficiencySlider.TabIndex = 14;
            this.WhiskersEfficiencySlider.Value = 30;
            this.WhiskersEfficiencySlider.Scroll += new System.EventHandler(this.WhiskerEfficiencySlider_Scroll);
            // 
            // VacuumEfficiencySlider
            // 
            this.VacuumEfficiencySlider.Enabled = false;
            this.VacuumEfficiencySlider.Location = new System.Drawing.Point(1, 61);
            this.VacuumEfficiencySlider.Maximum = 90;
            this.VacuumEfficiencySlider.Minimum = 10;
            this.VacuumEfficiencySlider.Name = "VacuumEfficiencySlider";
            this.VacuumEfficiencySlider.Size = new System.Drawing.Size(104, 45);
            this.VacuumEfficiencySlider.TabIndex = 13;
            this.VacuumEfficiencySlider.Value = 90;
            this.VacuumEfficiencySlider.Scroll += new System.EventHandler(this.VacuumEfficiencySlider_Scroll);
            // 
            // RunAllAlgorithmsCheckbox
            // 
            this.RunAllAlgorithmsCheckbox.AutoSize = true;
            this.RunAllAlgorithmsCheckbox.Checked = true;
            this.RunAllAlgorithmsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunAllAlgorithmsCheckbox.Enabled = false;
            this.RunAllAlgorithmsCheckbox.Location = new System.Drawing.Point(5, 214);
            this.RunAllAlgorithmsCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunAllAlgorithmsCheckbox.Name = "RunAllAlgorithmsCheckbox";
            this.RunAllAlgorithmsCheckbox.Size = new System.Drawing.Size(122, 19);
            this.RunAllAlgorithmsCheckbox.TabIndex = 12;
            this.RunAllAlgorithmsCheckbox.Text = "Run all algorithms";
            this.RunAllAlgorithmsCheckbox.UseVisualStyleBackColor = true;
            this.RunAllAlgorithmsCheckbox.CheckedChanged += new System.EventHandler(this.RunAllAlgorithmsCheckbox_CheckedChanged);
            // 
            // RobotPathAlgorithmLabel
            // 
            this.RobotPathAlgorithmLabel.AutoSize = true;
            this.RobotPathAlgorithmLabel.Enabled = false;
            this.RobotPathAlgorithmLabel.Location = new System.Drawing.Point(7, 171);
            this.RobotPathAlgorithmLabel.Name = "RobotPathAlgorithmLabel";
            this.RobotPathAlgorithmLabel.Size = new System.Drawing.Size(105, 15);
            this.RobotPathAlgorithmLabel.TabIndex = 11;
            this.RobotPathAlgorithmLabel.Text = "Pathing Algorithm";
            // 
            // RobotPathAlgorithmSelector
            // 
            this.RobotPathAlgorithmSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RobotPathAlgorithmSelector.Enabled = false;
            this.RobotPathAlgorithmSelector.FormattingEnabled = true;
            this.RobotPathAlgorithmSelector.Location = new System.Drawing.Point(5, 188);
            this.RobotPathAlgorithmSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RobotPathAlgorithmSelector.Name = "RobotPathAlgorithmSelector";
            this.RobotPathAlgorithmSelector.Size = new System.Drawing.Size(133, 23);
            this.RobotPathAlgorithmSelector.TabIndex = 10;
            this.RobotPathAlgorithmSelector.SelectedIndexChanged += new System.EventHandler(this.RobotPathAlgorithmSelector_SelectedIndexChanged);
            // 
            // RobotSpeedLabel
            // 
            this.RobotSpeedLabel.AutoSize = true;
            this.RobotSpeedLabel.Enabled = false;
            this.RobotSpeedLabel.Location = new System.Drawing.Point(313, 93);
            this.RobotSpeedLabel.Name = "RobotSpeedLabel";
            this.RobotSpeedLabel.Size = new System.Drawing.Size(143, 15);
            this.RobotSpeedLabel.TabIndex = 9;
            this.RobotSpeedLabel.Text = "Movement Speed (in/sec)";
            // 
            // RobotSpeedSelector
            // 
            this.RobotSpeedSelector.Enabled = false;
            this.RobotSpeedSelector.Location = new System.Drawing.Point(315, 116);
            this.RobotSpeedSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RobotSpeedSelector.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.RobotSpeedSelector.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.RobotSpeedSelector.Name = "RobotSpeedSelector";
            this.RobotSpeedSelector.Size = new System.Drawing.Size(65, 23);
            this.RobotSpeedSelector.TabIndex = 8;
            this.RobotSpeedSelector.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.RobotSpeedSelector.ValueChanged += new System.EventHandler(this.RobotSpeedSelector_ValueChanged);
            // 
            // VacuumAttributesLabel
            // 
            this.VacuumAttributesLabel.BackColor = System.Drawing.Color.Transparent;
            this.VacuumAttributesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VacuumAttributesLabel.Enabled = false;
            this.VacuumAttributesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.VacuumAttributesLabel.Location = new System.Drawing.Point(0, 0);
            this.VacuumAttributesLabel.Margin = new System.Windows.Forms.Padding(4);
            this.VacuumAttributesLabel.Name = "VacuumAttributesLabel";
            this.VacuumAttributesLabel.Size = new System.Drawing.Size(477, 23);
            this.VacuumAttributesLabel.TabIndex = 6;
            this.VacuumAttributesLabel.Text = "Vacuum Attributes";
            this.VacuumAttributesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RobotBatteryLifeLabel
            // 
            this.RobotBatteryLifeLabel.AutoSize = true;
            this.RobotBatteryLifeLabel.Enabled = false;
            this.RobotBatteryLifeLabel.Location = new System.Drawing.Point(313, 43);
            this.RobotBatteryLifeLabel.Name = "RobotBatteryLifeLabel";
            this.RobotBatteryLifeLabel.Size = new System.Drawing.Size(98, 15);
            this.RobotBatteryLifeLabel.TabIndex = 7;
            this.RobotBatteryLifeLabel.Text = "Battery Life (min)";
            // 
            // RobotBatteryLifeSelector
            // 
            this.RobotBatteryLifeSelector.Enabled = false;
            this.RobotBatteryLifeSelector.Location = new System.Drawing.Point(315, 66);
            this.RobotBatteryLifeSelector.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.RobotBatteryLifeSelector.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.Name = "RobotBatteryLifeSelector";
            this.RobotBatteryLifeSelector.Size = new System.Drawing.Size(65, 23);
            this.RobotBatteryLifeSelector.TabIndex = 6;
            this.RobotBatteryLifeSelector.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.RobotBatteryLifeSelector.ValueChanged += new System.EventHandler(this.RobotBatteryLifeSelector_ValueChanged);
            // 
            // WhiskersEfficiencyValueLabel
            // 
            this.WhiskersEfficiencyValueLabel.AutoSize = true;
            this.WhiskersEfficiencyValueLabel.Enabled = false;
            this.WhiskersEfficiencyValueLabel.Location = new System.Drawing.Point(102, 133);
            this.WhiskersEfficiencyValueLabel.Name = "WhiskersEfficiencyValueLabel";
            this.WhiskersEfficiencyValueLabel.Size = new System.Drawing.Size(29, 15);
            this.WhiskersEfficiencyValueLabel.TabIndex = 18;
            this.WhiskersEfficiencyValueLabel.Text = "30%";
            // 
            // RunAnotherSimulationLabel
            // 
            this.RunAnotherSimulationLabel.AutoSize = true;
            this.RunAnotherSimulationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RunAnotherSimulationLabel.Location = new System.Drawing.Point(334, 147);
            this.RunAnotherSimulationLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.RunAnotherSimulationLabel.Name = "RunAnotherSimulationLabel";
            this.RunAnotherSimulationLabel.Size = new System.Drawing.Size(122, 30);
            this.RunAnotherSimulationLabel.TabIndex = 19;
            this.RunAnotherSimulationLabel.Text = "Do You Want to Run Another Simulation?";
            this.RunAnotherSimulationLabel.Visible = false;
            // 
            // NoRunAnotherSimulationButton
            // 
            this.NoRunAnotherSimulationButton.Location = new System.Drawing.Point(407, 190);
            this.NoRunAnotherSimulationButton.Name = "NoRunAnotherSimulationButton";
            this.NoRunAnotherSimulationButton.Size = new System.Drawing.Size(58, 23);
            this.NoRunAnotherSimulationButton.TabIndex = 18;
            this.NoRunAnotherSimulationButton.Text = "No";
            this.NoRunAnotherSimulationButton.UseVisualStyleBackColor = true;
            this.NoRunAnotherSimulationButton.Visible = false;
            this.NoRunAnotherSimulationButton.Click += new System.EventHandler(this.NoRunAnotherSimulationButton_Click);
            // 
            // YesRunAnotherSimulationButton
            // 
            this.YesRunAnotherSimulationButton.Location = new System.Drawing.Point(322, 190);
            this.YesRunAnotherSimulationButton.Name = "YesRunAnotherSimulationButton";
            this.YesRunAnotherSimulationButton.Size = new System.Drawing.Size(58, 23);
            this.YesRunAnotherSimulationButton.TabIndex = 17;
            this.YesRunAnotherSimulationButton.Text = "Yes";
            this.YesRunAnotherSimulationButton.UseVisualStyleBackColor = true;
            this.YesRunAnotherSimulationButton.Visible = false;
            this.YesRunAnotherSimulationButton.Click += new System.EventHandler(this.YesRunAnotherSimulationButton_Click);
            // 
            // LoadSaveSimSettingsGroupBox
            // 
            this.LoadSaveSimSettingsGroupBox.Controls.Add(this.LoadSimulationButton);
            this.LoadSaveSimSettingsGroupBox.Location = new System.Drawing.Point(3, 219);
            this.LoadSaveSimSettingsGroupBox.Name = "LoadSaveSimSettingsGroupBox";
            this.LoadSaveSimSettingsGroupBox.Size = new System.Drawing.Size(474, 87);
            this.LoadSaveSimSettingsGroupBox.TabIndex = 16;
            this.LoadSaveSimSettingsGroupBox.TabStop = false;
            this.LoadSaveSimSettingsGroupBox.Text = "Report Files";
            // 
            // LoadSimulationButton
            // 
            this.LoadSimulationButton.Location = new System.Drawing.Point(7, 32);
            this.LoadSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadSimulationButton.Name = "LoadSimulationButton";
            this.LoadSimulationButton.Size = new System.Drawing.Size(161, 22);
            this.LoadSimulationButton.TabIndex = 14;
            this.LoadSimulationButton.Text = "Load Simulation Report";
            this.LoadSimulationButton.UseVisualStyleBackColor = true;
            this.LoadSimulationButton.Click += new System.EventHandler(this.LoadSimulationButton_Click);
            // 
            // SimulationControlLabel
            // 
            this.SimulationControlLabel.BackColor = System.Drawing.Color.Transparent;
            this.SimulationControlLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimulationControlLabel.Enabled = false;
            this.SimulationControlLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.SimulationControlLabel.Location = new System.Drawing.Point(0, 0);
            this.SimulationControlLabel.Margin = new System.Windows.Forms.Padding(4);
            this.SimulationControlLabel.Name = "SimulationControlLabel";
            this.SimulationControlLabel.Size = new System.Drawing.Size(477, 23);
            this.SimulationControlLabel.TabIndex = 5;
            this.SimulationControlLabel.Text = "Simulation Control";
            this.SimulationControlLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SimulationSpeedLabel
            // 
            this.SimulationSpeedLabel.AutoSize = true;
            this.SimulationSpeedLabel.Enabled = false;
            this.SimulationSpeedLabel.Location = new System.Drawing.Point(12, 37);
            this.SimulationSpeedLabel.Name = "SimulationSpeedLabel";
            this.SimulationSpeedLabel.Size = new System.Drawing.Size(99, 15);
            this.SimulationSpeedLabel.TabIndex = 10;
            this.SimulationSpeedLabel.Text = "Simulation Speed";
            // 
            // StartSimulationButton
            // 
            this.StartSimulationButton.Enabled = false;
            this.StartSimulationButton.Location = new System.Drawing.Point(10, 96);
            this.StartSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartSimulationButton.Name = "StartSimulationButton";
            this.StartSimulationButton.Size = new System.Drawing.Size(110, 22);
            this.StartSimulationButton.TabIndex = 7;
            this.StartSimulationButton.Text = "Start Simulation";
            this.StartSimulationButton.UseVisualStyleBackColor = true;
            this.StartSimulationButton.Click += new System.EventHandler(this.StartSimulationButton_Click);
            // 
            // SimulationSpeedSelector
            // 
            this.SimulationSpeedSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SimulationSpeedSelector.Enabled = false;
            this.SimulationSpeedSelector.FormattingEnabled = true;
            this.SimulationSpeedSelector.Location = new System.Drawing.Point(12, 54);
            this.SimulationSpeedSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SimulationSpeedSelector.Name = "SimulationSpeedSelector";
            this.SimulationSpeedSelector.Size = new System.Drawing.Size(115, 23);
            this.SimulationSpeedSelector.TabIndex = 9;
            this.SimulationSpeedSelector.SelectedIndexChanged += new System.EventHandler(this.SimulationSpeedSelector_SelectedIndexChanged);
            // 
            // StopSimulationButton
            // 
            this.StopSimulationButton.Enabled = false;
            this.StopSimulationButton.Location = new System.Drawing.Point(125, 96);
            this.StopSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopSimulationButton.Name = "StopSimulationButton";
            this.StopSimulationButton.Size = new System.Drawing.Size(110, 22);
            this.StopSimulationButton.TabIndex = 8;
            this.StopSimulationButton.Text = "Stop Simulation";
            this.StopSimulationButton.UseVisualStyleBackColor = true;
            this.StopSimulationButton.Click += new System.EventHandler(this.StopSimulationButton_Click);
            // 
            // ShowInstructionsButton
            // 
            this.ShowInstructionsButton.Location = new System.Drawing.Point(825, 783);
            this.ShowInstructionsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowInstructionsButton.Name = "ShowInstructionsButton";
            this.ShowInstructionsButton.Size = new System.Drawing.Size(113, 22);
            this.ShowInstructionsButton.TabIndex = 17;
            this.ShowInstructionsButton.Text = "Show Instructions";
            this.ShowInstructionsButton.UseVisualStyleBackColor = true;
            this.ShowInstructionsButton.Click += new System.EventHandler(this.ShowInstructionsButton_Click);
            // 
            // CenterSplitPane
            // 
            this.CenterSplitPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CenterSplitPane.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CenterSplitPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterSplitPane.IsSplitterFixed = true;
            this.CenterSplitPane.Location = new System.Drawing.Point(0, 0);
            this.CenterSplitPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CenterSplitPane.Name = "CenterSplitPane";
            // 
            // CenterSplitPane.Panel1
            // 
            this.CenterSplitPane.Panel1.Controls.Add(this.LeftPane);
            // 
            // CenterSplitPane.Panel2
            // 
            this.CenterSplitPane.Panel2.Controls.Add(this.CurrentAlgorithmLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.ShowInstructionsButton);
            this.CenterSplitPane.Panel2.Controls.Add(this.SimTimeElapsedLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.SimTimeElapsedTitleLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.BatteryLeftLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.BatteryLeftTitleLabel);
            this.CenterSplitPane.Panel2.Controls.Add(this.FloorCanvas);
            this.CenterSplitPane.Size = new System.Drawing.Size(1904, 811);
            this.CenterSplitPane.SplitterDistance = 952;
            this.CenterSplitPane.SplitterWidth = 1;
            this.CenterSplitPane.TabIndex = 0;
            // 
            // CurrentAlgorithmLabel
            // 
            this.CurrentAlgorithmLabel.AutoSize = true;
            this.CurrentAlgorithmLabel.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentAlgorithmLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentAlgorithmLabel.Location = new System.Drawing.Point(376, 792);
            this.CurrentAlgorithmLabel.Name = "CurrentAlgorithmLabel";
            this.CurrentAlgorithmLabel.Size = new System.Drawing.Size(126, 16);
            this.CurrentAlgorithmLabel.TabIndex = 18;
            this.CurrentAlgorithmLabel.Text = "Current Algorithm:";
            // 
            // SimTimeElapsedLabel
            // 
            this.SimTimeElapsedLabel.AutoSize = true;
            this.SimTimeElapsedLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SimTimeElapsedLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SimTimeElapsedLabel.Location = new System.Drawing.Point(161, 792);
            this.SimTimeElapsedLabel.Name = "SimTimeElapsedLabel";
            this.SimTimeElapsedLabel.Size = new System.Drawing.Size(69, 16);
            this.SimTimeElapsedLabel.TabIndex = 4;
            this.SimTimeElapsedLabel.Text = "0 seconds";
            // 
            // SimTimeElapsedTitleLabel
            // 
            this.SimTimeElapsedTitleLabel.AutoSize = true;
            this.SimTimeElapsedTitleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.SimTimeElapsedTitleLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SimTimeElapsedTitleLabel.Location = new System.Drawing.Point(3, 792);
            this.SimTimeElapsedTitleLabel.Name = "SimTimeElapsedTitleLabel";
            this.SimTimeElapsedTitleLabel.Size = new System.Drawing.Size(163, 16);
            this.SimTimeElapsedTitleLabel.TabIndex = 3;
            this.SimTimeElapsedTitleLabel.Text = "Simulation Time Elapsed:";
            // 
            // BatteryLeftLabel
            // 
            this.BatteryLeftLabel.AutoSize = true;
            this.BatteryLeftLabel.BackColor = System.Drawing.SystemColors.Window;
            this.BatteryLeftLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BatteryLeftLabel.Location = new System.Drawing.Point(84, 773);
            this.BatteryLeftLabel.Name = "BatteryLeftLabel";
            this.BatteryLeftLabel.Size = new System.Drawing.Size(84, 16);
            this.BatteryLeftLabel.TabIndex = 2;
            this.BatteryLeftLabel.Text = "150 minutes";
            // 
            // BatteryLeftTitleLabel
            // 
            this.BatteryLeftTitleLabel.AutoSize = true;
            this.BatteryLeftTitleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.BatteryLeftTitleLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BatteryLeftTitleLabel.Location = new System.Drawing.Point(3, 773);
            this.BatteryLeftTitleLabel.Name = "BatteryLeftTitleLabel";
            this.BatteryLeftTitleLabel.Size = new System.Drawing.Size(84, 16);
            this.BatteryLeftTitleLabel.TabIndex = 1;
            this.BatteryLeftTitleLabel.Text = "Battery Left:";
            // 
            // FloorCanvas
            // 
            this.FloorCanvas.BackColor = System.Drawing.SystemColors.Window;
            this.FloorCanvas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FloorCanvas.Location = new System.Drawing.Point(1, 1);
            this.FloorCanvas.Name = "FloorCanvas";
            this.FloorCanvas.Size = new System.Drawing.Size(954, 809);
            this.FloorCanvas.TabIndex = 0;
            this.FloorCanvas.TabStop = false;
            this.FloorCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.FloorCanvas_Paint);
            this.FloorCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_Click);
            this.FloorCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_Click);
            this.FloorCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloorCanvas_MouseUp);
            // 
            // VacDisplayTimer
            // 
            this.VacDisplayTimer.Interval = 1;
            this.VacDisplayTimer.Tick += new System.EventHandler(this.VacDisplayTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 811);
            this.Controls.Add(this.CenterSplitPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Team 8 Robot Vaccuum Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LeftPane.Panel1.ResumeLayout(false);
            this.LeftPane.Panel1.PerformLayout();
            this.LeftPane.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftPane)).EndInit();
            this.LeftPane.ResumeLayout(false);
            this.ObstaclesGroupBox.ResumeLayout(false);
            this.ChairTableDimensionsGroupBox.ResumeLayout(false);
            this.ChairTableDimensionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableHeightSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChairTableWidthSelector)).EndInit();
            this.RoomDimensionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoomWidthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomHeightSelector)).EndInit();
            this.LoadSaveFloorplanGroupBox.ResumeLayout(false);
            this.HouseDimensionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HouseWidthSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HouseHeightSelector)).EndInit();
            this.FloorTypeGroupBox.ResumeLayout(false);
            this.FloorTypeGroupBox.PerformLayout();
            this.ControlsPane.Panel1.ResumeLayout(false);
            this.ControlsPane.Panel1.PerformLayout();
            this.ControlsPane.Panel2.ResumeLayout(false);
            this.ControlsPane.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsPane)).EndInit();
            this.ControlsPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InitialVacuumHeadingSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiskersEfficiencySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VacuumEfficiencySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotSpeedSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RobotBatteryLifeSelector)).EndInit();
            this.LoadSaveSimSettingsGroupBox.ResumeLayout(false);
            this.CenterSplitPane.Panel1.ResumeLayout(false);
            this.CenterSplitPane.Panel2.ResumeLayout(false);
            this.CenterSplitPane.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CenterSplitPane)).EndInit();
            this.CenterSplitPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FloorCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer LeftPane;
        private System.Windows.Forms.SplitContainer ControlsPane;
        private System.Windows.Forms.Label SimulationControlLabel;
        private System.Windows.Forms.Label RobotBatteryLifeLabel;
        private System.Windows.Forms.NumericUpDown RobotBatteryLifeSelector;
        private System.Windows.Forms.Label RobotSpeedLabel;
        private System.Windows.Forms.NumericUpDown RobotSpeedSelector;
        private System.Windows.Forms.Label RobotPathAlgorithmLabel;
        private System.Windows.Forms.ComboBox RobotPathAlgorithmSelector;
        private System.Windows.Forms.CheckBox RunAllAlgorithmsCheckbox;
        private System.Windows.Forms.GroupBox HouseDimensionsGroupBox;
        private System.Windows.Forms.Label HouseWidthLabel;
        private System.Windows.Forms.Label HouseHeightLabel;
        private System.Windows.Forms.NumericUpDown HouseWidthSelector;
        private System.Windows.Forms.NumericUpDown HouseHeightSelector;
        private System.Windows.Forms.GroupBox FloorTypeGroupBox;
        private System.Windows.Forms.RadioButton FriezeCutPileRadioButton;
        private System.Windows.Forms.RadioButton CutPileRadioButton;
        private System.Windows.Forms.RadioButton LoopPileRadioButton;
        private System.Windows.Forms.RadioButton HardWoodRadioButton;
        private System.Windows.Forms.Label FloorplanDesignLabel;
        private System.Windows.Forms.Label SimulationSpeedLabel;
        private System.Windows.Forms.ComboBox SimulationSpeedSelector;
        private System.Windows.Forms.Button StopSimulationButton;
        private System.Windows.Forms.Button StartSimulationButton;
        private System.Windows.Forms.Label VacuumAttributesLabel;
        private System.Windows.Forms.SplitContainer CenterSplitPane;
        private System.Windows.Forms.GroupBox LoadSaveFloorplanGroupBox;
        private System.Windows.Forms.Button LoadSimulationButton;
        private System.Windows.Forms.Button SaveFloorplanButton;
        private System.Windows.Forms.Button LoadDefaultFloorplanButton;
        private System.Windows.Forms.PictureBox FloorCanvas;
        private System.Windows.Forms.ComboBox ObstacleSelector;
        private System.Windows.Forms.Label BatteryLeftLabel;
        private System.Windows.Forms.Label BatteryLeftTitleLabel;
        private System.Windows.Forms.Button LoadSavedFloorplanButton;
        private System.Windows.Forms.Label SimTimeElapsedLabel;
        private System.Windows.Forms.Label SimTimeElapsedTitleLabel;
        private System.Windows.Forms.GroupBox RoomDimensionsGroupBox;
        private System.Windows.Forms.Label RoomWidthLabel;
        private System.Windows.Forms.Label RoomHeightLabel;
        private System.Windows.Forms.NumericUpDown RoomWidthSelector;
        private System.Windows.Forms.NumericUpDown RoomHeightSelector;
        private System.Windows.Forms.Label ObstacleSelectorLabel;
        private System.Windows.Forms.GroupBox ChairTableDimensionsGroupBox;
        private System.Windows.Forms.Label ChairTableHeightLabel;
        private System.Windows.Forms.Label ChairTableWidthLabel;
        private System.Windows.Forms.NumericUpDown ChairTableHeightSelector;
        private System.Windows.Forms.NumericUpDown ChairTableWidthSelector;
        private System.Windows.Forms.Button EraserModeButton;
        public System.Windows.Forms.Timer VacDisplayTimer;
        private System.Windows.Forms.Label WhiskersEfficiencyTitleLabel;
        private System.Windows.Forms.Label VacuumEfficiencyTitleLabel;
        private System.Windows.Forms.TrackBar WhiskersEfficiencySlider;
        private System.Windows.Forms.TrackBar VacuumEfficiencySlider;
        private System.Windows.Forms.Label WhiskersEfficiencyValueLabel;
        private System.Windows.Forms.Label VacuumEfficiencyValueLabel;
        private System.Windows.Forms.Button ShowInstructionsButton;
        private System.Windows.Forms.GroupBox LoadSaveSimSettingsGroupBox;
        private System.Windows.Forms.Button FinishOrEditFloorplanButton;
        private System.Windows.Forms.Label InitialVacuumHeadingLabel;
        private System.Windows.Forms.NumericUpDown InitialVacuumHeadingSelector;
        private System.Windows.Forms.Label PlaceVacuumInstructionsLabel;
        private System.Windows.Forms.GroupBox ObstaclesGroupBox;
        private System.Windows.Forms.Label CreateDoorwayInstructionsLabel;
        private System.Windows.Forms.Button YesRunAnotherSimulationButton;
        private System.Windows.Forms.Label RunAnotherSimulationLabel;
        private System.Windows.Forms.Button NoRunAnotherSimulationButton;
        private System.Windows.Forms.Label CurrentAlgorithmLabel;
    }
}