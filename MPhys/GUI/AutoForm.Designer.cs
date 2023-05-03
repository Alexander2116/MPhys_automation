
namespace MPhys.GUI
{
    partial class AutoForm
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
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.textBoxExp = new System.Windows.Forms.TextBox();
            this.comboNDF2pos = new System.Windows.Forms.ComboBox();
            this.comboNDF1pos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.labelFinishTasks = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMaxTask = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textSample = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OpenPathDialog = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Image = new System.Windows.Forms.RadioButton();
            this.Spectra = new System.Windows.Forms.RadioButton();
            this.buttonInit = new System.Windows.Forms.Button();
            this.labelInit = new System.Windows.Forms.Label();
            this.textBoxSlit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PositionMode = new System.Windows.Forms.RadioButton();
            this.RangeMode = new System.Windows.Forms.RadioButton();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCentral = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(11, 305);
            this.listBoxTasks.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(296, 134);
            this.listBoxTasks.TabIndex = 16;
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(28, 100);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.Size = new System.Drawing.Size(79, 20);
            this.textBoxTemp.TabIndex = 17;
            // 
            // textBoxExp
            // 
            this.textBoxExp.Location = new System.Drawing.Point(233, 100);
            this.textBoxExp.Name = "textBoxExp";
            this.textBoxExp.Size = new System.Drawing.Size(51, 20);
            this.textBoxExp.TabIndex = 20;
            // 
            // comboNDF2pos
            // 
            this.comboNDF2pos.FormattingEnabled = true;
            this.comboNDF2pos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboNDF2pos.Location = new System.Drawing.Point(173, 99);
            this.comboNDF2pos.Name = "comboNDF2pos";
            this.comboNDF2pos.Size = new System.Drawing.Size(54, 21);
            this.comboNDF2pos.TabIndex = 22;
            // 
            // comboNDF1pos
            // 
            this.comboNDF1pos.FormattingEnabled = true;
            this.comboNDF1pos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboNDF1pos.Location = new System.Drawing.Point(113, 99);
            this.comboNDF1pos.Name = "comboNDF1pos";
            this.comboNDF1pos.Size = new System.Drawing.Size(54, 21);
            this.comboNDF1pos.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Temperature(K)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "NDF1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "NDF2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 26);
            this.label4.TabIndex = 26;
            this.label4.Text = "Integration\r\nTime (ns)";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(347, 99);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 27;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(11, 251);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 28;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "No.  |  Temp  |  pos1  |  pos2  |  Integration Time (ns)  |  Slit (nm)";
            // 
            // buttonSaveProfile
            // 
            this.buttonSaveProfile.Location = new System.Drawing.Point(185, 251);
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveProfile.TabIndex = 30;
            this.buttonSaveProfile.Text = "Save";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(663, 384);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 31;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // labelFinishTasks
            // 
            this.labelFinishTasks.AutoSize = true;
            this.labelFinishTasks.Location = new System.Drawing.Point(603, 389);
            this.labelFinishTasks.Name = "labelFinishTasks";
            this.labelFinishTasks.Size = new System.Drawing.Size(13, 13);
            this.labelFinishTasks.TabIndex = 32;
            this.labelFinishTasks.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(622, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "of";
            // 
            // labelMaxTask
            // 
            this.labelMaxTask.AutoSize = true;
            this.labelMaxTask.Location = new System.Drawing.Point(635, 389);
            this.labelMaxTask.Name = "labelMaxTask";
            this.labelMaxTask.Size = new System.Drawing.Size(13, 13);
            this.labelMaxTask.TabIndex = 34;
            this.labelMaxTask.Text = "0";
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(615, 266);
            this.Count.Margin = new System.Windows.Forms.Padding(2);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(39, 20);
            this.Count.TabIndex = 36;
            this.Count.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(537, 260);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 26);
            this.label10.TabIndex = 35;
            this.label10.Text = "Count of each\r\nspectra taken";
            // 
            // textSample
            // 
            this.textSample.Location = new System.Drawing.Point(615, 228);
            this.textSample.Margin = new System.Windows.Forms.Padding(2);
            this.textSample.Name = "textSample";
            this.textSample.Size = new System.Drawing.Size(62, 20);
            this.textSample.TabIndex = 38;
            this.textSample.Text = "AAA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Sample name";
            // 
            // OpenPathDialog
            // 
            this.OpenPathDialog.Location = new System.Drawing.Point(596, 167);
            this.OpenPathDialog.Name = "OpenPathDialog";
            this.OpenPathDialog.Size = new System.Drawing.Size(47, 23);
            this.OpenPathDialog.TabIndex = 41;
            this.OpenPathDialog.Text = "Open";
            this.OpenPathDialog.UseVisualStyleBackColor = true;
            this.OpenPathDialog.Click += new System.EventHandler(this.OpenPathDialog_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(540, 195);
            this.FileName.Margin = new System.Windows.Forms.Padding(2);
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Size = new System.Drawing.Size(248, 20);
            this.FileName.TabIndex = 40;
            this.FileName.Text = "Default";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(548, 172);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "File Path:";
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(554, 339);
            this.textBoxStart.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(57, 20);
            this.textBoxStart.TabIndex = 42;
            this.textBoxStart.Text = "300";
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(684, 339);
            this.textBoxEnd.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(62, 20);
            this.textBoxEnd.TabIndex = 43;
            this.textBoxEnd.Text = "500";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(498, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 26);
            this.label8.TabIndex = 44;
            this.label8.Text = "Spectra\r\nStart (nm)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(631, 333);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 26);
            this.label9.TabIndex = 45;
            this.label9.Text = "Spectra\r\nEnd (nm)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Image);
            this.groupBox4.Controls.Add(this.Spectra);
            this.groupBox4.Location = new System.Drawing.Point(28, 136);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(136, 54);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acq Format";
            // 
            // Image
            // 
            this.Image.AutoSize = true;
            this.Image.Location = new System.Drawing.Point(74, 23);
            this.Image.Margin = new System.Windows.Forms.Padding(2);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(54, 17);
            this.Image.TabIndex = 1;
            this.Image.Text = "Image";
            this.Image.UseVisualStyleBackColor = true;
            // 
            // Spectra
            // 
            this.Spectra.AutoSize = true;
            this.Spectra.Checked = true;
            this.Spectra.Location = new System.Drawing.Point(8, 23);
            this.Spectra.Margin = new System.Windows.Forms.Padding(2);
            this.Spectra.Name = "Spectra";
            this.Spectra.Size = new System.Drawing.Size(62, 17);
            this.Spectra.TabIndex = 0;
            this.Spectra.TabStop = true;
            this.Spectra.Text = "Spectra";
            this.Spectra.UseVisualStyleBackColor = true;
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(540, 119);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(75, 23);
            this.buttonInit.TabIndex = 50;
            this.buttonInit.Text = "Initialize";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // labelInit
            // 
            this.labelInit.AutoSize = true;
            this.labelInit.ForeColor = System.Drawing.Color.Red;
            this.labelInit.Location = new System.Drawing.Point(628, 124);
            this.labelInit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInit.Name = "labelInit";
            this.labelInit.Size = new System.Drawing.Size(50, 13);
            this.labelInit.TabIndex = 51;
            this.labelInit.Text = "Initialized";
            // 
            // textBoxSlit
            // 
            this.textBoxSlit.Location = new System.Drawing.Point(290, 100);
            this.textBoxSlit.Name = "textBoxSlit";
            this.textBoxSlit.Size = new System.Drawing.Size(51, 20);
            this.textBoxSlit.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 26);
            this.label12.TabIndex = 53;
            this.label12.Text = "Slit width\r\n (nm)";
            // 
            // PositionMode
            // 
            this.PositionMode.AutoSize = true;
            this.PositionMode.Location = new System.Drawing.Point(420, 305);
            this.PositionMode.Margin = new System.Windows.Forms.Padding(2);
            this.PositionMode.Name = "PositionMode";
            this.PositionMode.Size = new System.Drawing.Size(62, 17);
            this.PositionMode.TabIndex = 2;
            this.PositionMode.Text = "Position";
            this.PositionMode.UseVisualStyleBackColor = true;
            this.PositionMode.CheckedChanged += new System.EventHandler(this.PositionMode_CheckedChanged);
            // 
            // RangeMode
            // 
            this.RangeMode.AutoSize = true;
            this.RangeMode.Checked = true;
            this.RangeMode.Location = new System.Drawing.Point(420, 340);
            this.RangeMode.Margin = new System.Windows.Forms.Padding(2);
            this.RangeMode.Name = "RangeMode";
            this.RangeMode.Size = new System.Drawing.Size(57, 17);
            this.RangeMode.TabIndex = 2;
            this.RangeMode.TabStop = true;
            this.RangeMode.Text = "Range";
            this.RangeMode.UseVisualStyleBackColor = true;
            this.RangeMode.CheckedChanged += new System.EventHandler(this.RangeMode_CheckedChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(312, 316);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 54;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(498, 305);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Central Position (nm)";
            // 
            // textBoxCentral
            // 
            this.textBoxCentral.Enabled = false;
            this.textBoxCentral.Location = new System.Drawing.Point(606, 302);
            this.textBoxCentral.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCentral.Name = "textBoxCentral";
            this.textBoxCentral.Size = new System.Drawing.Size(57, 20);
            this.textBoxCentral.TabIndex = 56;
            this.textBoxCentral.Text = "300";
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCentral);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.RangeMode);
            this.Controls.Add(this.PositionMode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxSlit);
            this.Controls.Add(this.labelInit);
            this.Controls.Add(this.buttonInit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.OpenPathDialog);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textSample);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelMaxTask);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelFinishTasks);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonSaveProfile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboNDF2pos);
            this.Controls.Add(this.comboNDF1pos);
            this.Controls.Add(this.textBoxExp);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.listBoxTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoForm";
            this.Text = "AutoForm";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.TextBox textBoxExp;
        private System.Windows.Forms.ComboBox comboNDF2pos;
        private System.Windows.Forms.ComboBox comboNDF1pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveProfile;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelFinishTasks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMaxTask;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textSample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OpenPathDialog;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton Image;
        private System.Windows.Forms.RadioButton Spectra;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.Label labelInit;
        private System.Windows.Forms.TextBox textBoxSlit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton PositionMode;
        private System.Windows.Forms.RadioButton RangeMode;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxCentral;
    }
}