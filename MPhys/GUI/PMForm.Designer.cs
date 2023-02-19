
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
            this.textBoxConnSet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonComSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(184, 146);
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
            // textBoxConnSet
            // 
            this.textBoxConnSet.Enabled = false;
            this.textBoxConnSet.Location = new System.Drawing.Point(184, 95);
            this.textBoxConnSet.Name = "textBoxConnSet";
            this.textBoxConnSet.Size = new System.Drawing.Size(357, 20);
            this.textBoxConnSet.TabIndex = 3;
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
            this.label3.Location = new System.Drawing.Point(115, 149);
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
            // PMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonComSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxConnSet);
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
        private System.Windows.Forms.TextBox textBoxConnSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonComSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}