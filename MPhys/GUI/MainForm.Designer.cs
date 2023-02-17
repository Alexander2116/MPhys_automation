
namespace MPhys.GUI
{
    partial class MainForm
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
            this.buttonNDF = new System.Windows.Forms.Button();
            this.buttonPM = new System.Windows.Forms.Button();
            this.buttonTemp = new System.Windows.Forms.Button();
            this.buttonSpec = new System.Windows.Forms.Button();
            this.buttonAuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNDF
            // 
            this.buttonNDF.Location = new System.Drawing.Point(0, 26);
            this.buttonNDF.Name = "buttonNDF";
            this.buttonNDF.Size = new System.Drawing.Size(60, 39);
            this.buttonNDF.TabIndex = 0;
            this.buttonNDF.Text = "NDFs";
            this.buttonNDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNDF.UseVisualStyleBackColor = true;
            this.buttonNDF.Click += new System.EventHandler(this.buttonNDF_Click);
            // 
            // buttonPM
            // 
            this.buttonPM.Location = new System.Drawing.Point(0, 65);
            this.buttonPM.Name = "buttonPM";
            this.buttonPM.Size = new System.Drawing.Size(60, 39);
            this.buttonPM.TabIndex = 1;
            this.buttonPM.Text = "PM";
            this.buttonPM.UseVisualStyleBackColor = true;
            this.buttonPM.Click += new System.EventHandler(this.buttonPM_Click);
            // 
            // buttonTemp
            // 
            this.buttonTemp.Location = new System.Drawing.Point(0, 104);
            this.buttonTemp.Name = "buttonTemp";
            this.buttonTemp.Size = new System.Drawing.Size(60, 39);
            this.buttonTemp.TabIndex = 2;
            this.buttonTemp.Text = "Temp";
            this.buttonTemp.UseVisualStyleBackColor = true;
            this.buttonTemp.Click += new System.EventHandler(this.buttonTemp_Click);
            // 
            // buttonSpec
            // 
            this.buttonSpec.Location = new System.Drawing.Point(0, 143);
            this.buttonSpec.Name = "buttonSpec";
            this.buttonSpec.Size = new System.Drawing.Size(60, 39);
            this.buttonSpec.TabIndex = 3;
            this.buttonSpec.Text = "Spectrometer";
            this.buttonSpec.UseVisualStyleBackColor = true;
            this.buttonSpec.Click += new System.EventHandler(this.buttonSpec_Click);
            // 
            // buttonAuto
            // 
            this.buttonAuto.Location = new System.Drawing.Point(0, 182);
            this.buttonAuto.Name = "buttonAuto";
            this.buttonAuto.Size = new System.Drawing.Size(60, 39);
            this.buttonAuto.TabIndex = 4;
            this.buttonAuto.Text = "Auto";
            this.buttonAuto.UseVisualStyleBackColor = true;
            this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 921);
            this.Controls.Add(this.buttonAuto);
            this.Controls.Add(this.buttonSpec);
            this.Controls.Add(this.buttonTemp);
            this.Controls.Add(this.buttonPM);
            this.Controls.Add(this.buttonNDF);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNDF;
        private System.Windows.Forms.Button buttonPM;
        private System.Windows.Forms.Button buttonTemp;
        private System.Windows.Forms.Button buttonSpec;
        private System.Windows.Forms.Button buttonAuto;
    }
}