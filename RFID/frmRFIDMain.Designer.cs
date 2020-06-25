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
            System.Windows.Forms.DataGridView dataGridView1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.coltagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnTagList = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bwNotifications = new System.ComponentModel.BackgroundWorker();
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbNotify = new System.Windows.Forms.TabPage();
            this.txtStream = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tbTrack = new System.Windows.Forms.TabPage();
            this.dgvTracker = new System.Windows.Forms.DataGridView();
            this.tbUnitHistory = new System.Windows.Forms.TabPage();
            this.dgvUnitHistory = new System.Windows.Forms.DataGridView();
            this.txtUnitHistory = new System.Windows.Forms.TextBox();
            this.tbPrefect = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnStartCollection = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bwListen = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTagCount = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbNotify.SuspendLayout();
            this.tbTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).BeginInit();
            this.tbUnitHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitHistory)).BeginInit();
            this.tbPrefect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltagID,
            this.colCount,
            this.colRPS,
            this.colStatus,
            this.colDateAdded,
            this.colKown});
            dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new System.Drawing.Point(0, 1);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new System.Drawing.Size(885, 339);
            dataGridView1.TabIndex = 0;
            // 
            // coltagID
            // 
            this.coltagID.HeaderText = "Tag ID";
            this.coltagID.Name = "coltagID";
            // 
            // colCount
            // 
            this.colCount.HeaderText = "Read Count";
            this.colCount.Name = "colCount";
            // 
            // colRPS
            // 
            this.colRPS.HeaderText = "RPS";
            this.colRPS.Name = "colRPS";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colDateAdded
            // 
            this.colDateAdded.HeaderText = "Added";
            this.colDateAdded.Name = "colDateAdded";
            // 
            // colKown
            // 
            this.colKown.HeaderText = "Known?";
            this.colKown.Name = "colKown";
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
            // btnTagList
            // 
            this.btnTagList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTagList.Location = new System.Drawing.Point(825, 355);
            this.btnTagList.Margin = new System.Windows.Forms.Padding(2);
            this.btnTagList.Name = "btnTagList";
            this.btnTagList.Size = new System.Drawing.Size(56, 23);
            this.btnTagList.TabIndex = 3;
            this.btnTagList.Text = "TagList";
            this.btnTagList.UseVisualStyleBackColor = true;
            this.btnTagList.Click += new System.EventHandler(this.btnTagList_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(765, 355);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbNotify);
            this.tabControl1.Controls.Add(this.tbTrack);
            this.tabControl1.Controls.Add(this.tbUnitHistory);
            this.tabControl1.Controls.Add(this.tbPrefect);
            this.tabControl1.Location = new System.Drawing.Point(8, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1151, 408);
            this.tabControl1.TabIndex = 5;
            // 
            // tbNotify
            // 
            this.tbNotify.Controls.Add(this.txtStream);
            this.tbNotify.Controls.Add(this.txtCommand);
            this.tbNotify.Controls.Add(this.button3);
            this.tbNotify.Controls.Add(this.btnTagList);
            this.tbNotify.Controls.Add(this.txtConsole);
            this.tbNotify.Location = new System.Drawing.Point(4, 22);
            this.tbNotify.Margin = new System.Windows.Forms.Padding(2);
            this.tbNotify.Name = "tbNotify";
            this.tbNotify.Padding = new System.Windows.Forms.Padding(2);
            this.tbNotify.Size = new System.Drawing.Size(886, 382);
            this.tbNotify.TabIndex = 0;
            this.tbNotify.Text = "Notifications";
            this.tbNotify.UseVisualStyleBackColor = true;
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
            this.txtStream.Size = new System.Drawing.Size(454, 350);
            this.txtStream.TabIndex = 5;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(4, 356);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(757, 20);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
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
            this.dgvTracker.RowHeadersWidth = 62;
            this.dgvTracker.RowTemplate.Height = 28;
            this.dgvTracker.Size = new System.Drawing.Size(1137, 361);
            this.dgvTracker.TabIndex = 0;
            // 
            // tbUnitHistory
            // 
            this.tbUnitHistory.Controls.Add(this.dgvUnitHistory);
            this.tbUnitHistory.Controls.Add(this.txtUnitHistory);
            this.tbUnitHistory.Controls.Add(this.button1);
            this.tbUnitHistory.Location = new System.Drawing.Point(4, 22);
            this.tbUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.tbUnitHistory.Name = "tbUnitHistory";
            this.tbUnitHistory.Size = new System.Drawing.Size(881, 382);
            this.tbUnitHistory.TabIndex = 2;
            this.tbUnitHistory.Text = "UnitHistory";
            this.tbUnitHistory.UseVisualStyleBackColor = true;
            // 
            // dgvUnitHistory
            // 
            this.dgvUnitHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnitHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnitHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnitHistory.Location = new System.Drawing.Point(0, 24);
            this.dgvUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUnitHistory.Name = "dgvUnitHistory";
            this.dgvUnitHistory.RowHeadersWidth = 62;
            this.dgvUnitHistory.RowTemplate.Height = 28;
            this.dgvUnitHistory.Size = new System.Drawing.Size(876, 340);
            this.dgvUnitHistory.TabIndex = 3;
            // 
            // txtUnitHistory
            // 
            this.txtUnitHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUnitHistory.Location = new System.Drawing.Point(0, 0);
            this.txtUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitHistory.Name = "txtUnitHistory";
            this.txtUnitHistory.Size = new System.Drawing.Size(300, 20);
            this.txtUnitHistory.TabIndex = 0;
            this.txtUnitHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitHistory_KeyDown);
            // 
            // tbPrefect
            // 
            this.tbPrefect.Controls.Add(this.groupBox1);
            this.tbPrefect.Controls.Add(dataGridView1);
            this.tbPrefect.Location = new System.Drawing.Point(4, 22);
            this.tbPrefect.Name = "tbPrefect";
            this.tbPrefect.Size = new System.Drawing.Size(881, 382);
            this.tbPrefect.TabIndex = 3;
            this.tbPrefect.Text = "Prefect";
            this.tbPrefect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnStartCollection);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(0, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "collection controls";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button4.Location = new System.Drawing.Point(67, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 26);
            this.button4.TabIndex = 9;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnStartCollection
            // 
            this.btnStartCollection.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnStartCollection.Location = new System.Drawing.Point(6, 15);
            this.btnStartCollection.Name = "btnStartCollection";
            this.btnStartCollection.Size = new System.Drawing.Size(55, 26);
            this.btnStartCollection.TabIndex = 8;
            this.btnStartCollection.Text = "Start";
            this.btnStartCollection.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "tags in list:";
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
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbNotify.ResumeLayout(false);
            this.tbNotify.PerformLayout();
            this.tbTrack.ResumeLayout(false);
            this.tbTrack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).EndInit();
            this.tbUnitHistory.ResumeLayout(false);
            this.tbUnitHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitHistory)).EndInit();
            this.tbPrefect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnTagList;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker bwNotifications;
        private System.ComponentModel.BackgroundWorker bwConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbNotify;
        private System.Windows.Forms.TabPage tbTrack;
        private System.Windows.Forms.DataGridView dgvTracker;
        private System.Windows.Forms.TabPage tbUnitHistory;
        private System.Windows.Forms.TextBox txtUnitHistory;
        private System.Windows.Forms.DataGridView dgvUnitHistory;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TabPage tbPrefect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartCollection;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltagID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKown;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker bwListen;
        private System.Windows.Forms.TextBox txtStream;
        private System.Windows.Forms.Label lblTagCount;
        private System.Windows.Forms.Label label1;
    }
}

