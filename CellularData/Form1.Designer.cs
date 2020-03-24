namespace CellularData
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblMDN = new System.Windows.Forms.Label();
            this.lblMEID = new System.Windows.Forms.Label();
            this.lblSIM = new System.Windows.Forms.Label();
            this.lblSN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MDN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "MEID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "SIMID:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(185, 17);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "...";
            // 
            // lblMDN
            // 
            this.lblMDN.AutoSize = true;
            this.lblMDN.Location = new System.Drawing.Point(94, 88);
            this.lblMDN.Name = "lblMDN";
            this.lblMDN.Size = new System.Drawing.Size(16, 13);
            this.lblMDN.TabIndex = 2;
            this.lblMDN.Text = "...";
            // 
            // lblMEID
            // 
            this.lblMEID.AutoSize = true;
            this.lblMEID.Location = new System.Drawing.Point(94, 140);
            this.lblMEID.Name = "lblMEID";
            this.lblMEID.Size = new System.Drawing.Size(16, 13);
            this.lblMEID.TabIndex = 2;
            this.lblMEID.Text = "...";
            // 
            // lblSIM
            // 
            this.lblSIM.AutoSize = true;
            this.lblSIM.Location = new System.Drawing.Point(94, 196);
            this.lblSIM.Name = "lblSIM";
            this.lblSIM.Size = new System.Drawing.Size(16, 13);
            this.lblSIM.TabIndex = 2;
            this.lblSIM.Text = "...";
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.Location = new System.Drawing.Point(94, 45);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(16, 13);
            this.lblSN.TabIndex = 2;
            this.lblSN.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 225);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.lblSIM);
            this.Controls.Add(this.lblMEID);
            this.Controls.Add(this.lblMDN);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblMDN;
        private System.Windows.Forms.Label lblMEID;
        private System.Windows.Forms.Label lblSIM;
        private System.Windows.Forms.Label lblSN;
    }
}

