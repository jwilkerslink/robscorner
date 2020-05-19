namespace HG2020_XMTR_Engraver
{
    partial class Engraver
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtXT1 = new System.Windows.Forms.TextBox();
            this.txtXT2 = new System.Windows.Forms.TextBox();
            this.txtXT3 = new System.Windows.Forms.TextBox();
            this.txtXT4 = new System.Windows.Forms.TextBox();
            this.lblXT1 = new System.Windows.Forms.Label();
            this.lblXT2 = new System.Windows.Forms.Label();
            this.lblXT4 = new System.Windows.Forms.Label();
            this.lblXT3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrent1 = new System.Windows.Forms.Label();
            this.lblCurrent2 = new System.Windows.Forms.Label();
            this.lblCurrent3 = new System.Windows.Forms.Label();
            this.lblCurrent4 = new System.Windows.Forms.Label();
            this.timerGetSettings = new System.Windows.Forms.Timer(this.components);
            this.lblReady = new System.Windows.Forms.Label();
            this.timerReady = new System.Windows.Forms.Timer(this.components);
            this.numLOC8 = new System.Windows.Forms.NumericUpDown();
            this.lblNumLOC8s = new System.Windows.Forms.Label();
            this.Resettimer = new System.Windows.Forms.Timer(this.components);
            this.lblXT5 = new System.Windows.Forms.Label();
            this.txtXT5 = new System.Windows.Forms.TextBox();
            this.lblXT6 = new System.Windows.Forms.Label();
            this.txtXT6 = new System.Windows.Forms.TextBox();
            this.lblCurrent5 = new System.Windows.Forms.Label();
            this.lblCurrent6 = new System.Windows.Forms.Label();
            this.bwReadyStateCheck = new System.ComponentModel.BackgroundWorker();
            this.bwGetSettings = new System.ComponentModel.BackgroundWorker();
            this.pnlHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOC8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(375, 50);
            this.pnlHeader.TabIndex = 9;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlHeader_Paint);
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlHeader_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(312, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 28);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "__";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(101)))), ((int)(((byte)(113)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(349, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(114, 20);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(214, 30);
            this.lblHeader.TabIndex = 7;
            this.lblHeader.Text = "HG2020 Engraver";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(115, 50);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtXT1
            // 
            this.txtXT1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT1.Location = new System.Drawing.Point(14, 120);
            this.txtXT1.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT1.Name = "txtXT1";
            this.txtXT1.Size = new System.Drawing.Size(164, 20);
            this.txtXT1.TabIndex = 1;
            this.txtXT1.TextChanged += new System.EventHandler(this.TxtXT1_TextChanged);
            this.txtXT1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtXT1_KeyDown);
            // 
            // txtXT2
            // 
            this.txtXT2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT2.Location = new System.Drawing.Point(14, 178);
            this.txtXT2.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT2.Name = "txtXT2";
            this.txtXT2.Size = new System.Drawing.Size(164, 20);
            this.txtXT2.TabIndex = 2;
            this.txtXT2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtXT2_KeyDown);
            // 
            // txtXT3
            // 
            this.txtXT3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT3.Location = new System.Drawing.Point(16, 236);
            this.txtXT3.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT3.Name = "txtXT3";
            this.txtXT3.Size = new System.Drawing.Size(164, 20);
            this.txtXT3.TabIndex = 3;
            this.txtXT3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtXT3_KeyDown);
            // 
            // txtXT4
            // 
            this.txtXT4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT4.Location = new System.Drawing.Point(16, 294);
            this.txtXT4.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT4.Name = "txtXT4";
            this.txtXT4.Size = new System.Drawing.Size(164, 20);
            this.txtXT4.TabIndex = 4;
            this.txtXT4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtXT4_KeyDown);
            // 
            // lblXT1
            // 
            this.lblXT1.AutoSize = true;
            this.lblXT1.Location = new System.Drawing.Point(12, 94);
            this.lblXT1.Name = "lblXT1";
            this.lblXT1.Size = new System.Drawing.Size(138, 21);
            this.lblXT1.TabIndex = 2;
            this.lblXT1.Text = "HG2020 XMTR, 1:";
            // 
            // lblXT2
            // 
            this.lblXT2.AutoSize = true;
            this.lblXT2.Location = new System.Drawing.Point(12, 152);
            this.lblXT2.Name = "lblXT2";
            this.lblXT2.Size = new System.Drawing.Size(138, 21);
            this.lblXT2.TabIndex = 2;
            this.lblXT2.Text = "HG2020 XMTR, 2:";
            // 
            // lblXT4
            // 
            this.lblXT4.AutoSize = true;
            this.lblXT4.Location = new System.Drawing.Point(12, 268);
            this.lblXT4.Name = "lblXT4";
            this.lblXT4.Size = new System.Drawing.Size(138, 21);
            this.lblXT4.TabIndex = 2;
            this.lblXT4.Text = "HG2020 XMTR, 4:";
            // 
            // lblXT3
            // 
            this.lblXT3.AutoSize = true;
            this.lblXT3.Location = new System.Drawing.Point(12, 210);
            this.lblXT3.Name = "lblXT3";
            this.lblXT3.Size = new System.Drawing.Size(138, 21);
            this.lblXT3.TabIndex = 2;
            this.lblXT3.Text = "HG2020 XMTR, 3:";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(245, 451);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 33);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current Settings:";
            // 
            // lblCurrent1
            // 
            this.lblCurrent1.AutoSize = true;
            this.lblCurrent1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent1.Location = new System.Drawing.Point(243, 120);
            this.lblCurrent1.Name = "lblCurrent1";
            this.lblCurrent1.Size = new System.Drawing.Size(85, 21);
            this.lblCurrent1.TabIndex = 10;
            this.lblCurrent1.Text = "Loading...";
            // 
            // lblCurrent2
            // 
            this.lblCurrent2.AutoSize = true;
            this.lblCurrent2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent2.Location = new System.Drawing.Point(243, 178);
            this.lblCurrent2.Name = "lblCurrent2";
            this.lblCurrent2.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent2.TabIndex = 11;
            // 
            // lblCurrent3
            // 
            this.lblCurrent3.AutoSize = true;
            this.lblCurrent3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent3.Location = new System.Drawing.Point(243, 236);
            this.lblCurrent3.Name = "lblCurrent3";
            this.lblCurrent3.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent3.TabIndex = 12;
            // 
            // lblCurrent4
            // 
            this.lblCurrent4.AutoSize = true;
            this.lblCurrent4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent4.Location = new System.Drawing.Point(243, 294);
            this.lblCurrent4.Name = "lblCurrent4";
            this.lblCurrent4.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent4.TabIndex = 13;
            // 
            // timerGetSettings
            // 
            this.timerGetSettings.Interval = 500;
            this.timerGetSettings.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.ForeColor = System.Drawing.Color.Red;
            this.lblReady.Location = new System.Drawing.Point(12, 457);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(0, 21);
            this.lblReady.TabIndex = 10;
            // 
            // timerReady
            // 
            this.timerReady.Interval = 500;
            this.timerReady.Tick += new System.EventHandler(this.TimerReady_Tick);
            // 
            // numLOC8
            // 
            this.numLOC8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLOC8.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLOC8.Location = new System.Drawing.Point(148, 61);
            this.numLOC8.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numLOC8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLOC8.Name = "numLOC8";
            this.numLOC8.Size = new System.Drawing.Size(30, 23);
            this.numLOC8.TabIndex = 0;
            this.numLOC8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLOC8.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numLOC8.ValueChanged += new System.EventHandler(this.NumLOC8_ValueChanged);
            // 
            // lblNumLOC8s
            // 
            this.lblNumLOC8s.AutoSize = true;
            this.lblNumLOC8s.Location = new System.Drawing.Point(10, 60);
            this.lblNumLOC8s.Name = "lblNumLOC8s";
            this.lblNumLOC8s.Size = new System.Drawing.Size(137, 21);
            this.lblNumLOC8s.TabIndex = 15;
            this.lblNumLOC8s.Text = "Number of Units:";
            // 
            // Resettimer
            // 
            this.Resettimer.Interval = 5000;
            this.Resettimer.Tick += new System.EventHandler(this.Resettimer_Tick);
            // 
            // lblXT5
            // 
            this.lblXT5.AutoSize = true;
            this.lblXT5.Location = new System.Drawing.Point(12, 326);
            this.lblXT5.Name = "lblXT5";
            this.lblXT5.Size = new System.Drawing.Size(138, 21);
            this.lblXT5.TabIndex = 16;
            this.lblXT5.Text = "HG2020 XMTR, 5:";
            // 
            // txtXT5
            // 
            this.txtXT5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT5.Location = new System.Drawing.Point(16, 352);
            this.txtXT5.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT5.Name = "txtXT5";
            this.txtXT5.Size = new System.Drawing.Size(164, 20);
            this.txtXT5.TabIndex = 17;
            this.txtXT5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXT5_KeyDown);
            // 
            // lblXT6
            // 
            this.lblXT6.AutoSize = true;
            this.lblXT6.Location = new System.Drawing.Point(12, 386);
            this.lblXT6.Name = "lblXT6";
            this.lblXT6.Size = new System.Drawing.Size(138, 21);
            this.lblXT6.TabIndex = 18;
            this.lblXT6.Text = "HG2020 XMTR, 6:";
            // 
            // txtXT6
            // 
            this.txtXT6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXT6.Location = new System.Drawing.Point(16, 412);
            this.txtXT6.Margin = new System.Windows.Forms.Padding(5);
            this.txtXT6.Name = "txtXT6";
            this.txtXT6.Size = new System.Drawing.Size(164, 20);
            this.txtXT6.TabIndex = 19;
            this.txtXT6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtXT6_KeyDown);
            // 
            // lblCurrent5
            // 
            this.lblCurrent5.AutoSize = true;
            this.lblCurrent5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent5.Location = new System.Drawing.Point(243, 347);
            this.lblCurrent5.Name = "lblCurrent5";
            this.lblCurrent5.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent5.TabIndex = 13;
            // 
            // lblCurrent6
            // 
            this.lblCurrent6.AutoSize = true;
            this.lblCurrent6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(139)))));
            this.lblCurrent6.Location = new System.Drawing.Point(243, 411);
            this.lblCurrent6.Name = "lblCurrent6";
            this.lblCurrent6.Size = new System.Drawing.Size(0, 21);
            this.lblCurrent6.TabIndex = 13;
            // 
            // bwReadyStateCheck
            // 
            this.bwReadyStateCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReadyStateCheck_DoWork);
            this.bwReadyStateCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwReadyStateCheck_RunWorkerCompleted);
            // 
            // bwGetSettings
            // 
            this.bwGetSettings.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetSettings_DoWork);
            this.bwGetSettings.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetSettings_RunWorkerCompleted);
            // 
            // Engraver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(375, 496);
            this.Controls.Add(this.lblXT6);
            this.Controls.Add(this.txtXT6);
            this.Controls.Add(this.lblXT5);
            this.Controls.Add(this.txtXT5);
            this.Controls.Add(this.lblNumLOC8s);
            this.Controls.Add(this.numLOC8);
            this.Controls.Add(this.lblCurrent6);
            this.Controls.Add(this.lblCurrent5);
            this.Controls.Add(this.lblCurrent4);
            this.Controls.Add(this.lblCurrent3);
            this.Controls.Add(this.lblCurrent2);
            this.Controls.Add(this.lblReady);
            this.Controls.Add(this.lblCurrent1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblXT3);
            this.Controls.Add(this.lblXT4);
            this.Controls.Add(this.lblXT2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblXT1);
            this.Controls.Add(this.txtXT4);
            this.Controls.Add(this.txtXT3);
            this.Controls.Add(this.txtXT2);
            this.Controls.Add(this.txtXT1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Engraver";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLOC8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtXT1;
        private System.Windows.Forms.TextBox txtXT2;
        private System.Windows.Forms.TextBox txtXT3;
        private System.Windows.Forms.TextBox txtXT4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblXT1;
        private System.Windows.Forms.Label lblXT2;
        private System.Windows.Forms.Label lblXT4;
        private System.Windows.Forms.Label lblXT3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrent1;
        private System.Windows.Forms.Label lblCurrent2;
        private System.Windows.Forms.Label lblCurrent3;
        private System.Windows.Forms.Label lblCurrent4;
        private System.Windows.Forms.Timer timerGetSettings;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Timer timerReady;
        private System.Windows.Forms.NumericUpDown numLOC8;
        private System.Windows.Forms.Label lblNumLOC8s;
        private System.Windows.Forms.Timer Resettimer;
        private System.Windows.Forms.Label lblXT5;
        private System.Windows.Forms.TextBox txtXT5;
        private System.Windows.Forms.Label lblXT6;
        private System.Windows.Forms.TextBox txtXT6;
        private System.Windows.Forms.Label lblCurrent5;
        private System.Windows.Forms.Label lblCurrent6;
        private System.ComponentModel.BackgroundWorker bwReadyStateCheck;
        private System.ComponentModel.BackgroundWorker bwGetSettings;
    }
}

