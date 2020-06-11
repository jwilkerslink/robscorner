namespace RFID
{
    partial class frmSettingsPane
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkRunSSMS = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPipe = new System.Windows.Forms.Label();
            this.btnConnectDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(82, 13);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(110, 20);
            this.txtIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TCP Port";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 20);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(82, 39);
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(38, 20);
            this.nudPort.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 62);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reader Connection Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 69);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reader Credentials";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(81, 37);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(110, 20);
            this.txtPass.TabIndex = 12;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(81, 13);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(110, 20);
            this.txtUser.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkRunSSMS);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblPipe);
            this.groupBox3.Controls.Add(this.btnConnectDB);
            this.groupBox3.Location = new System.Drawing.Point(16, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 59);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LocalDB";
            // 
            // chkRunSSMS
            // 
            this.chkRunSSMS.AutoSize = true;
            this.chkRunSSMS.Location = new System.Drawing.Point(89, 39);
            this.chkRunSSMS.Name = "chkRunSSMS";
            this.chkRunSSMS.Size = new System.Drawing.Size(74, 17);
            this.chkRunSSMS.TabIndex = 3;
            this.chkRunSSMS.Text = "run SSMS";
            this.chkRunSSMS.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "pipe:";
            // 
            // lblPipe
            // 
            this.lblPipe.AutoSize = true;
            this.lblPipe.Location = new System.Drawing.Point(116, 19);
            this.lblPipe.Name = "lblPipe";
            this.lblPipe.Size = new System.Drawing.Size(39, 13);
            this.lblPipe.TabIndex = 1;
            this.lblPipe.Text = "not set";
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(6, 19);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(63, 34);
            this.btnConnectDB.TabIndex = 0;
            this.btnConnectDB.Text = "Connect";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // frmSettingsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 235);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettingsPane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reader Settings";
            this.Load += new System.EventHandler(this.frmSettingsPane_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRunSSMS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPipe;
        private System.Windows.Forms.Button btnConnectDB;
    }
}