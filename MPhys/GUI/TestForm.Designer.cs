
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Initialize";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 228);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 35;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Initialize";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 257);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 37;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 40;
            this.button3.Text = "Initialize";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(10, 286);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 39;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(155, 313);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 42;
            this.button4.Text = "Initialize";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(10, 315);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 41;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(155, 342);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 44;
            this.button5.Text = "Initialize";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(10, 344);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 43;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
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
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.ComboBox comboBox3;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.ComboBox comboBox4;
        internal System.Windows.Forms.Button button5;
        internal System.Windows.Forms.ComboBox comboBox5;
    }
}