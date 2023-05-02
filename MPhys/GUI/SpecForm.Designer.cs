
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
            this.comboBoxMonos = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.button_shutter = new System.Windows.Forms.Button();
            this.ShutterLabel = new System.Windows.Forms.Label();
            this.ShutterStateLabel = new System.Windows.Forms.Label();
            this.groupboxWlCtrl = new System.Windows.Forms.GroupBox();
            this.comboboxGrating = new System.Windows.Forms.ComboBox();
            this.labelGrating = new System.Windows.Forms.Label();
            this.textboxPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.GroupBoxAcquire = new System.Windows.Forms.GroupBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.Update_Renamed = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.StatusMessage = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.GroupBoxStreamAcq = new System.Windows.Forms.GroupBox();
            this.OpenPathDialog = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.GoBtn = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Option3 = new System.Windows.Forms.RadioButton();
            this.Option2 = new System.Windows.Forms.RadioButton();
            this.Option1 = new System.Windows.Forms.RadioButton();
            this.StatusLabelCCD = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBoxCCDs = new System.Windows.Forms.ComboBox();
            this.buttonCDDInit = new System.Windows.Forms.Button();
            this.groupBoxCollect = new System.Windows.Forms.GroupBox();
            this.checkBoxContinuous = new System.Windows.Forms.CheckBox();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.checkBoxSyncAcq = new System.Windows.Forms.CheckBox();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonCCDSet = new System.Windows.Forms.Button();
            this.buttonMonoSet = new System.Windows.Forms.Button();
            this.labelCCDID = new System.Windows.Forms.Label();
            this.labelMonoID = new System.Windows.Forms.Label();
            this.labelCCDName = new System.Windows.Forms.Label();
            this.labelMonoName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ADCSelect = new System.Windows.Forms.ComboBox();
            this.GainList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveGainADC = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Image = new System.Windows.Forms.RadioButton();
            this.Spectra = new System.Windows.Forms.RadioButton();
            this.groupboxWlCtrl.SuspendLayout();
            this.GroupBoxAcquire.SuspendLayout();
            this.GroupBoxStreamAcq.SuspendLayout();
            this.groupBoxCollect.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonComSet
            // 
            this.buttonComSet.Location = new System.Drawing.Point(467, 27);
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
            this.checkBox1.Location = new System.Drawing.Point(18, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Set Mono.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxMonos
            // 
            this.comboBoxMonos.Enabled = false;
            this.comboBoxMonos.FormattingEnabled = true;
            this.comboBoxMonos.Location = new System.Drawing.Point(99, 25);
            this.comboBoxMonos.Name = "comboBoxMonos";
            this.comboBoxMonos.Size = new System.Drawing.Size(54, 21);
            this.comboBoxMonos.TabIndex = 21;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(388, 32);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(73, 13);
            this.StatusLabel.TabIndex = 23;
            this.StatusLabel.Text = "Disconnected";
            // 
            // button_shutter
            // 
            this.button_shutter.Enabled = false;
            this.button_shutter.Location = new System.Drawing.Point(653, 27);
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
            this.ShutterLabel.Location = new System.Drawing.Point(555, 32);
            this.ShutterLabel.Name = "ShutterLabel";
            this.ShutterLabel.Size = new System.Drawing.Size(44, 13);
            this.ShutterLabel.TabIndex = 25;
            this.ShutterLabel.Text = "Shutter:";
            // 
            // ShutterStateLabel
            // 
            this.ShutterStateLabel.AutoSize = true;
            this.ShutterStateLabel.Location = new System.Drawing.Point(603, 32);
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
            this.groupboxWlCtrl.Location = new System.Drawing.Point(26, 97);
            this.groupboxWlCtrl.Name = "groupboxWlCtrl";
            this.groupboxWlCtrl.Size = new System.Drawing.Size(248, 78);
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
            // GroupBoxAcquire
            // 
            this.GroupBoxAcquire.Controls.Add(this.SaveBtn);
            this.GroupBoxAcquire.Controls.Add(this.Update_Renamed);
            this.GroupBoxAcquire.Controls.Add(this.label20);
            this.GroupBoxAcquire.Controls.Add(this.StatusMessage);
            this.GroupBoxAcquire.Controls.Add(this.label19);
            this.GroupBoxAcquire.Controls.Add(this.StartBtn);
            this.GroupBoxAcquire.Enabled = false;
            this.GroupBoxAcquire.Location = new System.Drawing.Point(278, 97);
            this.GroupBoxAcquire.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBoxAcquire.Name = "GroupBoxAcquire";
            this.GroupBoxAcquire.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBoxAcquire.Size = new System.Drawing.Size(151, 180);
            this.GroupBoxAcquire.TabIndex = 29;
            this.GroupBoxAcquire.TabStop = false;
            this.GroupBoxAcquire.Text = "Acquire";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(44, 141);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(76, 25);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save Data";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Update_Renamed
            // 
            this.Update_Renamed.AutoSize = true;
            this.Update_Renamed.Location = new System.Drawing.Point(8, 114);
            this.Update_Renamed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Update_Renamed.Name = "Update_Renamed";
            this.Update_Renamed.Size = new System.Drawing.Size(27, 13);
            this.Update_Renamed.TabIndex = 4;
            this.Update_Renamed.Text = "N/A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 98);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Update:";
            // 
            // StatusMessage
            // 
            this.StatusMessage.AutoSize = true;
            this.StatusMessage.Location = new System.Drawing.Point(8, 65);
            this.StatusMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(27, 13);
            this.StatusMessage.TabIndex = 2;
            this.StatusMessage.Text = "N/A";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 49);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Status:";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(82, 16);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(53, 25);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // GroupBoxStreamAcq
            // 
            this.GroupBoxStreamAcq.Controls.Add(this.OpenPathDialog);
            this.GroupBoxStreamAcq.Controls.Add(this.label26);
            this.GroupBoxStreamAcq.Controls.Add(this.GoBtn);
            this.GroupBoxStreamAcq.Controls.Add(this.FileName);
            this.GroupBoxStreamAcq.Controls.Add(this.label13);
            this.GroupBoxStreamAcq.Controls.Add(this.label12);
            this.GroupBoxStreamAcq.Controls.Add(this.Count);
            this.GroupBoxStreamAcq.Controls.Add(this.label10);
            this.GroupBoxStreamAcq.Controls.Add(this.Option3);
            this.GroupBoxStreamAcq.Controls.Add(this.Option2);
            this.GroupBoxStreamAcq.Controls.Add(this.Option1);
            this.GroupBoxStreamAcq.Enabled = false;
            this.GroupBoxStreamAcq.Location = new System.Drawing.Point(27, 276);
            this.GroupBoxStreamAcq.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBoxStreamAcq.Name = "GroupBoxStreamAcq";
            this.GroupBoxStreamAcq.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBoxStreamAcq.Size = new System.Drawing.Size(248, 163);
            this.GroupBoxStreamAcq.TabIndex = 28;
            this.GroupBoxStreamAcq.TabStop = false;
            this.GroupBoxStreamAcq.Text = "Stream Acquisition";
            // 
            // OpenPathDialog
            // 
            this.OpenPathDialog.Location = new System.Drawing.Point(56, 95);
            this.OpenPathDialog.Name = "OpenPathDialog";
            this.OpenPathDialog.Size = new System.Drawing.Size(47, 23);
            this.OpenPathDialog.TabIndex = 10;
            this.OpenPathDialog.Text = "Open";
            this.OpenPathDialog.UseVisualStyleBackColor = true;
            this.OpenPathDialog.Click += new System.EventHandler(this.OpenPathDialog_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(204, 73);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "N/A";
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(188, 16);
            this.GoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(53, 25);
            this.GoBtn.TabIndex = 9;
            this.GoBtn.Text = "Go";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(0, 123);
            this.FileName.Margin = new System.Windows.Forms.Padding(2);
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Size = new System.Drawing.Size(248, 20);
            this.FileName.TabIndex = 8;
            this.FileName.Text = "c:\\temp\\mydata.txt";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 100);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "File Path:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(158, 73);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Iteration:";
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(52, 73);
            this.Count.Margin = new System.Windows.Forms.Padding(2);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(39, 20);
            this.Count.TabIndex = 4;
            this.Count.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Count:";
            // 
            // Option3
            // 
            this.Option3.AutoSize = true;
            this.Option3.Location = new System.Drawing.Point(8, 49);
            this.Option3.Margin = new System.Windows.Forms.Padding(2);
            this.Option3.Name = "Option3";
            this.Option3.Size = new System.Drawing.Size(86, 17);
            this.Option3.TabIndex = 2;
            this.Option3.Text = "Save to Files";
            this.Option3.UseVisualStyleBackColor = true;
            // 
            // Option2
            // 
            this.Option2.AutoSize = true;
            this.Option2.Location = new System.Drawing.Point(8, 32);
            this.Option2.Margin = new System.Windows.Forms.Padding(2);
            this.Option2.Name = "Option2";
            this.Option2.Size = new System.Drawing.Size(102, 17);
            this.Option2.TabIndex = 1;
            this.Option2.Text = "Save to Memory";
            this.Option2.UseVisualStyleBackColor = true;
            // 
            // Option1
            // 
            this.Option1.AutoSize = true;
            this.Option1.Checked = true;
            this.Option1.Location = new System.Drawing.Point(8, 16);
            this.Option1.Margin = new System.Windows.Forms.Padding(2);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(83, 17);
            this.Option1.TabIndex = 0;
            this.Option1.TabStop = true;
            this.Option1.Text = "Simple Loop";
            this.Option1.UseVisualStyleBackColor = true;
            // 
            // StatusLabelCCD
            // 
            this.StatusLabelCCD.AutoSize = true;
            this.StatusLabelCCD.ForeColor = System.Drawing.Color.Red;
            this.StatusLabelCCD.Location = new System.Drawing.Point(388, 61);
            this.StatusLabelCCD.Name = "StatusLabelCCD";
            this.StatusLabelCCD.Size = new System.Drawing.Size(73, 13);
            this.StatusLabelCCD.TabIndex = 33;
            this.StatusLabelCCD.Text = "Disconnected";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Set CCD";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBoxCCDs
            // 
            this.comboBoxCCDs.Enabled = false;
            this.comboBoxCCDs.FormattingEnabled = true;
            this.comboBoxCCDs.Location = new System.Drawing.Point(99, 54);
            this.comboBoxCCDs.Name = "comboBoxCCDs";
            this.comboBoxCCDs.Size = new System.Drawing.Size(54, 21);
            this.comboBoxCCDs.TabIndex = 31;
            // 
            // buttonCDDInit
            // 
            this.buttonCDDInit.Location = new System.Drawing.Point(467, 56);
            this.buttonCDDInit.Name = "buttonCDDInit";
            this.buttonCDDInit.Size = new System.Drawing.Size(75, 23);
            this.buttonCDDInit.TabIndex = 30;
            this.buttonCDDInit.Text = "Initialize";
            this.buttonCDDInit.UseVisualStyleBackColor = true;
            this.buttonCDDInit.Click += new System.EventHandler(this.buttonCDDInit_Click);
            // 
            // groupBoxCollect
            // 
            this.groupBoxCollect.Controls.Add(this.checkBoxContinuous);
            this.groupBoxCollect.Controls.Add(this.listBoxData);
            this.groupBoxCollect.Controls.Add(this.Label14);
            this.groupBoxCollect.Controls.Add(this.checkBoxSyncAcq);
            this.groupBoxCollect.Controls.Add(this.buttonAbort);
            this.groupBoxCollect.Controls.Add(this.buttonGo);
            this.groupBoxCollect.Enabled = false;
            this.groupBoxCollect.Location = new System.Drawing.Point(433, 97);
            this.groupBoxCollect.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxCollect.Name = "groupBoxCollect";
            this.groupBoxCollect.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxCollect.Size = new System.Drawing.Size(308, 180);
            this.groupBoxCollect.TabIndex = 34;
            this.groupBoxCollect.TabStop = false;
            this.groupBoxCollect.Text = "Collect";
            // 
            // checkBoxContinuous
            // 
            this.checkBoxContinuous.AutoSize = true;
            this.checkBoxContinuous.Location = new System.Drawing.Point(26, 60);
            this.checkBoxContinuous.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxContinuous.Name = "checkBoxContinuous";
            this.checkBoxContinuous.Size = new System.Drawing.Size(79, 17);
            this.checkBoxContinuous.TabIndex = 16;
            this.checkBoxContinuous.Text = "Continuous";
            this.checkBoxContinuous.UseVisualStyleBackColor = true;
            // 
            // listBoxData
            // 
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.Location = new System.Drawing.Point(159, 35);
            this.listBoxData.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(140, 134);
            this.listBoxData.TabIndex = 15;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(159, 19);
            this.Label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(30, 13);
            this.Label14.TabIndex = 14;
            this.Label14.Text = "Data";
            // 
            // checkBoxSyncAcq
            // 
            this.checkBoxSyncAcq.AutoSize = true;
            this.checkBoxSyncAcq.Location = new System.Drawing.Point(26, 31);
            this.checkBoxSyncAcq.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSyncAcq.Name = "checkBoxSyncAcq";
            this.checkBoxSyncAcq.Size = new System.Drawing.Size(113, 17);
            this.checkBoxSyncAcq.TabIndex = 13;
            this.checkBoxSyncAcq.Text = "Synchronous Acq.";
            this.checkBoxSyncAcq.UseVisualStyleBackColor = true;
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(50, 142);
            this.buttonAbort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(56, 23);
            this.buttonAbort.TabIndex = 12;
            this.buttonAbort.Text = "ABORT";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(46, 102);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(63, 23);
            this.buttonGo.TabIndex = 11;
            this.buttonGo.Text = "GO";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonCCDSet
            // 
            this.buttonCCDSet.Location = new System.Drawing.Point(159, 54);
            this.buttonCCDSet.Name = "buttonCCDSet";
            this.buttonCCDSet.Size = new System.Drawing.Size(50, 23);
            this.buttonCCDSet.TabIndex = 36;
            this.buttonCCDSet.Text = "Set";
            this.buttonCCDSet.UseVisualStyleBackColor = true;
            this.buttonCCDSet.Click += new System.EventHandler(this.buttonCCDSet_Click);
            // 
            // buttonMonoSet
            // 
            this.buttonMonoSet.Location = new System.Drawing.Point(159, 25);
            this.buttonMonoSet.Name = "buttonMonoSet";
            this.buttonMonoSet.Size = new System.Drawing.Size(50, 23);
            this.buttonMonoSet.TabIndex = 35;
            this.buttonMonoSet.Text = "Set";
            this.buttonMonoSet.UseVisualStyleBackColor = true;
            this.buttonMonoSet.Click += new System.EventHandler(this.buttonMonoSet_Click);
            // 
            // labelCCDID
            // 
            this.labelCCDID.AutoSize = true;
            this.labelCCDID.ForeColor = System.Drawing.Color.Black;
            this.labelCCDID.Location = new System.Drawing.Point(306, 61);
            this.labelCCDID.Name = "labelCCDID";
            this.labelCCDID.Size = new System.Drawing.Size(43, 13);
            this.labelCCDID.TabIndex = 38;
            this.labelCCDID.Text = "CCD ID";
            // 
            // labelMonoID
            // 
            this.labelMonoID.AutoSize = true;
            this.labelMonoID.ForeColor = System.Drawing.Color.Black;
            this.labelMonoID.Location = new System.Drawing.Point(306, 32);
            this.labelMonoID.Name = "labelMonoID";
            this.labelMonoID.Size = new System.Drawing.Size(48, 13);
            this.labelMonoID.TabIndex = 37;
            this.labelMonoID.Text = "Mono ID";
            // 
            // labelCCDName
            // 
            this.labelCCDName.AutoSize = true;
            this.labelCCDName.ForeColor = System.Drawing.Color.Black;
            this.labelCCDName.Location = new System.Drawing.Point(215, 60);
            this.labelCCDName.Name = "labelCCDName";
            this.labelCCDName.Size = new System.Drawing.Size(60, 13);
            this.labelCCDName.TabIndex = 40;
            this.labelCCDName.Text = "CCD Name";
            // 
            // labelMonoName
            // 
            this.labelMonoName.AutoSize = true;
            this.labelMonoName.ForeColor = System.Drawing.Color.Black;
            this.labelMonoName.Location = new System.Drawing.Point(215, 31);
            this.labelMonoName.Name = "labelMonoName";
            this.labelMonoName.Size = new System.Drawing.Size(65, 13);
            this.labelMonoName.TabIndex = 39;
            this.labelMonoName.Text = "Mono Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Mono Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(306, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Mono ID";
            // 
            // ADCSelect
            // 
            this.ADCSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ADCSelect.FormattingEnabled = true;
            this.ADCSelect.Location = new System.Drawing.Point(54, 211);
            this.ADCSelect.Margin = new System.Windows.Forms.Padding(2);
            this.ADCSelect.Name = "ADCSelect";
            this.ADCSelect.Size = new System.Drawing.Size(99, 21);
            this.ADCSelect.TabIndex = 44;
            // 
            // GainList
            // 
            this.GainList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GainList.FormattingEnabled = true;
            this.GainList.Location = new System.Drawing.Point(54, 187);
            this.GainList.Margin = new System.Windows.Forms.Padding(2);
            this.GainList.Name = "GainList";
            this.GainList.Size = new System.Drawing.Size(122, 21);
            this.GainList.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "ADC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Gain";
            // 
            // buttonSaveGainADC
            // 
            this.buttonSaveGainADC.Location = new System.Drawing.Point(188, 199);
            this.buttonSaveGainADC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveGainADC.Name = "buttonSaveGainADC";
            this.buttonSaveGainADC.Size = new System.Drawing.Size(53, 25);
            this.buttonSaveGainADC.TabIndex = 11;
            this.buttonSaveGainADC.Text = "Save";
            this.buttonSaveGainADC.UseVisualStyleBackColor = true;
            this.buttonSaveGainADC.Click += new System.EventHandler(this.buttonSaveGainADC_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Image);
            this.groupBox4.Controls.Add(this.Spectra);
            this.groupBox4.Location = new System.Drawing.Point(278, 281);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(136, 54);
            this.groupBox4.TabIndex = 47;
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
            // SpecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonSaveGainADC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ADCSelect);
            this.Controls.Add(this.GainList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCCDName);
            this.Controls.Add(this.labelMonoName);
            this.Controls.Add(this.labelCCDID);
            this.Controls.Add(this.labelMonoID);
            this.Controls.Add(this.buttonCCDSet);
            this.Controls.Add(this.buttonMonoSet);
            this.Controls.Add(this.groupBoxCollect);
            this.Controls.Add(this.StatusLabelCCD);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboBoxCCDs);
            this.Controls.Add(this.buttonCDDInit);
            this.Controls.Add(this.GroupBoxAcquire);
            this.Controls.Add(this.GroupBoxStreamAcq);
            this.Controls.Add(this.groupboxWlCtrl);
            this.Controls.Add(this.ShutterStateLabel);
            this.Controls.Add(this.ShutterLabel);
            this.Controls.Add(this.button_shutter);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBoxMonos);
            this.Controls.Add(this.buttonComSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecForm";
            this.Text = "SpecForm";
            this.groupboxWlCtrl.ResumeLayout(false);
            this.groupboxWlCtrl.PerformLayout();
            this.GroupBoxAcquire.ResumeLayout(false);
            this.GroupBoxAcquire.PerformLayout();
            this.GroupBoxStreamAcq.ResumeLayout(false);
            this.GroupBoxStreamAcq.PerformLayout();
            this.groupBoxCollect.ResumeLayout(false);
            this.groupBoxCollect.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonComSet;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxMonos;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button button_shutter;
        private System.Windows.Forms.Label ShutterLabel;
        private System.Windows.Forms.Label ShutterStateLabel;
        internal System.Windows.Forms.GroupBox groupboxWlCtrl;
        internal System.Windows.Forms.ComboBox comboboxGrating;
        internal System.Windows.Forms.Label labelGrating;
        internal System.Windows.Forms.TextBox textboxPosition;
        internal System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.GroupBox GroupBoxAcquire;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label Update_Renamed;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label StatusMessage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.GroupBox GroupBoxStreamAcq;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton Option3;
        private System.Windows.Forms.RadioButton Option2;
        private System.Windows.Forms.RadioButton Option1;
        private System.Windows.Forms.Label StatusLabelCCD;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBoxCCDs;
        private System.Windows.Forms.Button buttonCDDInit;
        internal System.Windows.Forms.GroupBox groupBoxCollect;
        private System.Windows.Forms.CheckBox checkBoxContinuous;
        internal System.Windows.Forms.ListBox listBoxData;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.CheckBox checkBoxSyncAcq;
        internal System.Windows.Forms.Button buttonAbort;
        internal System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button OpenPathDialog;
        private System.Windows.Forms.Button buttonCCDSet;
        private System.Windows.Forms.Button buttonMonoSet;
        private System.Windows.Forms.Label labelCCDID;
        private System.Windows.Forms.Label labelMonoID;
        private System.Windows.Forms.Label labelCCDName;
        private System.Windows.Forms.Label labelMonoName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ADCSelect;
        private System.Windows.Forms.ComboBox GainList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveGainADC;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton Image;
        private System.Windows.Forms.RadioButton Spectra;
    }
}