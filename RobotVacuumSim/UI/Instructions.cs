using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VacuumSim.UI
{
    public partial class Instructions : Form
    {
        private readonly Form1 _parentForm;

        public Instructions(Form1 ParentForm)
        {
            _parentForm = ParentForm;
            InitializeComponent();

            InstructionsTextBox.SelectionStart = InstructionsTextBox.Text.Length;
            InstructionsTextBox.DeselectAll();
            InstructionsTextBox.TabStop = false;
            SoftwareTitleLabel.Focus();
        }

        private void InstructionsTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            SoftwareTitleLabel.Focus();
        }

        private void Instructions_Load(object sender, EventArgs e)
        {

        }
    }
}
