using WorkTimeLogger.Constants;
using WorkTimeLogger.Models;
using WorkTimeLogger.Services;

namespace WorkTimeLogger
{
    public partial class LogDetailsForm : Form
    {
        List<CsvRecord> list = new List<CsvRecord>();
        private Image defaultImage_Excel = null;
        private Image hoverImage_Excel = null;

        public LogDetailsForm()
        {
            InitializeComponent();
            datePicker_End.MaxDate = DateTime.Now.AddDays(1).Date;
            datePicker_Begin.MaxDate = DateTime.Now.AddDays(1).Date;
            // Load default image
            defaultImage_Excel = Image.FromFile(GeneralConstants.bckgrImg_btnReport1);
            string hoverImageFilePath = Path.Combine(Path.GetDirectoryName(GeneralConstants.bckgrImg_btnReport1), GeneralConstants.bckgrImg_btnReport2);
            if (File.Exists(hoverImageFilePath))
            {
                hoverImage_Excel = Image.FromFile(hoverImageFilePath);
            }
        }

        private void LogDetailsForm_Load(object sender, EventArgs e)
        {
            DateTime dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            datePicker_Begin.Value = dateFrom;
            DateTime dateTo = DateTime.Now;
            datePicker_End.Value = dateTo;
            list = LogsHistory.ReadCSVFiles(dateFrom, dateTo);
            CalculateTotalHours(list);
            FillDataGridView(dateFrom, dateTo);
        }

        private void datePicker_Begin_ValueChanged(object sender, EventArgs e)
        {
            list.Clear();
            DateTime dateFrom = datePicker_Begin.Value;
            DateTime dateTo = datePicker_End.Value;
            list = LogsHistory.ReadCSVFiles(dateFrom, dateTo);
            CalculateTotalHours(list);
            FillDataGridView(dateFrom, dateTo);
        }

        private void datePicker_End_ValueChanged(object sender, EventArgs e)
        {
            list.Clear();
            DateTime dateFrom = datePicker_Begin.Value;
            DateTime dateTo = datePicker_End.Value;
            list = LogsHistory.ReadCSVFiles(dateFrom, dateTo);
            CalculateTotalHours(list);
            FillDataGridView(dateFrom, dateTo);
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            LogsHistory.CreateExcelReport(list);
        }

        private void btn_Report_MouseEnter(object sender, EventArgs e)
        {
            if (hoverImage_Excel != null)
            {
                defaultImage_Excel = btn_Report.BackgroundImage;
                btn_Report.BackgroundImage = hoverImage_Excel;
            }

        }

        private void btn_Report_MouseLeave(object sender, EventArgs e)
        {
            if (defaultImage_Excel != null)
            {
                btn_Report.BackgroundImage = defaultImage_Excel;
            }
        }

        private void CalculateTotalHours(List<CsvRecord> l)
        {
            // coding, meeting, break
            List<decimal> totalHrs = new List<decimal> { 0.0m, 0.0m, 0.0m };
            List<string> unfinishedRecords = new List<string>();

            if (l != null)
            {
                foreach (CsvRecord r in l)
                {
                    if (r.EndTime != "-")
                    {
                        if (r.Activity == "Coding")
                        {
                            totalHrs[0] += (decimal)r.Duration;
                        }
                        else if (r.Activity == "Meeting")
                        {
                            totalHrs[1] += (decimal)r.Duration;
                        }
                        else if (r.Activity == "Break")
                        {
                            totalHrs[2] += (decimal)r.Duration;
                        }
                    }
                    else
                    {
                        string pomRecord = r.Date + " " + r.StartTime + " - / " + r.Activity + "; " + r.Description;
                        unfinishedRecords.Add(pomRecord);
                    }
                }// END - foreach

                groupBox_Total.Text = $"Total hrs: {totalHrs.Sum()}";
                txtBox_Details.Text = $"Coding: {totalHrs[0]}, Meeting: {totalHrs[1]}, Break: {totalHrs[2]}";
                if(unfinishedRecords.Count > 0)
                {
                    txtBox_Details.Text += Environment.NewLine + Environment.NewLine + "There are unfinished records: " + Environment.NewLine;
                    foreach(string s in unfinishedRecords)
                    {
                        txtBox_Details.Text += s + Environment.NewLine;
                    }
                }
            }
        }

