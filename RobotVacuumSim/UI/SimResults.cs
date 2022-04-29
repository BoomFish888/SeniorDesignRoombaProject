using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VacuumSim.UI
{
    /// <summary>
    /// A modal that allows the user to view the results of past simulations, and recall the settings and floorplan from those past simulations.
    /// </summary>
    public partial class SimResults : Form
    {
        private readonly Form1 _parentForm;
        private readonly FloorplanLayout _fplayout;

        /// <summary>
        /// Initializes and shows a new instance of the <see cref="SimResults"/> class.
        /// </summary>
        /// <param name="loadedFileName">The path of the simulation report to load when the modal is spawned.</param>
        /// <param name="ParentForm">The parent form (Form1).</param>
        /// <param name="fplayout">A reference to the FloorplanLayout from the parent Form.</param>
        public SimResults(string loadedFileName, Form1 ParentForm, ref FloorplanLayout fplayout)
        {
            _fplayout = fplayout;
            _parentForm = ParentForm;
            InitializeComponent();
            // Get the file name by itself for using in titles.
            string[] _splitFileName = loadedFileName.Split('\\');
            string fileName = _splitFileName[_splitFileName.Length - 1];

            // Load the simulation report
            string simReport = File.ReadAllText(loadedFileName);
            SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

            // Add rows to the table for the fields in the simulation report.
            PropertyInfo[] properties = inreport.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                // Don't show the floorplan data field cause it's huge and not user-facing
                if (pi.Name != "FloorplanData")
                {
                    MainDataGridView.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                }
            }

            MainDataGridView.Rows.Add("Report Path", loadedFileName);

            SimulationReportTabs.TabPages[0].Text = fileName;
        }

        /// <summary>
        /// Loads the SimReport json file shown by the active tab, and returns it as a SimulationReport object.
        /// </summary>
        /// <returns>The SimulationReport object shown on the active tab. Returns null if there was an error.</returns>
        private SimulationReport GetSimReportFromActiveTab()
        {
            // Find the gridview control on the active tab
            var activeTabControls = SimulationReportTabs.SelectedTab.Controls;
            DataGridView activeTabGridView = (DataGridView)activeTabControls[0];
            string thisReportPath = "";
            var pathRow = activeTabGridView.Rows[activeTabGridView.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            // Get the path held in the 'Report Path' row.
            if (pathRow.Cells[0].Value.ToString() == "Report Path")
            {
                thisReportPath = pathRow.Cells[1].Value.ToString();
            }

            // Load the report and create SimulationReport object.
            string simReport;
            if (thisReportPath != "")
            {
                simReport = File.ReadAllText(thisReportPath);
            }
            else { return null; }
            SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

            // Return the object.
            return inreport;
        }

        /// <summary>
        /// Loads the floorplan that is saved in the report that is currently being viewed.
        /// </summary>
        private void LoadFloorplanButton_Click(object sender, EventArgs e)
        {
            // Get the SimulationReport data shown by the active tab
            SimulationReport inreport = GetSimReportFromActiveTab();

            if (inreport == null)
            {
                MessageBox.Show("Error loading simulation report.");
                this.Close();
            }
            // Load the floorplan saved in the active simulation report.
            FloorplanFileReader.LoadTileGridData(inreport.FloorplanData, _fplayout);
            this.Close();
        }

        /// <summary>
        /// Loads the floorplan and simulation settings that are saved in the report that is currently being viewed.
        /// </summary>
        private void LoadFloorplanAndSettingsButton_Click(object sender, EventArgs e)
        {
            SimulationReport inreport = GetSimReportFromActiveTab();

            if (inreport == null)
            {
                MessageBox.Show("Error loading simulation report.");
                this.Close();
            }
            FloorplanFileReader.LoadTileGridData(inreport.FloorplanData, _fplayout);
            _parentForm.LoadSimulationSettingsFromReport(inreport);
            this.Close();
        }

        /// <summary>
        /// Handler for clicking a report Tab. Used to make the + tab work to add a new tab.
        /// </summary>

        private void SimulationReportTabs_MouseClick(object sender, MouseEventArgs e)
        {
            var lastTabIdx = this.SimulationReportTabs.TabCount - 1;
            // If the user clicked on the last tab (the add tab button)
            if (this.SimulationReportTabs.GetTabRect(lastTabIdx).Contains(e.Location))
            {
                // Ask the user for a path to a simulation report to load.
                string inFilePath;
                // get the current user's desktop directory.
                string usrDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                OpenFileDialog openFloorplanDialog = new OpenFileDialog
                {
                    Title = "Open Saved Simulation",
                    Filter = "Report Files (*.json)|*.json",
                    InitialDirectory = usrDesktopPath,
                    RestoreDirectory = true
                };

                if (openFloorplanDialog.ShowDialog() == DialogResult.OK)
                {
                    inFilePath = openFloorplanDialog.FileName;
                }
                else
                {
                    // If the user closes the dialog without opening anything, just exit out.
                    return;
                }

                string[] _splitFileName = inFilePath.Split('\\');
                string fileName = _splitFileName[_splitFileName.Length - 1];

                // Load the simulation report.
                string simReport = File.ReadAllText(inFilePath);
                SimulationReport inreport = JsonSerializer.Deserialize<SimulationReport>(simReport)!;

                // Add a new tab for the newly loaded report, and move the + tab back to the end.
                this.SimulationReportTabs.TabPages.Insert(lastTabIdx, fileName);
                this.SimulationReportTabs.SelectedIndex = lastTabIdx;
                SimulationReportTabs.TabPages[SimulationReportTabs.SelectedIndex].Padding = new Padding(3);
                SimulationReportTabs.TabPages[SimulationReportTabs.SelectedIndex].UseVisualStyleBackColor = true;

                var lastContentTabIdx = this.SimulationReportTabs.TabCount - 2;

                // Create the content to stick in the new tab.
                DataGridView dgv = new DataGridView();
                dgv.Columns.Add("Property", "Property");
                dgv.Columns.Add("Value", "Value");
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToResizeRows = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.Size = new Size(482, 473);
                dgv.ReadOnly = true;

                // Loop through the properties of the loaded report and add them to the table.
                PropertyInfo[] properties = inreport.GetType().GetProperties();
                foreach (PropertyInfo pi in properties)
                {
                    // Don't show the floorplan data field cause it's huge and not user-facing
                    if (pi.Name != "FloorplanData")
                    {
                        dgv.Rows.Add(pi.Name, pi.GetValue(inreport, null).ToString());
                    }
                }

                // Also add the path to the simulation report.
                dgv.Rows.Add("Report Path", inFilePath);
                // Set the tab title
                SimulationReportTabs.TabPages[lastContentTabIdx].Text = fileName;
                dgv.Parent = SimulationReportTabs.TabPages[lastContentTabIdx];
                dgv.Dock = DockStyle.Fill;
            }
        }
    }
}