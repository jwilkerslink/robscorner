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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bwNotifications = new System.ComponentModel.BackgroundWorker();
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbNotify = new System.Windows.Forms.TabPage();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tbTrack = new System.Windows.Forms.TabPage();
            this.dgvTracker = new System.Windows.Forms.DataGridView();
            this.TagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbUnitHistory = new System.Windows.Forms.TabPage();
            this.dgvUnitHistory = new System.Windows.Forms.DataGridView();
            this.txtUnitHistory = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbNotify.SuspendLayout();
            this.tbTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).BeginInit();
            this.tbUnitHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(2, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(881, 326);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "TagList";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(807, 330);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 17);
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
            this.button1.Location = new System.Drawing.Point(93, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 17);
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
            this.tabControl1.Location = new System.Drawing.Point(8, 32);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 372);
            this.tabControl1.TabIndex = 5;
            // 
            // tbNotify
            // 
            this.tbNotify.Controls.Add(this.txtCommand);
            this.tbNotify.Controls.Add(this.button3);
            this.tbNotify.Controls.Add(this.textBox1);
            this.tbNotify.Location = new System.Drawing.Point(4, 22);
            this.tbNotify.Margin = new System.Windows.Forms.Padding(2);
            this.tbNotify.Name = "tbNotify";
            this.tbNotify.Padding = new System.Windows.Forms.Padding(2);
            this.tbNotify.Size = new System.Drawing.Size(881, 346);
            this.tbNotify.TabIndex = 0;
            this.tbNotify.Text = "Notifications";
            this.tbNotify.UseVisualStyleBackColor = true;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(4, 330);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(800, 20);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // tbTrack
            // 
            this.tbTrack.Controls.Add(this.dgvTracker);
            this.tbTrack.Location = new System.Drawing.Point(4, 22);
            this.tbTrack.Margin = new System.Windows.Forms.Padding(2);
            this.tbTrack.Name = "tbTrack";
            this.tbTrack.Padding = new System.Windows.Forms.Padding(2);
            this.tbTrack.Size = new System.Drawing.Size(881, 346);
            this.tbTrack.TabIndex = 1;
            this.tbTrack.Text = "Tracker";
            this.tbTrack.UseVisualStyleBackColor = true;
            // 
            // dgvTracker
            // 
            this.dgvTracker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTracker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagID,
            this.Location,
            this.Event,
            this.Time});
            this.dgvTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTracker.Location = new System.Drawing.Point(2, 2);
            this.dgvTracker.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTracker.Name = "dgvTracker";
            this.dgvTracker.RowHeadersWidth = 62;
            this.dgvTracker.RowTemplate.Height = 28;
            this.dgvTracker.Size = new System.Drawing.Size(877, 342);
            this.dgvTracker.TabIndex = 0;
            // 
            // TagID
            // 
            this.TagID.HeaderText = "TagID";
            this.TagID.MinimumWidth = 8;
            this.TagID.Name = "TagID";
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 8;
            this.Location.Name = "Location";
            // 
            // Event
            // 
            this.Event.HeaderText = "Event";
            this.Event.MinimumWidth = 8;
            this.Event.Name = "Event";
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 8;
            this.Time.Name = "Time";
            // 
            // tbUnitHistory
            // 
            this.tbUnitHistory.Controls.Add(this.dgvUnitHistory);
            this.tbUnitHistory.Controls.Add(this.txtUnitHistory);
            this.tbUnitHistory.Controls.Add(this.button1);
            this.tbUnitHistory.Location = new System.Drawing.Point(4, 22);
            this.tbUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.tbUnitHistory.Name = "tbUnitHistory";
            this.tbUnitHistory.Size = new System.Drawing.Size(881, 346);
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
            this.dgvUnitHistory.Location = new System.Drawing.Point(5, 23);
            this.dgvUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUnitHistory.Name = "dgvUnitHistory";
            this.dgvUnitHistory.RowHeadersWidth = 62;
            this.dgvUnitHistory.RowTemplate.Height = 28;
            this.dgvUnitHistory.Size = new System.Drawing.Size(876, 328);
            this.dgvUnitHistory.TabIndex = 3;
            // 
            // txtUnitHistory
            // 
            this.txtUnitHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUnitHistory.Location = new System.Drawing.Point(0, 0);
            this.txtUnitHistory.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitHistory.Name = "txtUnitHistory";
            this.txtUnitHistory.Size = new System.Drawing.Size(89, 20);
            this.txtUnitHistory.TabIndex = 0;
            this.txtUnitHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitHistory_KeyDown);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(871, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(26, 37);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "⚙";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmRFIDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 412);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRFIDMain";
            this.Text = "Glix";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbNotify.ResumeLayout(false);
            this.tbNotify.PerformLayout();
            this.tbTrack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracker)).EndInit();
            this.tbUnitHistory.ResumeLayout(false);
            this.tbUnitHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker bwNotifications;
        private System.ComponentModel.BackgroundWorker bwConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbNotify;
        private System.Windows.Forms.TabPage tbTrack;
        private System.Windows.Forms.DataGridView dgvTracker;
        private System.Windows.Forms.TabPage tbUnitHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TextBox txtUnitHistory;
        private System.Windows.Forms.DataGridView dgvUnitHistory;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSettings;
    }
}

