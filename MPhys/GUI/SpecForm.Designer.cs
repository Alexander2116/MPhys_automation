
namespace MPhys.GUI
{
    partial class SpecForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonComSet = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxSCDs = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonComSet
            // 
            this.buttonComSet.Location = new System.Drawing.Point(254, 23);
            this.buttonComSet.Name = "buttonComSet";
            this.buttonComSet.Size = new System.Drawing.Size(75, 23);
            this.buttonComSet.TabIndex = 6;
            this.buttonComSet.Text = "Initialize";
            this.buttonComSet.UseVisualStyleBackColor = true;
            this.buttonComSet.Click += new System.EventHandler(this.buttonComSet_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Set SCD";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxSCDs
            // 
            this.comboBoxSCDs.Enabled = false;
            this.comboBoxSCDs.FormattingEnabled = true;
            this.comboBoxSCDs.Location = new System.Drawing.Point(99, 25);
            this.comboBoxSCDs.Name = "comboBoxSCDs";
            this.comboBoxSCDs.Size = new System.Drawing.Size(54, 21);
            this.comboBoxSCDs.TabIndex = 21;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(175, 28);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(73, 13);
            this.StatusLabel.TabIndex = 23;
            this.StatusLabel.Text = "Disconnected";
            // 
            // SpecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBoxSCDs);
            this.Controls.Add(this.buttonComSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecForm";
            this.Text = "SpecForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonComSet;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxSCDs;
        private System.Windows.Forms.Label StatusLabel;
    }
}