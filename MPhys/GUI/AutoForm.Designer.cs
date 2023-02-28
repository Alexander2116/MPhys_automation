
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
            this.label4.Size = new System.Drawing.Size(51, 26);
            this.label4.TabIndex = 26;
            this.label4.Text = "Exposure\r\nTime (s)";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(301, 98);
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
            this.label5.Size = new System.Drawing.Size(194, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "No.  |  Temp  |  pos1  |  pos2  |  Ext Time";
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
            this.buttonRun.Location = new System.Drawing.Point(615, 305);
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
            this.labelFinishTasks.Location = new System.Drawing.Point(555, 310);
            this.labelFinishTasks.Name = "labelFinishTasks";
            this.labelFinishTasks.Size = new System.Drawing.Size(13, 13);
            this.labelFinishTasks.TabIndex = 32;
            this.labelFinishTasks.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(574, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "of";
            // 
            // labelMaxTask
            // 
            this.labelMaxTask.AutoSize = true;
            this.labelMaxTask.Location = new System.Drawing.Point(587, 310);
            this.labelMaxTask.Name = "labelMaxTask";
            this.labelMaxTask.Size = new System.Drawing.Size(13, 13);
            this.labelMaxTask.TabIndex = 34;
            this.labelMaxTask.Text = "0";
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(56, 212);
            this.Count.Margin = new System.Windows.Forms.Padding(2);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(39, 20);
            this.Count.TabIndex = 36;
            this.Count.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 212);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Count:";
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}