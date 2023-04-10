namespace WorkTimeLogger
{
    partial class LogDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.datePicker_End = new System.Windows.Forms.DateTimePicker();
            this.groupBox_Total = new System.Windows.Forms.GroupBox();
            this.txtBox_Details = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Report = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView_Logs = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Break = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Total.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).BeginInit();
            this.SuspendLayout();
            // 
            // datePicker_Begin
            // 
            this.datePicker_Begin.CalendarForeColor = System.Drawing.Color.Navy;
            this.datePicker_Begin.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.datePicker_Begin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datePicker_Begin.CustomFormat = "dd.MM.yyyy";
            this.datePicker_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker_Begin.Location = new System.Drawing.Point(118, 16);
            this.datePicker_Begin.MaxDate = new System.DateTime(2023, 4, 10, 0, 0, 0, 0);
            this.datePicker_Begin.Name = "datePicker_Begin";
            this.datePicker_Begin.Size = new System.Drawing.Size(83, 23);
            this.datePicker_Begin.TabIndex = 1;
            this.datePicker_Begin.Value = new System.DateTime(2023, 4, 10, 0, 0, 0, 0);
            this.datePicker_Begin.ValueChanged += new System.EventHandler(this.datePicker_Begin_ValueChanged);
            // 
            // datePicker_End
            // 
            this.datePicker_End.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datePicker_End.CustomFormat = "dd.MM.yyyy";
            this.datePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker_End.Location = new System.Drawing.Point(225, 16);
            this.datePicker_End.MaxDate = new System.DateTime(2023, 4, 10, 0, 0, 0, 0);
            this.datePicker_End.Name = "datePicker_End";
            this.datePicker_End.Size = new System.Drawing.Size(83, 23);
            this.datePicker_End.TabIndex = 2;
            this.datePicker_End.Value = new System.DateTime(2023, 4, 10, 0, 0, 0, 0);
            this.datePicker_End.ValueChanged += new System.EventHandler(this.datePicker_End_ValueChanged);
            // 
            // groupBox_Total
            // 
            this.groupBox_Total.Controls.Add(this.txtBox_Details);
            this.groupBox_Total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_Total.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox_Total.ForeColor = System.Drawing.SystemColors.GrayText;
            this.groupBox_Total.Location = new System.Drawing.Point(1, 45);
            this.groupBox_Total.Name = "groupBox_Total";
            this.groupBox_Total.Size = new System.Drawing.Size(460, 87);
            this.groupBox_Total.TabIndex = 0;
            this.groupBox_Total.TabStop = false;
            this.groupBox_Total.Text = "Total hrs: ";
            this.toolTip1.SetToolTip(this.groupBox_Total, "Total hours for the chosen period");
            // 
            // txtBox_Details
            // 
            this.txtBox_Details.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBox_Details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_Details.Location = new System.Drawing.Point(6, 22);
            this.txtBox_Details.Multiline = true;
            this.txtBox_Details.Name = "txtBox_Details";
            this.txtBox_Details.ReadOnly = true;
            this.txtBox_Details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_Details.Size = new System.Drawing.Size(444, 58);
            this.txtBox_Details.TabIndex = 0;
            this.txtBox_Details.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(207, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // btn_Report
            // 
            this.btn_Report.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Report.BackgroundImage")));
            this.btn_Report.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Report.FlatAppearance.BorderSize = 0;
            this.btn_Report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Report.Location = new System.Drawing.Point(334, 9);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(36, 40);
            this.btn_Report.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_Report, "Create detail Excel report");
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            this.btn_Report.MouseEnter += new System.EventHandler(this.btn_Report_MouseEnter);
            this.btn_Report.MouseLeave += new System.EventHandler(this.btn_Report_MouseLeave);
            // 
            // dataGridView_Logs
            // 
            this.dataGridView_Logs.AllowUserToAddRows = false;
            this.dataGridView_Logs.AllowUserToDeleteRows = false;
            this.dataGridView_Logs.AllowUserToResizeColumns = false;
            this.dataGridView_Logs.AllowUserToResizeRows = false;
            this.dataGridView_Logs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Logs.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView_Logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Logs.CausesValidation = false;
            this.dataGridView_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Logs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.CodingTime,
            this.Meeting,
            this.Break,
            this.Total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Logs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Logs.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView_Logs.Location = new System.Drawing.Point(1, 151);
            this.dataGridView_Logs.Name = "dataGridView_Logs";
            this.dataGridView_Logs.RowHeadersVisible = false;
            this.dataGridView_Logs.RowTemplate.Height = 25;
            this.dataGridView_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Logs.ShowCellErrors = false;
            this.dataGridView_Logs.ShowRowErrors = false;
            this.dataGridView_Logs.Size = new System.Drawing.Size(460, 177);
            this.dataGridView_Logs.TabIndex = 0;
            this.dataGridView_Logs.TabStop = false;
            this.dataGridView_Logs.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Logs_CellMouseEnter);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.ToolTipText = "Date";
            // 
            // CodingTime
            // 
            this.CodingTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CodingTime.HeaderText = "Coding";
            this.CodingTime.Name = "CodingTime";
            this.CodingTime.ReadOnly = true;
            this.CodingTime.ToolTipText = "Coding time";
            // 
            // Meeting
            // 
            this.Meeting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Meeting.HeaderText = "Meeting";
            this.Meeting.Name = "Meeting";
            this.Meeting.ReadOnly = true;
            this.Meeting.ToolTipText = "Meeting time";
            // 
            // Break
            // 
            this.Break.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Break.HeaderText = "Break";
            this.Break.Name = "Break";
            this.Break.ReadOnly = true;
            this.Break.ToolTipText = "Break Time";
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Total.DefaultCellStyle = dataGridViewCellStyle1;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.ToolTipText = "Total time";
            // 
            // LogDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(463, 326);
            this.Controls.Add(this.dataGridView_Logs);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_Total);
            this.Controls.Add(this.datePicker_End);
            this.Controls.Add(this.datePicker_Begin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Logger Details";
            this.Load += new System.EventHandler(this.LogDetailsForm_Load);
            this.groupBox_Total.ResumeLayout(false);
            this.groupBox_Total.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Logs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker datePicker_Begin;
        private DateTimePicker datePicker_End;
        private GroupBox groupBox_Total;
        private TextBox txtBox_Details;
        private Label label1;
        private Button btn_Report;
        private ToolTip toolTip1;
        private DataGridView dataGridView_Logs;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn CodingTime;
        private DataGridViewTextBoxColumn Meeting;
        private DataGridViewTextBoxColumn Break;
        private DataGridViewTextBoxColumn Total;
    }
}