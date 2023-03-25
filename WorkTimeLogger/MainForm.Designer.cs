namespace WorkTimeLogger
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishForTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btn_Maximize = new System.Windows.Forms.Button();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_Meeting = new System.Windows.Forms.Button();
            this.btn_Coding = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Break = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView_History = new System.Windows.Forms.DataGridView();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_History)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Work Time Logger";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.openFileLocationToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.finishForTodayToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 92);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open the logs in file explorer";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // finishForTodayToolStripMenuItem
            // 
            this.finishForTodayToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finishForTodayToolStripMenuItem.Name = "finishForTodayToolStripMenuItem";
            this.finishForTodayToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.finishForTodayToolStripMenuItem.Text = "Finish for today!";
            this.finishForTodayToolStripMenuItem.Click += new System.EventHandler(this.finishForTodayToolStripMenuItem_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Controls.Add(this.btn_Maximize);
            this.panelHeader.Controls.Add(this.btn_Minimize);
            this.panelHeader.Location = new System.Drawing.Point(2, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(457, 30);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseEnter += new System.EventHandler(this.panelHeader_MouseEnter);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(3, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(64, 15);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "__:__ - __:__";
            this.lblHeader.MouseEnter += new System.EventHandler(this.panelHeader_MouseEnter);
            // 
            // btn_Maximize
            // 
            this.btn_Maximize.FlatAppearance.BorderSize = 0;
            this.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximize.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Maximize.ForeColor = System.Drawing.Color.White;
            this.btn_Maximize.Location = new System.Drawing.Point(394, 3);
            this.btn_Maximize.Name = "btn_Maximize";
            this.btn_Maximize.Size = new System.Drawing.Size(28, 27);
            this.btn_Maximize.TabIndex = 0;
            this.btn_Maximize.TabStop = false;
            this.btn_Maximize.Text = "[]";
            this.toolTip1.SetToolTip(this.btn_Maximize, "Maximize");
            this.btn_Maximize.UseVisualStyleBackColor = true;
            this.btn_Maximize.Click += new System.EventHandler(this.btn_Maximize_Click);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Minimize.ForeColor = System.Drawing.Color.White;
            this.btn_Minimize.Location = new System.Drawing.Point(428, 3);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(28, 27);
            this.btn_Minimize.TabIndex = 3;
            this.btn_Minimize.Text = "-";
            this.toolTip1.SetToolTip(this.btn_Minimize, "Hide");
            this.btn_Minimize.UseVisualStyleBackColor = true;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_Meeting
            // 
            this.btn_Meeting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Meeting.BackgroundImage")));
            this.btn_Meeting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Meeting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Meeting.FlatAppearance.BorderSize = 0;
            this.btn_Meeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Meeting.Location = new System.Drawing.Point(93, 41);
            this.btn_Meeting.Name = "btn_Meeting";
            this.btn_Meeting.Size = new System.Drawing.Size(60, 60);
            this.btn_Meeting.TabIndex = 0;
            this.btn_Meeting.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Meeting, "Meeting");
            this.btn_Meeting.UseVisualStyleBackColor = true;
            this.btn_Meeting.Click += new System.EventHandler(this.btn_Meeting_Click);
            this.btn_Meeting.MouseEnter += new System.EventHandler(this.btn_Meeting_MouseEnter);
            this.btn_Meeting.MouseLeave += new System.EventHandler(this.btn_Meeting_MouseLeave);
            // 
            // btn_Coding
            // 
            this.btn_Coding.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Coding.BackgroundImage")));
            this.btn_Coding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Coding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Coding.FlatAppearance.BorderSize = 0;
            this.btn_Coding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Coding.Location = new System.Drawing.Point(12, 41);
            this.btn_Coding.Name = "btn_Coding";
            this.btn_Coding.Size = new System.Drawing.Size(60, 60);
            this.btn_Coding.TabIndex = 0;
            this.btn_Coding.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Coding, "Coding");
            this.btn_Coding.UseVisualStyleBackColor = true;
            this.btn_Coding.Click += new System.EventHandler(this.btn_Coding_Click);
            this.btn_Coding.MouseEnter += new System.EventHandler(this.btn_Coding_MouseEnter);
            this.btn_Coding.MouseLeave += new System.EventHandler(this.btn_Coding_MouseLeave);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.Navy;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(170, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 23);
            this.comboBox1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox1, "Description of your work");
            // 
            // btn_Break
            // 
            this.btn_Break.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Break.BackgroundImage")));
            this.btn_Break.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Break.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Break.FlatAppearance.BorderSize = 0;
            this.btn_Break.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Break.Location = new System.Drawing.Point(430, 38);
            this.btn_Break.Name = "btn_Break";
            this.btn_Break.Size = new System.Drawing.Size(25, 25);
            this.btn_Break.TabIndex = 2;
            this.btn_Break.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Break, "Break");
            this.btn_Break.UseVisualStyleBackColor = true;
            this.btn_Break.Click += new System.EventHandler(this.btn_Break_Click);
            this.btn_Break.MouseEnter += new System.EventHandler(this.btn_Break_MouseEnter);
            this.btn_Break.MouseLeave += new System.EventHandler(this.btn_Break_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView_History
            // 
            this.dataGridView_History.AllowUserToAddRows = false;
            this.dataGridView_History.AllowUserToDeleteRows = false;
            this.dataGridView_History.AllowUserToResizeColumns = false;
            this.dataGridView_History.AllowUserToResizeRows = false;
            this.dataGridView_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dataGridView_History.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView_History.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_History.CausesValidation = false;
            this.dataGridView_History.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_History.ColumnHeadersVisible = false;
            this.dataGridView_History.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartTime,
            this.EndTime,
            this.Activity,
            this.Description});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_History.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_History.EnableHeadersVisualStyles = false;
            this.dataGridView_History.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView_History.Location = new System.Drawing.Point(12, 107);
            this.dataGridView_History.Name = "dataGridView_History";
            this.dataGridView_History.RowHeadersVisible = false;
            this.dataGridView_History.RowTemplate.Height = 25;
            this.dataGridView_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_History.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_History.ShowCellErrors = false;
            this.dataGridView_History.ShowRowErrors = false;
            this.dataGridView_History.Size = new System.Drawing.Size(447, 76);
            this.dataGridView_History.TabIndex = 0;
            this.dataGridView_History.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_History_CellClick);
            this.dataGridView_History.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_History_CellEndEdit);
            this.dataGridView_History.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView_History_RowPrePaint);
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.ToolTipText = "Start time";
            this.StartTime.Width = 5;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.ToolTipText = "End time";
            this.EndTime.Width = 5;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "?";
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            this.Activity.Visible = false;
            this.Activity.Width = 5;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ToolTipText = "Description";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(461, 187);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_History);
            this.Controls.Add(this.btn_Break);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Coding);
            this.Controls.Add(this.btn_Meeting);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Logger";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_History)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private Panel panelHeader;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem openFileLocationToolStripMenuItem;
        private Button btn_Meeting;
        private Button btn_Coding;
        private ComboBox comboBox1;
        private ToolTip toolTip1;
        private Button btn_Break;
        private Button btn_Minimize;
        private ErrorProvider errorProvider1;
        private Button btn_Maximize;
        private DataGridView dataGridView_History;
        private Label lblHeader;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private DataGridViewTextBoxColumn Activity;
        private DataGridViewTextBoxColumn Description;
        private ToolStripMenuItem finishForTodayToolStripMenuItem;
    }
}