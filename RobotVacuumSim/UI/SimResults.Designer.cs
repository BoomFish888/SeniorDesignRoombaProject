﻿
namespace VacuumSim.UI
{
    partial class SimResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SimReportFieldsTable = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadedFileLabel = new System.Windows.Forms.Label();
            this.LoadFloorplanAndSettingsButton = new System.Windows.Forms.Button();
            this.LoadFloorplanButton = new System.Windows.Forms.Button();
            this.SimulationReportTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.SimReportFieldsTable)).BeginInit();
            this.SimulationReportTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimReportFieldsTable
            // 
            this.SimReportFieldsTable.AllowUserToAddRows = false;
            this.SimReportFieldsTable.AllowUserToResizeRows = false;
            this.SimReportFieldsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SimReportFieldsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimReportFieldsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.SimReportFieldsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimReportFieldsTable.Location = new System.Drawing.Point(3, 3);
            this.SimReportFieldsTable.Name = "SimReportFieldsTable";
            this.SimReportFieldsTable.ReadOnly = true;
            this.SimReportFieldsTable.RowHeadersVisible = false;
            this.SimReportFieldsTable.RowTemplate.Height = 25;
            this.SimReportFieldsTable.Size = new System.Drawing.Size(482, 473);
            this.SimReportFieldsTable.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // LoadedFileLabel
            // 
            this.LoadedFileLabel.AutoSize = true;
            this.LoadedFileLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadedFileLabel.Location = new System.Drawing.Point(12, 9);
            this.LoadedFileLabel.Name = "LoadedFileLabel";
            this.LoadedFileLabel.Size = new System.Drawing.Size(78, 25);
            this.LoadedFileLabel.TabIndex = 1;
            this.LoadedFileLabel.Text = "Loaded:";
            // 
            // LoadFloorplanAndSettingsButton
            // 
            this.LoadFloorplanAndSettingsButton.Location = new System.Drawing.Point(345, 550);
            this.LoadFloorplanAndSettingsButton.Name = "LoadFloorplanAndSettingsButton";
            this.LoadFloorplanAndSettingsButton.Size = new System.Drawing.Size(163, 45);
            this.LoadFloorplanAndSettingsButton.TabIndex = 2;
            this.LoadFloorplanAndSettingsButton.Text = "Load this floorplan + settings";
            this.LoadFloorplanAndSettingsButton.UseVisualStyleBackColor = true;
            this.LoadFloorplanAndSettingsButton.Click += new System.EventHandler(this.LoadFloorplanAndSettingsButton_Click);
            // 
            // LoadFloorplanButton
            // 
            this.LoadFloorplanButton.Location = new System.Drawing.Point(12, 551);
            this.LoadFloorplanButton.Name = "LoadFloorplanButton";
            this.LoadFloorplanButton.Size = new System.Drawing.Size(163, 44);
            this.LoadFloorplanButton.TabIndex = 3;
            this.LoadFloorplanButton.Text = "Load this floorplan";
            this.LoadFloorplanButton.UseVisualStyleBackColor = true;
            this.LoadFloorplanButton.Click += new System.EventHandler(this.LoadFloorplanButton_Click);
            // 
            // SimulationReportTabs
            // 
            this.SimulationReportTabs.Controls.Add(this.tabPage1);
            this.SimulationReportTabs.Location = new System.Drawing.Point(12, 37);
            this.SimulationReportTabs.Name = "SimulationReportTabs";
            this.SimulationReportTabs.SelectedIndex = 0;
            this.SimulationReportTabs.Size = new System.Drawing.Size(496, 507);
            this.SimulationReportTabs.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SimReportFieldsTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(488, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SimResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 607);
            this.Controls.Add(this.SimulationReportTabs);
            this.Controls.Add(this.LoadFloorplanButton);
            this.Controls.Add(this.LoadFloorplanAndSettingsButton);
            this.Controls.Add(this.LoadedFileLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SimResults";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Simulation Results";
            ((System.ComponentModel.ISupportInitialize)(this.SimReportFieldsTable)).EndInit();
            this.SimulationReportTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SimReportFieldsTable;
        private System.Windows.Forms.Label LoadedFileLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button LoadFloorplanAndSettingsButton;
        private System.Windows.Forms.Button LoadFloorplanButton;
        private System.Windows.Forms.TabControl SimulationReportTabs;
        private System.Windows.Forms.TabPage tabPage1;
    }
}