        private void FillDataGridView(DateTime startDate, DateTime endDate)
        {
            // Create a dictionary to store the totals for each date
            Dictionary<string, decimal[]> totalsByDate = new Dictionary<string, decimal[]>();

            // Loop through each record in the list
            foreach (CsvRecord record in list)
            {
                // Parse the record's date string to a DateTime object
                DateTime recordDate = DateTime.Parse(record.Date);

                // Check if the record is within the specified date range
                if (recordDate >= startDate && recordDate <= endDate)
                {
                    // If the dictionary doesn't already have an entry for this date, add one
                    if (!totalsByDate.ContainsKey(record.Date))
                    {
                        totalsByDate[record.Date] = new decimal[4] { 0m, 0m, 0m, 0m };
                    }

                    // Update the totals for this date based on the activity type
                    switch (record.Activity)
                    {
                        case "Coding":
                            totalsByDate[record.Date][0] += record.Duration;
                            break;
                        case "Meeting":
                            totalsByDate[record.Date][1] += record.Duration;
                            break;
                        case "Break":
                            totalsByDate[record.Date][2] += record.Duration;
                            break;
                        default:
                            break;
                    }

                    // Update the total time for this date
                    totalsByDate[record.Date][3] += record.Duration;
                }
            }

            // Clear the grid view
            dataGridView_Logs.Rows.Clear();

            // Loop through the dates in the dictionary and add them to the grid view
            foreach (string date in totalsByDate.Keys)
            {
                decimal[] totals = totalsByDate[date];

                // Calculate the total time as a TimeSpan object
                TimeSpan totalTime = TimeSpan.FromHours((double)totals[3]);

                // Add a new row to the grid view
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView_Logs);
                row.Cells[0].Value = date;
                row.Cells[1].Value = FormatTimeSpan(TimeSpan.FromHours((double)totals[0]));
                row.Cells[2].Value = FormatTimeSpan(TimeSpan.FromHours((double)totals[1]));
                row.Cells[3].Value = FormatTimeSpan(TimeSpan.FromHours((double)totals[2]));
                row.Cells[4].Value = FormatTimeSpan(totalTime);

                // Set the cell text color based on the total duration of coding and meeting time
                TimeSpan codingMeetingTime = TimeSpan.FromHours((double)(totals[0] + totals[1]));
                if (codingMeetingTime < TimeSpan.FromHours(7.5))
                {
                    // Less than 7.5 hours
                    row.Cells[1].Style.ForeColor = Color.Red;
                    row.Cells[2].Style.ForeColor = Color.Red;
                }
                else if (codingMeetingTime > TimeSpan.FromHours(8))
                {
                    // More than 8 hours
                    row.Cells[1].Style.ForeColor = Color.Green;
                    row.Cells[2].Style.ForeColor = Color.Green;
                }

                dataGridView_Logs.Rows.Add(row);
            }

            dataGridView_Logs.CurrentCell = null;
        }

        // Helper method to format a TimeSpan object as a string in the format "hh:mm:ss"
        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

        private void dataGridView_Logs_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                decimal codingTime = 0m;
                decimal meetingTime = 0m;

                for (int i = 1; i <= 2; i++)
                {
                    
                    if (i == 1) // Coding Time column
                    {
                        codingTime = ConvertTimeToDecimal(dataGridView_Logs.Rows[e.RowIndex].Cells[i].Value.ToString());
                    }
                    else if (i == 2) // Meeting Time column
                    {
                        meetingTime = ConvertTimeToDecimal(dataGridView_Logs.Rows[e.RowIndex].Cells[i].Value.ToString());
                    }
                    
                }

                string tooltipText = string.Format("Coding + meeting time = {0}", TimeSpan.FromHours((double)(codingTime + meetingTime)).ToString("hh\\:mm\\:ss"));
                dataGridView_Logs.ShowCellToolTips = true;
                dataGridView_Logs.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = tooltipText;
            }
        }

        private static decimal ConvertTimeToDecimal(string timeString)
        {
            // Split the time string into hours, minutes, and seconds
            string[] timeParts = timeString.Split(':');

            // Parse the parts to integers
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);
            int seconds = int.Parse(timeParts[2]);

            // Calculate the decimal value of the time
            decimal decimalTime = hours + (minutes / 60m) + (seconds / 3600m);

            return decimalTime;
        }
    }
}
