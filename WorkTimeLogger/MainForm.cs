using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WorkTimeLogger.Constants;
using WorkTimeLogger.Models;
using WorkTimeLogger.Services;

namespace WorkTimeLogger
{
    public partial class MainForm : Form
    {
        private Image defaultImage_Coding = null;
        private Image defaultImage_Meeting = null;
        private Image defaultImage_Break = null;
        private Image hoverImage_Coding = null;
        private Image hoverImage_Meeting = null;
        private Image hoverImage_Break = null;
        
        private bool isMaximized = false;

        List<string> mostUsedPhrases = new List<string>();

        private bool dragging;
        private Point lastLocation;
        int maxScreenX = Screen.PrimaryScreen.WorkingArea.Width;
        int maxScreenY = Screen.PrimaryScreen.WorkingArea.Height;

        public MainForm()
        {
            InitializeComponent();

            DefineBtnBackgrounds();

            this.Size = new Size(GeneralConstants.widthSmall, GeneralConstants.heightSmall);
            RepositionTheForm();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Select();
            mostUsedPhrases = JsonReader.GetMostUsedPhrases(GeneralConstants.templateFile);
            foreach(string ph in mostUsedPhrases)
            {
                comboBox1.Items.Add(ph);
            }

            string activity = "";
            GeneralConstants.listRecords = CsvFileCreator.CreateCsvFile();
            if(GeneralConstants.listRecords != null)
            {
                if(GeneralConstants.listRecords.Count > 0)
                {
                    PopulateDataGridView();
                    CsvRecord lastRecord = GeneralConstants.listRecords.Last();
                    if (lastRecord.EndTime == "-")
                    {
                        activity = lastRecord.Activity;

                    }
                    else
                    {
                        activity = "";
                    }
                    setHeader(lastRecord);

                    setTotalHrs();
                }
            }

            HeaderGradientBackground(activity);
        }

        // The panel that is shown befor you show with the mouse on it
        // On mouse enter resize the form
        private void panelHeader_MouseEnter(object sender, EventArgs e)
        {
            comboBox1.Focus();
            comboBox1.Select();
            if (!isMaximized)
            {
                this.Size = new Size(GeneralConstants.widthBig, GeneralConstants.heightBig);
                //RepositionTheForm();
                dataGridView_History.CurrentCell = null;
                comboBox1.Select();
                setTotalHrs();

                
                if(lastLocation.Y >= (maxScreenY-GeneralConstants.heightSmall))
                {
                    this.Location = new Point(lastLocation.X, (maxScreenY - GeneralConstants.heightBig));
                }else if(lastLocation.X >= (maxScreenX-GeneralConstants.widthBig))
                {
                    this.Location = new Point((maxScreenX - GeneralConstants.widthBig), lastLocation.Y);
                }
            }
        }

        // The header text shown in the header panel
        private void setHeader(CsvRecord r)
        {
            string header = $"{r.StartTime} {r.Description}";
            if(header.Length > 60)
            {
                header = header.Substring(0,60)+"...";
            }
            if(r.EndTime != "-")
            {
                header = "Today's log is finished!";
            }
            lblHeader.Text = header;
        }

        // Total calculated hours for the current day
        private void setTotalHrs()
        {
            List<decimal> totalHrs = CsvFileCreator.GetTotalHrs();
            if(totalHrs.Count > 0)
            {
                groupBox_Total.Text = $"Total hrs: {totalHrs.Sum()}";
                lblHrs.Text = $"Coding: {totalHrs[0]}, Meeting: {totalHrs[1]}, Break: {totalHrs[2]}";
            }
        }

