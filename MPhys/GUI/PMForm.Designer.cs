
namespace MPhys.GUI
{
    partial class PMForm
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
            this.textBoxPower = new System.Windows.Forms.TextBox();
            this.textPMconnection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonComSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonSetCorr = new System.Windows.Forms.Button();
            this.textCorr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxConnSet = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(613, 159);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.ReadOnly = true;
            this.textBoxPower.Size = new System.Drawing.Size(67, 20);
            this.textBoxPower.TabIndex = 0;
            // 
            // textPMconnection
            // 
            this.textPMconnection.Location = new System.Drawing.Point(184, 69);
            this.textPMconnection.Name = "textPMconnection";
            this.textPMconnection.ReadOnly = true;
            this.textPMconnection.Size = new System.Drawing.Size(357, 20);
            this.textPMconnection.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "USB[board]::0x1313::product id::serial number[::interface number][::INSTR]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current communication";
            // 
            // buttonComSet
            // 
            this.buttonComSet.Enabled = false;
            this.buttonComSet.Location = new System.Drawing.Point(547, 93);
            this.buttonComSet.Name = "buttonComSet";
            this.buttonComSet.Size = new System.Drawing.Size(75, 23);
            this.buttonComSet.TabIndex = 5;
            this.buttonComSet.Text = "Set";
            this.buttonComSet.UseVisualStyleBackColor = true;
            this.buttonComSet.Click += new System.EventHandler(this.buttonComSet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Power (uW)";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(113, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Set com";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonSetCorr
            // 
            this.buttonSetCorr.Enabled = false;
            this.buttonSetCorr.Location = new System.Drawing.Point(211, 179);
            this.buttonSetCorr.Name = "buttonSetCorr";
            this.buttonSetCorr.Size = new System.Drawing.Size(75, 23);
            this.buttonSetCorr.TabIndex = 23;
            this.buttonSetCorr.Text = "Set";
            this.buttonSetCorr.UseVisualStyleBackColor = true;
            this.buttonSetCorr.Click += new System.EventHandler(this.buttonSetCorr_Click);
            // 
            // textCorr
            // 
            this.textCorr.Enabled = false;
            this.textCorr.Location = new System.Drawing.Point(128, 181);
            this.textCorr.Name = "textCorr";
            this.textCorr.Size = new System.Drawing.Size(77, 20);
            this.textCorr.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Set correction\r\nwavelength (nm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Write";
            // 
            // comboBoxConnSet
            // 
            this.comboBoxConnSet.FormattingEnabled = true;
            this.comboBoxConnSet.Location = new System.Drawing.Point(184, 95);
            this.comboBoxConnSet.Name = "comboBoxConnSet";
            this.comboBoxConnSet.Size = new System.Drawing.Size(357, 21);
            this.comboBoxConnSet.TabIndex = 24;
            // 
            // PMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxConnSet);
            this.Controls.Add(this.buttonSetCorr);
            this.Controls.Add(this.textCorr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonComSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPMconnection);
            this.Controls.Add(this.textBoxPower);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMForm";
            this.Text = "PMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPower;
        private System.Windows.Forms.TextBox textPMconnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonComSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonSetCorr;
        private System.Windows.Forms.TextBox textCorr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxConnSet;
    }
}