
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
            this.button_shutter = new System.Windows.Forms.Button();
            this.ShutterLabel = new System.Windows.Forms.Label();
            this.ShutterStateLabel = new System.Windows.Forms.Label();
            this.groupboxWlCtrl = new System.Windows.Forms.GroupBox();
            this.comboboxGrating = new System.Windows.Forms.ComboBox();
            this.labelGrating = new System.Windows.Forms.Label();
            this.textboxPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.groupboxWlCtrl.SuspendLayout();
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
            // button_shutter
            // 
            this.button_shutter.Enabled = false;
            this.button_shutter.Location = new System.Drawing.Point(713, 92);
            this.button_shutter.Name = "button_shutter";
            this.button_shutter.Size = new System.Drawing.Size(75, 23);
            this.button_shutter.TabIndex = 24;
            this.button_shutter.Text = "Open/Close";
            this.button_shutter.UseVisualStyleBackColor = true;
            this.button_shutter.Click += new System.EventHandler(this.button_shutter_Click);
            // 
            // ShutterLabel
            // 
            this.ShutterLabel.AutoSize = true;
            this.ShutterLabel.Location = new System.Drawing.Point(615, 97);
            this.ShutterLabel.Name = "ShutterLabel";
            this.ShutterLabel.Size = new System.Drawing.Size(44, 13);
            this.ShutterLabel.TabIndex = 25;
            this.ShutterLabel.Text = "Shutter:";
            // 
            // ShutterStateLabel
            // 
            this.ShutterStateLabel.AutoSize = true;
            this.ShutterStateLabel.Location = new System.Drawing.Point(663, 97);
            this.ShutterStateLabel.Name = "ShutterStateLabel";
            this.ShutterStateLabel.Size = new System.Drawing.Size(33, 13);
            this.ShutterStateLabel.TabIndex = 26;
            this.ShutterStateLabel.Text = "Close";
            // 
            // groupboxWlCtrl
            // 
            this.groupboxWlCtrl.Controls.Add(this.comboboxGrating);
            this.groupboxWlCtrl.Controls.Add(this.labelGrating);
            this.groupboxWlCtrl.Controls.Add(this.textboxPosition);
            this.groupboxWlCtrl.Controls.Add(this.labelPosition);
            this.groupboxWlCtrl.Enabled = false;
            this.groupboxWlCtrl.Location = new System.Drawing.Point(26, 64);
            this.groupboxWlCtrl.Name = "groupboxWlCtrl";
            this.groupboxWlCtrl.Size = new System.Drawing.Size(241, 78);
            this.groupboxWlCtrl.TabIndex = 27;
            this.groupboxWlCtrl.TabStop = false;
            this.groupboxWlCtrl.Text = "Wavelength Control";
            // 
            // comboboxGrating
            // 
            this.comboboxGrating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxGrating.FormattingEnabled = true;
            this.comboboxGrating.Location = new System.Drawing.Point(142, 40);
            this.comboboxGrating.Name = "comboboxGrating";
            this.comboboxGrating.Size = new System.Drawing.Size(73, 21);
            this.comboboxGrating.TabIndex = 3;
            this.comboboxGrating.SelectedIndexChanged += new System.EventHandler(this.comboboxGrating_SelectedIndexChanged);
            // 
            // labelGrating
            // 
            this.labelGrating.AutoSize = true;
            this.labelGrating.Location = new System.Drawing.Point(142, 23);
            this.labelGrating.Name = "labelGrating";
            this.labelGrating.Size = new System.Drawing.Size(41, 13);
            this.labelGrating.TabIndex = 2;
            this.labelGrating.Text = "Grating";
            // 
            // textboxPosition
            // 
            this.textboxPosition.Location = new System.Drawing.Point(28, 42);
            this.textboxPosition.Name = "textboxPosition";
            this.textboxPosition.Size = new System.Drawing.Size(75, 20);
            this.textboxPosition.TabIndex = 1;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(28, 23);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(67, 13);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "Position (nm)";
            // 
            // SpecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupboxWlCtrl);
            this.Controls.Add(this.ShutterStateLabel);
            this.Controls.Add(this.ShutterLabel);
            this.Controls.Add(this.button_shutter);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBoxSCDs);
            this.Controls.Add(this.buttonComSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecForm";
            this.Text = "SpecForm";
            this.groupboxWlCtrl.ResumeLayout(false);
            this.groupboxWlCtrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonComSet;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxSCDs;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button button_shutter;
        private System.Windows.Forms.Label ShutterLabel;
        private System.Windows.Forms.Label ShutterStateLabel;
        internal System.Windows.Forms.GroupBox groupboxWlCtrl;
        internal System.Windows.Forms.ComboBox comboboxGrating;
        internal System.Windows.Forms.Label labelGrating;
        internal System.Windows.Forms.TextBox textboxPosition;
        internal System.Windows.Forms.Label labelPosition;
    }
}