        // When mouse leaves the form resize it back to the small header panel
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                {
                    this.Size = new Size(GeneralConstants.widthSmall, GeneralConstants.heightSmall);
                    //RepositionTheForm();
                    this.Location = lastLocation;
                }
            }
        }

        // Prevent the user click on the X button or Alt+F4
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                e.Cancel = true;
            }
        }

        // The menu strip buttons that are showing when the user click right mouse click on the icon
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
            this.Show();
            setTotalHrs();
        }

        // Exit the app, when you run again the app will continue from the last state
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // When you double click on the icon - show the app
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            BringToFront();
            Activate();
            this.Show();
            setTotalHrs();
        }

        // Hide the form by clicking the '-' button
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            isMaximized = false;
            btn_Maximize.Text = "[]";
            dataGridView_History.CurrentCell = null;
        }

        // Hide the form by clicking the menu strip button 'Hide'
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Minimize_Click(sender, e);
        }

        // The form will stay open
        private void btn_Maximize_Click(object sender, EventArgs e)
        {
            comboBox1.Select();
            dataGridView_History.CurrentCell = null;
            if (isMaximized == false)
            {
                isMaximized = true;
                int rowCount = dataGridView_History.Rows.Count;
                int newHeight = GeneralConstants.heightBig;
                int newGridHeight = dataGridView_History.Height; 
                if (rowCount > 3)
                {
                    newHeight = CalculateNewFormHeight(rowCount+1);
                    newGridHeight = CalculateNewGridHeight(rowCount + 1, newHeight);
                }
                this.Size = new Size(GeneralConstants.widthBig, newHeight);
                dataGridView_History.Size = new Size(dataGridView_History.Width, newGridHeight);
                //RepositionTheForm();
                btn_Maximize.Text = "[ ]";
                toolTip1.SetToolTip(btn_Maximize, "Minimize");
                
            }
            else
            {
                isMaximized = false;
                this.Size = new Size(GeneralConstants.widthSmall, GeneralConstants.heightSmall);
                dataGridView_History.Size = new Size(dataGridView_History.Width, 76);
                //RepositionTheForm();
                btn_Maximize.Text = "[]";
                toolTip1.SetToolTip(btn_Maximize, "Maximize");
                dataGridView_History.FirstDisplayedScrollingRowIndex = dataGridView_History.Rows.Count - 1;
            }
            setTotalHrs();
        }

        // Calculate new bigger high of the form depending on the inserted rows
        private int CalculateNewFormHeight(int rowCount)
        {
            int rowHeight = dataGridView_History.RowTemplate.Height;
            int screenHight = Screen.PrimaryScreen.WorkingArea.Height-200;
            int newHeight = (GeneralConstants.heightBig - (3*rowHeight)) + (rowCount * rowHeight);
            if (newHeight > screenHight)
            {
                newHeight = screenHight;
            }

            return newHeight;
        }

        // Calculate new bigger high of the gridview depending on the inserted rows
        private int CalculateNewGridHeight(int rowCount, int formHeight)
        {
            int rowHeight = dataGridView_History.RowTemplate.Height;
            int newHeight = formHeight - 130;

            return newHeight;
        }

        // Open the folder with all csv log files
        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(GeneralConstants.logsFolder, DateTime.Now.Year.ToString(), DateTime.Now.ToString("MM")));
        }

        // Button for coding - on mouse over
        private void btn_Coding_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Coding != null)
            {
                defaultImage_Coding = btn_Coding.BackgroundImage;
                btn_Coding.BackgroundImage = hoverImage_Coding;
            }
        }

        // Button for coding - on mouse leave
        private void btn_Coding_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Coding != null)
            {
                btn_Coding.BackgroundImage = defaultImage_Coding;
            }
        }

        // Button for meeting - on mouse over
        private void btn_Meeting_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Meeting != null)
            {
                defaultImage_Meeting = btn_Meeting.BackgroundImage;
                btn_Meeting.BackgroundImage = hoverImage_Meeting;
            }
        }

        // Button for meeting - on mouse leave
        private void btn_Meeting_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Meeting != null)
            {
                btn_Meeting.BackgroundImage = defaultImage_Meeting;
            }
        }

        // Button for break - on mouse over
        private void btn_Break_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Break != null)
            {
                defaultImage_Break = btn_Break.BackgroundImage;
                btn_Break.BackgroundImage = hoverImage_Break;
            }
        }

        // Button for break - on mouse leave
        private void btn_Break_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Break != null)
            {
                btn_Break.BackgroundImage = defaultImage_Break;
            }
        }

        // When you click on the meeting button...
        private void btn_Meeting_Click(object sender, EventArgs e)
        {
            string activity = "Meeting";
            string description = "Meeting";
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                description = comboBox1.Text;
            }
            //if (ValidateComboBox())
            //{
            comboBox1.Select();
            CsvFileCreator.InsertCsvRow(description, activity, 0);
            CsvRecord lastRecord = GeneralConstants.listRecords.Last();
            setHeader(lastRecord);
            HeaderGradientBackground(activity);
            PopulateDataGridView();
            setTotalHrs();
            dataGridView_History.CurrentCell = null;
            //}
            comboBox1.Text = "";
            comboBox1.Focus();
            comboBox1.Select();
        }

        // When you click on the coding button...
        private void btn_Coding_Click(object sender, EventArgs e)
        {
            string activity = "Coding";
            string description = "Coding";
            if(!string.IsNullOrEmpty(comboBox1.Text))
            {
                description = comboBox1.Text;
            }
            //if (ValidateComboBox())
            //{
            comboBox1.Select();
            CsvFileCreator.InsertCsvRow(description, activity, 0);
            CsvRecord lastRecord = GeneralConstants.listRecords.Last();
            setHeader(lastRecord);
            HeaderGradientBackground(activity);
            PopulateDataGridView();
            setTotalHrs();
            dataGridView_History.CurrentCell = null;
            //}
            comboBox1.Text = "";
            comboBox1.Focus();
            comboBox1.Select();
        }

        // When you click on the break button...
        private void btn_Break_Click(object sender, EventArgs e)
        {
            // Validation for empty combobox here is not needed
            string activity = "Break";
            comboBox1.Text = "";
            comboBox1.Focus();
            comboBox1.Select();
            CsvFileCreator.InsertCsvRow(activity, activity, 0);
            CsvRecord lastRecord = GeneralConstants.listRecords.Last();
            setHeader(lastRecord);
            HeaderGradientBackground(activity);
            PopulateDataGridView();
            setTotalHrs();
            dataGridView_History.CurrentCell = null;
        }

        // Combobox validation - I will not use this, because I though that is better to 
        // inser a record without any text, I will use default text instead such Coding, Meeting (similar to Break)
        private bool ValidateComboBox()
        {
            if (comboBox1.SelectedItem == null && string.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider1.SetError(comboBox1, "What you are working now!");
                return false;
            }
            else 
            {
                errorProvider1.SetError(comboBox1, "");
            }
            return true;
        }


        // Change the backgroung of the header panel, according the action: coding, meeting, break
        private void HeaderGradientBackground(string mode)
        {
            // Create a new ColorBlend object
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new float[] { 0, 0.5f, 1 };
            colorBlend.Colors = new Color[] { Color.Navy, Color.DarkBlue, Color.RoyalBlue };

            if(mode.Equals("Coding"))
            {
                colorBlend.Colors = new Color[] { Color.Navy, Color.DarkGreen, Color.SeaGreen };
            }
            else if (mode.Equals("Meeting"))
            {
                colorBlend.Colors = new Color[] { Color.Navy, Color.RebeccaPurple, Color.Purple };
            }
            else if (mode.Equals("Break"))
            {
                colorBlend.Colors = new Color[] { Color.Navy, Color.DarkRed, Color.IndianRed };
            }

                // Create a new Brush object using the ColorBlend object
                LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), // Starting point of the gradient
                new Point(panelHeader.ClientSize.Width, panelHeader.ClientSize.Height), // Ending point of the gradient
                Color.Navy, // Starting color of the gradient
                Color.RoyalBlue); // Ending color of the gradient
            brush.InterpolationColors = colorBlend;

            // Set the BackColor property of the panel to the brush
            panelHeader.BackColor = Color.Transparent; // Set the panel's BackColor to transparent
            panelHeader.BackgroundImage = new Bitmap(panelHeader.ClientSize.Width, panelHeader.ClientSize.Height); // Create a new bitmap for the panel's background
            using (Graphics g = Graphics.FromImage(panelHeader.BackgroundImage))
            {
                g.FillRectangle(brush, 0, 0, panelHeader.ClientSize.Width, panelHeader.ClientSize.Height); // Fill the bitmap with the gradient brush
            }
        }

        private void DefineBtnBackgrounds()
        {
            // Load default image
            defaultImage_Coding = Image.FromFile(GeneralConstants.bckgrImg_btnCoding1);

            // Load hover image (change file name)
            string hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnCoding1), GeneralConstants.bckgrImg_btnCoding2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Coding = Image.FromFile(hoverImageFilePath);
            }

            //-------------------------------

            // Load default image
            defaultImage_Meeting = Image.FromFile(GeneralConstants.bckgrImg_btnMeeting1);

            // Load hover image (change file name)
            hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnMeeting1), GeneralConstants.bckgrImg_btnMeeting2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Meeting = Image.FromFile(hoverImageFilePath);
            }

            //-------------------------------

            // Load default image
            defaultImage_Break = Image.FromFile(GeneralConstants.bckgrImg_btnBreak1);

            // Load hover image (change file name)
            hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnBreak1), GeneralConstants.bckgrImg_btnBreak2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Break = Image.FromFile(hoverImageFilePath);
            }

        }

        private void PopulateDataGridView()
        {
            // Clear any existing rows from the DataGridView
            dataGridView_History.Rows.Clear();

            // Add column headers
            //dataGridView_History.Columns.Add("StartTime", "Start");
            //dataGridView_History.Columns.Add("EndTime", "End");
            //dataGridView_History.Columns.Add("Activity", "?");
            //dataGridView_History.Columns.Add("Description", "Description");

            foreach (var record in GeneralConstants.listRecords)
            {
                Color rowColor = Color.White;
                if (record.Activity == "Meeting")
                {
                    rowColor = Color.Violet;
                }
                else if (record.Activity == "Coding")
                {
                    rowColor = Color.LightGreen;
                }

                // Add a new row to the DataGridView with the record data
                dataGridView_History.Rows.Add(new object[] {
                    record.StartTime,
                    record.EndTime,
                    record.Activity.Substring(0,1),
                    record.Description
                });

                // Set the background color of the new row
                dataGridView_History.Rows[dataGridView_History.Rows.Count - 1].DefaultCellStyle.BackColor = rowColor;
                // Scroll to the last row in the grid view
                dataGridView_History.FirstDisplayedScrollingRowIndex = dataGridView_History.Rows.Count - 1;
            }
        }

        private void dataGridView_History_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Get the row and the value of the Type column
            DataGridViewRow row = dataGridView_History.Rows[e.RowIndex];
            string type = row.Cells["Activity"].Value.ToString();

            // Set the background color based on the value of the Type column
            if (type.ToUpper() == "C")
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else if (type.ToUpper() == "M")
            {
                row.DefaultCellStyle.BackColor = Color.Violet;
            }
            else if (type.ToUpper() == "B")
            {
                row.DefaultCellStyle.BackColor = Color.IndianRed;
            }
        }

        private void dataGridView_History_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView_History.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Clipboard.SetText(cell.Value.ToString());
                //cell.Selected = false;

                string content = cell.Value.ToString();
                Clipboard.SetText(content);
                comboBox1.Text = cell.Value.ToString();
                comboBox1.Select();
            }
        }

        private void dataGridView_History_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Suspend the CellEndEdit event handler
            dataGridView_History.CellEndEdit -= dataGridView_History_CellEndEdit;

            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (columnIndex == 3) // description column
            {
                string newValue = dataGridView_History.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                if(newValue != GeneralConstants.listRecords[rowIndex].Description)
                {
                    GeneralConstants.listRecords[rowIndex].Description = newValue;
                    comboBox1.Select();
                    CsvFileCreator.InsertCsvRow(newValue, GeneralConstants.listRecords[rowIndex].Activity, 1);
                    //PopulateDataGridView();
                    if (rowIndex == GeneralConstants.listRecords.Count - 1)
                    {
                        setHeader(GeneralConstants.listRecords[rowIndex]);
                    }
                }
            }

            // Reattach the CellEndEdit event handler
            dataGridView_History.CellEndEdit += dataGridView_History_CellEndEdit;
        }

        private void finishForTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GeneralConstants.listRecords != null)
            {
                if(GeneralConstants.listRecords.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to close today's log file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        comboBox1.Select();
                        CsvRecord lastRecord = GeneralConstants.listRecords.Last();

                        CsvFileCreator.InsertCsvRow(lastRecord.Description, lastRecord.Activity, 2);

                        Application.Exit();
                    }
                }else
                {
                    MessageBox.Show("You don't have any records!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // When you click on the form, make a disselection of the selected row and calculate the total hours
        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView_History.CurrentCell = null;
            setTotalHrs();
        }

        // Reposition the form
        private void RepositionTheForm()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            lastLocation = new Point(x, y);
            this.Location = lastLocation;
        }

        // ----------------------------------------
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            lastLocation = e.Location;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {

                int pomWidth = 0;
                int pomHeight = 0;

                if(!isMaximized)
                {
                    pomWidth = GeneralConstants.widthSmall;
                    pomHeight = GeneralConstants.heightSmall;
                }else
                {
                    pomWidth = GeneralConstants.widthBig;
                    pomHeight = GeneralConstants.heightBig;
                }
                // Get the screen's working area
                Rectangle workingArea = Screen.GetWorkingArea(this);

                // Calculate the bounds of the form
                int formLeft = this.Location.X - lastLocation.X + e.X;
                int formTop = this.Location.Y - lastLocation.Y + e.Y;
                int formRight = formLeft + pomWidth;
                int formBottom = formTop + pomHeight;

                // Check if the form is within the screen's working area
                if (formLeft < workingArea.Left)
                {
                    formLeft = workingArea.Left;
                }
                else if (formRight > workingArea.Right)
                {
                    formLeft = workingArea.Right - pomWidth;
                }

                if (formTop < workingArea.Top)
                {
                    formTop = workingArea.Top;
                }
                else if (formBottom > workingArea.Bottom)
                {
                    formTop = workingArea.Bottom - pomHeight;
                }

                // Set the new position of the form
                this.Location = new Point(formLeft, formTop);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            lastLocation = this.Location;
            dragging = false;
        }

    }
}