
namespace MPhys.GUI
{
    partial class TestForm
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
            this.labelInitStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupboxWlCtrl = new System.Windows.Forms.GroupBox();
            this.comboboxGrating = new System.Windows.Forms.ComboBox();
            this.labelGrating = new System.Windows.Forms.Label();
            this.textboxPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.labelMonosDevs = new System.Windows.Forms.Label();
            this.comboboxMonos = new System.Windows.Forms.ComboBox();
            this.groupboxWlCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInitStatus
            // 
            this.labelInitStatus.Location = new System.Drawing.Point(186, 9);
            this.labelInitStatus.Name = "labelInitStatus";
            this.labelInitStatus.Size = new System.Drawing.Size(65, 23);
            this.labelInitStatus.TabIndex = 34;
            this.labelInitStatus.Text = "Uninitialized";
            this.labelInitStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(147, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 23);
            this.labelStatus.TabIndex = 33;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupboxWlCtrl
            // 
            this.groupboxWlCtrl.Controls.Add(this.comboboxGrating);
            this.groupboxWlCtrl.Controls.Add(this.labelGrating);
            this.groupboxWlCtrl.Controls.Add(this.textboxPosition);
            this.groupboxWlCtrl.Controls.Add(this.labelPosition);
            this.groupboxWlCtrl.Enabled = false;
            this.groupboxWlCtrl.Location = new System.Drawing.Point(10, 71);
            this.groupboxWlCtrl.Name = "groupboxWlCtrl";
            this.groupboxWlCtrl.Size = new System.Drawing.Size(241, 78);
            this.groupboxWlCtrl.TabIndex = 32;
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
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(269, 24);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStatus.Size = new System.Drawing.Size(277, 126);
            this.tbStatus.TabIndex = 31;
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.Location = new System.Drawing.Point(155, 33);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(75, 23);
            this.buttonInitialize.TabIndex = 30;
            this.buttonInitialize.Text = "Initialize";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // labelMonosDevs
            // 
            this.labelMonosDevs.Location = new System.Drawing.Point(17, 9);
            this.labelMonosDevs.Name = "labelMonosDevs";
            this.labelMonosDevs.Size = new System.Drawing.Size(100, 23);
            this.labelMonosDevs.TabIndex = 29;
            this.labelMonosDevs.Text = "Select Mono";
            this.labelMonosDevs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboboxMonos
            // 
            this.comboboxMonos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxMonos.FormattingEnabled = true;
            this.comboboxMonos.Location = new System.Drawing.Point(10, 35);
            this.comboboxMonos.Name = "comboboxMonos";
            this.comboboxMonos.Size = new System.Drawing.Size(121, 21);
            this.comboboxMonos.TabIndex = 28;
            this.comboboxMonos.SelectedIndexChanged += new System.EventHandler(this.comboboxMonos_SelectedIndexChanged);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelInitStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupboxWlCtrl);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.buttonInitialize);
            this.Controls.Add(this.labelMonosDevs);
            this.Controls.Add(this.comboboxMonos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.groupboxWlCtrl.ResumeLayout(false);
            this.groupboxWlCtrl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label labelInitStatus;
        internal System.Windows.Forms.Label labelStatus;
        internal System.Windows.Forms.GroupBox groupboxWlCtrl;
        internal System.Windows.Forms.ComboBox comboboxGrating;
        internal System.Windows.Forms.Label labelGrating;
        internal System.Windows.Forms.TextBox textboxPosition;
        internal System.Windows.Forms.Label labelPosition;
        internal System.Windows.Forms.TextBox tbStatus;
        internal System.Windows.Forms.Button buttonInitialize;
        internal System.Windows.Forms.Label labelMonosDevs;
        internal System.Windows.Forms.ComboBox comboboxMonos;
    }
}