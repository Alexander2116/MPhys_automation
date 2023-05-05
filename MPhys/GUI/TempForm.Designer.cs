
namespace MPhys.GUI
{
    partial class TempForm
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
            this.buttonSet1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textM9700COM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textTempWrite = new System.Windows.Forms.TextBox();
            this.buttonSetTemp = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonPID = new System.Windows.Forms.Button();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxI = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxCL = new System.Windows.Forms.ComboBox();
            this.groupBoxPID = new System.Windows.Forms.GroupBox();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.buttonMode = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxPID.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSet1
            // 
            this.buttonSet1.Enabled = false;
            this.buttonSet1.Location = new System.Drawing.Point(315, 89);
            this.buttonSet1.Name = "buttonSet1";
            this.buttonSet1.Size = new System.Drawing.Size(75, 23);
            this.buttonSet1.TabIndex = 12;
            this.buttonSet1.Text = "Set";
            this.buttonSet1.UseVisualStyleBackColor = true;
            this.buttonSet1.Click += new System.EventHandler(this.buttonSet1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(255, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(54, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // textM9700COM
            // 
            this.textM9700COM.Location = new System.Drawing.Point(416, 46);
            this.textM9700COM.Name = "textM9700COM";
            this.textM9700COM.ReadOnly = true;
            this.textM9700COM.Size = new System.Drawing.Size(37, 20);
            this.textM9700COM.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "COM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "M9700 - temp controller";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(585, 152);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.ReadOnly = true;
            this.textBoxTemp.Size = new System.Drawing.Size(77, 20);
            this.textBoxTemp.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(582, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Read";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(150, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Write";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Temperature (K)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Set Temperature (K)";
            // 
            // textTempWrite
            // 
            this.textTempWrite.Enabled = false;
            this.textTempWrite.Location = new System.Drawing.Point(153, 152);
            this.textTempWrite.Name = "textTempWrite";
            this.textTempWrite.Size = new System.Drawing.Size(77, 20);
            this.textTempWrite.TabIndex = 18;
            // 
            // buttonSetTemp
            // 
            this.buttonSetTemp.Enabled = false;
            this.buttonSetTemp.Location = new System.Drawing.Point(236, 150);
            this.buttonSetTemp.Name = "buttonSetTemp";
            this.buttonSetTemp.Size = new System.Drawing.Size(75, 23);
            this.buttonSetTemp.TabIndex = 19;
            this.buttonSetTemp.Text = "Set";
            this.buttonSetTemp.UseVisualStyleBackColor = true;
            this.buttonSetTemp.Click += new System.EventHandler(this.buttonSetTemp_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(180, 93);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Set COM";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonPID
            // 
            this.buttonPID.Location = new System.Drawing.Point(168, 44);
            this.buttonPID.Name = "buttonPID";
            this.buttonPID.Size = new System.Drawing.Size(75, 23);
            this.buttonPID.TabIndex = 23;
            this.buttonPID.Text = "Set";
            this.buttonPID.UseVisualStyleBackColor = true;
            this.buttonPID.Click += new System.EventHandler(this.buttonPID_Click);
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(128, 45);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(34, 20);
            this.textBoxD.TabIndex = 26;
            this.textBoxD.Text = "ccc";
            // 
            // textBoxI
            // 
            this.textBoxI.Location = new System.Drawing.Point(88, 45);
            this.textBoxI.Name = "textBoxI";
            this.textBoxI.Size = new System.Drawing.Size(34, 20);
            this.textBoxI.TabIndex = 27;
            this.textBoxI.Text = "bbb";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(48, 45);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(34, 20);
            this.textBoxP.TabIndex = 28;
            this.textBoxP.Text = "aaa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "P";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(90, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "I";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(135, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "D";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 26);
            this.label11.TabIndex = 32;
            this.label11.Text = "Control\r\nloop";
            // 
            // comboBoxCL
            // 
            this.comboBoxCL.FormattingEnabled = true;
            this.comboBoxCL.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBoxCL.Location = new System.Drawing.Point(5, 44);
            this.comboBoxCL.Name = "comboBoxCL";
            this.comboBoxCL.Size = new System.Drawing.Size(37, 21);
            this.comboBoxCL.TabIndex = 33;
            // 
            // groupBoxPID
            // 
            this.groupBoxPID.Controls.Add(this.comboBoxCL);
            this.groupBoxPID.Controls.Add(this.label11);
            this.groupBoxPID.Controls.Add(this.label10);
            this.groupBoxPID.Controls.Add(this.label9);
            this.groupBoxPID.Controls.Add(this.label8);
            this.groupBoxPID.Controls.Add(this.textBoxP);
            this.groupBoxPID.Controls.Add(this.textBoxI);
            this.groupBoxPID.Controls.Add(this.textBoxD);
            this.groupBoxPID.Controls.Add(this.buttonPID);
            this.groupBoxPID.Enabled = false;
            this.groupBoxPID.Location = new System.Drawing.Point(29, 188);
            this.groupBoxPID.Name = "groupBoxPID";
            this.groupBoxPID.Size = new System.Drawing.Size(254, 82);
            this.groupBoxPID.TabIndex = 34;
            this.groupBoxPID.TabStop = false;
            this.groupBoxPID.Text = "PID";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.label7);
            this.groupBoxMode.Controls.Add(this.comboBoxModes);
            this.groupBoxMode.Controls.Add(this.buttonMode);
            this.groupBoxMode.Enabled = false;
            this.groupBoxMode.Location = new System.Drawing.Point(29, 276);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(254, 82);
            this.groupBoxMode.TabIndex = 35;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxModes.Location = new System.Drawing.Point(8, 29);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(37, 21);
            this.comboBoxModes.TabIndex = 33;
            // 
            // buttonMode
            // 
            this.buttonMode.Location = new System.Drawing.Point(48, 27);
            this.buttonMode.Name = "buttonMode";
            this.buttonMode.Size = new System.Drawing.Size(75, 23);
            this.buttonMode.TabIndex = 23;
            this.buttonMode.Text = "Set";
            this.buttonMode.UseVisualStyleBackColor = true;
            this.buttonMode.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 65);
            this.label7.TabIndex = 34;
            this.label7.Text = "1: Stop\r\n2: Manual\r\n3: Program\r\n4: AutoTune\r\n5: Fixed Output (?)";
            // 
            // TempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.groupBoxPID);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonSetTemp);
            this.Controls.Add(this.textTempWrite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.buttonSet1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textM9700COM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TempForm";
            this.Text = "TempForm";
            this.groupBoxPID.ResumeLayout(false);
            this.groupBoxPID.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSet1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textM9700COM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textTempWrite;
        private System.Windows.Forms.Button buttonSetTemp;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonPID;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxI;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxCL;
        internal System.Windows.Forms.GroupBox groupBoxPID;
        internal System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxModes;
        private System.Windows.Forms.Button buttonMode;
    }
}