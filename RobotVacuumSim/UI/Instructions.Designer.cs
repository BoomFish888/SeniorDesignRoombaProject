
namespace VacuumSim.UI
{
    partial class Instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instructions));
            this.InstructionsTextBox = new System.Windows.Forms.TextBox();
            this.SoftwareTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InstructionsTextBox
            // 
            this.InstructionsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.InstructionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.InstructionsTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InstructionsTextBox.Location = new System.Drawing.Point(1, 38);
            this.InstructionsTextBox.Multiline = true;
            this.InstructionsTextBox.Name = "InstructionsTextBox";
            this.InstructionsTextBox.ReadOnly = true;
            this.InstructionsTextBox.Size = new System.Drawing.Size(1383, 486);
            this.InstructionsTextBox.TabIndex = 0;
            this.InstructionsTextBox.Text = resources.GetString("InstructionsTextBox.Text");
            this.InstructionsTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InstructionsTextBox_MouseDown);
            // 
            // SoftwareTitleLabel
            // 
            this.SoftwareTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SoftwareTitleLabel.AutoSize = true;
            this.SoftwareTitleLabel.Font = new System.Drawing.Font("Harlow Solid Italic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.SoftwareTitleLabel.ForeColor = System.Drawing.Color.Teal;
            this.SoftwareTitleLabel.Location = new System.Drawing.Point(560, 9);
            this.SoftwareTitleLabel.Name = "SoftwareTitleLabel";
            this.SoftwareTitleLabel.Size = new System.Drawing.Size(230, 26);
            this.SoftwareTitleLabel.TabIndex = 1;
            this.SoftwareTitleLabel.Text = "Robot Vacuum Simulator";
            // 
            // Instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1384, 521);
            this.Controls.Add(this.SoftwareTitleLabel);
            this.Controls.Add(this.InstructionsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Instructions";
            this.ShowIcon = false;
            this.Text = "Instructions";
            this.Load += new System.EventHandler(this.Instructions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InstructionsTextBox;
        private System.Windows.Forms.Label SoftwareTitleLabel;
    }
}