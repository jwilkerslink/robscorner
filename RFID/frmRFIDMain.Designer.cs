namespace RFID
{
    partial class frmRFIDMain
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
            this.bwNotifications = new System.ComponentModel.BackgroundWorker();
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bwListen = new System.ComponentModel.BackgroundWorker();
            this.tbMaster = new System.Windows.Forms.TabPage();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.tbTrack = new System.Windows.Forms.TabPage();
            this.lblTagCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTracker = new System.Windows.Forms.DataGridView();
            this.tbCommand = new System.Windows.Forms.TabPage();
            this.txtStream = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnTagList = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.tbTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).BeginInit();
            this.tbCommand.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwNotifications
            // 
            this.bwNotifications.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwNotifications_DoWork);
            this.bwNotifications.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwNotifications_RunWorkerCompleted);
            // 
            // bwConnect
            // 
            this.bwConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnect_DoWork);
            this.bwConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwConnect_RunWorkerCompleted);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(1142, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(18, 28);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "⚙";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1068, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "щ（ﾟДﾟщ）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bwListen
            // 
            this.bwListen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwListen_DoWork);
            // 
            // tbMaster
            // 
            this.tbMaster.Controls.Add(this.dgvMaster);
            this.tbMaster.Location = new System.Drawing.Point(4, 22);
            this.tbMaster.Name = "tbMaster";
            this.tbMaster.Size = new System.Drawing.Size(1143, 382);
            this.tbMaster.TabIndex = 3;
            this.tbMaster.Text = "Master List";
            this.tbMaster.UseVisualStyleBackColor = true;
            // 
            // dgvMaster
            // 
            this.dgvMaster.AllowUserToAddRows = false;
            this.dgvMaster.AllowUserToDeleteRows = false;
            this.dgvMaster.AllowUserToResizeColumns = false;
            this.dgvMaster.AllowUserToResizeRows = false;
            this.dgvMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Location = new System.Drawing.Point(2, 2);
            this.dgvMaster.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 62;
            this.dgvMaster.RowTemplate.Height = 28;
            this.dgvMaster.Size = new System.Drawing.Size(1137, 378);
            this.dgvMaster.TabIndex = 1;
            // 
            // tbTrack
            // 
            this.tbTrack.Controls.Add(this.lblTagCount);
            this.tbTrack.Controls.Add(this.label1);
            this.tbTrack.Controls.Add(this.dgvTracker);
            this.tbTrack.Location = new System.Drawing.Point(4, 22);
            this.tbTrack.Margin = new System.Windows.Forms.Padding(2);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Padding = new System.Windows.Forms.Padding(2);
            this.tbTrack.Size = new System.Drawing.Size(1143, 382);
            this.tbTrack.TabIndex = 1;
            this.tbTrack.Text = "Tracker";
            this.tbTrack.UseVisualStyleBackColor = true;
            // 
            // lblTagCount
            // 
            this.lblTagCount.AutoSize = true;
            this.lblTagCount.Location = new System.Drawing.Point(67, 365);
            this.lblTagCount.Name = "lblTagCount";
            this.lblTagCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTagCount.Size = new System.Drawing.Size(13, 13);
            this.lblTagCount.TabIndex = 2;
            this.lblTagCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "tags in list:";
            // 
            // dgvTracker
            // 
            this.dgvTracker.AllowUserToAddRows = false;
            this.dgvTracker.AllowUserToDeleteRows = false;
            this.dgvTracker.AllowUserToResizeColumns = false;
            this.dgvTracker.AllowUserToResizeRows = false;
            this.dgvTracker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTracker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracker.Location = new System.Drawing.Point(2, 2);
            this.dgvTracker.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTracker.Name = "dgvTracker";
            this.dgvTracker.ReadOnly = true;
            this.dgvTracker.RowHeadersWidth = 62;
            this.dgvTracker.RowTemplate.Height = 28;
            this.dgvTracker.Size = new System.Drawing.Size(1137, 361);
            this.dgvTracker.TabIndex = 0;
            this.dgvTracker.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTracker_CellContentDoubleClick);
            // 
            // tbCommand
            // 
            this.tbCommand.Controls.Add(this.txtStream);
            this.tbCommand.Controls.Add(this.txtCommand);
            this.tbCommand.Controls.Add(this.txtConsole);
            this.tbCommand.Controls.Add(this.button3);
            this.tbCommand.Controls.Add(this.btnTagList);
            this.tbCommand.Location = new System.Drawing.Point(4, 22);
            this.tbCommand.Margin = new System.Windows.Forms.Padding(2);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Padding = new System.Windows.Forms.Padding(2);
            this.tbCommand.Size = new System.Drawing.Size(1143, 382);
            this.tbCommand.TabIndex = 0;
            this.tbCommand.Text = "Command";
            this.tbCommand.UseVisualStyleBackColor = true;
            // 
            // txtStream
            // 
            this.txtStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStream.Location = new System.Drawing.Point(436, 0);
            this.txtStream.Margin = new System.Windows.Forms.Padding(2);
            this.txtStream.Multiline = true;
            this.txtStream.Name = "txtStream";
            this.txtStream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStream.Size = new System.Drawing.Size(703, 350);
            this.txtStream.TabIndex = 5;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(4, 356);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(1015, 20);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(-1, 0);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(446, 350);
            this.txtConsole.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1023, 355);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnTagList
            // 
            this.btnTagList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagList.Location = new System.Drawing.Point(1083, 355);
            this.btnTagList.Margin = new System.Windows.Forms.Padding(2);
            this.btnTagList.Name = "btnTagList";
            this.btnTagList.Size = new System.Drawing.Size(56, 23);
            this.btnTagList.TabIndex = 3;
            this.btnTagList.Text = "TagList";
            this.btnTagList.UseVisualStyleBackColor = true;
            this.btnTagList.Click += new System.EventHandler(this.btnTagList_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbCommand);
            this.tabControl1.Controls.Add(this.tbTrack);
            this.tabControl1.Controls.Add(this.tbMaster);
            this.tabControl1.Location = new System.Drawing.Point(8, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1151, 408);
            this.tabControl1.TabIndex = 5;
            // 
            // frmRFIDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 427);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRFIDMain";
            this.Text = "Glix";
            this.Load += new System.EventHandler(this.frmRFIDMain_Load);
            this.tbMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.tbTrack.ResumeLayout(false);
            this.tbTrack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).EndInit();
            this.tbCommand.ResumeLayout(false);
            this.tbCommand.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwNotifications;
        private System.ComponentModel.BackgroundWorker bwConnect;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker bwListen;
        private System.Windows.Forms.TabPage tbMaster;
        private System.Windows.Forms.TabPage tbTrack;
        private System.Windows.Forms.Label lblTagCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTracker;
        private System.Windows.Forms.TabPage tbCommand;
        private System.Windows.Forms.TextBox txtStream;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnTagList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView dgvMaster;
    }
}

