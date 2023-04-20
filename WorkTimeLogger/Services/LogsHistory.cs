using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using WorkTimeLogger.Constants;
using WorkTimeLogger.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace WorkTimeLogger.Services
{
    public static class LogsHistory
    {
        public static List<CsvRecord> ReadCSVFiles(DateTime startDate, DateTime endDate)
        {
            List<CsvRecord> logEntries = new List<CsvRecord>();
            string logsPath = GeneralConstants.logsFolder;

            // Loop through all year folders
            foreach (string yearDir in Directory.GetDirectories(logsPath))
            {
                int year = Int32.Parse(new DirectoryInfo(yearDir).Name);

                // Only process years within range
                if (year < startDate.Year || year > endDate.Year)
                    continue;

                // Loop through all month folders
                foreach (string monthDir in Directory.GetDirectories(yearDir))
                {
                    int month = Int32.Parse(new DirectoryInfo(monthDir).Name);

                    // Only process months within range
                    if (year == startDate.Year && month < startDate.Month)
                        continue;
                    if (year == endDate.Year && month > endDate.Month)
                        continue;

                    // Loop through all CSV files in the month folder
                    foreach (string csvFile in Directory.GetFiles(monthDir, "*.csv"))
                    {
                        DateTime fileDate = getDateFromFile(csvFile);

                        if (!(fileDate >= startDate && fileDate <= endDate))
                            continue;

                        using (var reader = new StreamReader(csvFile))
                        {
                            // Skip first line (header)
                            reader.ReadLine();

                            // Loop through all lines and add to logEntries list
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                DateTime date = DateTime.ParseExact(values[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                                // Only process entries within range
                                //if (date < startDate || date > endDate)
                                //    continue;

                                CsvRecord entry = new CsvRecord()
                                {
                                    StartTime = values[0],
                                    EndTime = values[1],
                                    Duration = Decimal.Parse(values[2].Replace('.', ',')),
                                    Date = date.ToString("dd.MM.yyyy"),
                                    Activity = values[4],
                                    Description = values[5]
                                };
                                logEntries.Add(entry);
                            }
                        }
                    }
                }
            }
            return logEntries;
        }

        private static DateTime getDateFromFile(string file)
        {
            string datePom = "";
            string[] subFolders = file.Split('\\');
            string[] dateElements = subFolders[subFolders.Length - 1].Split('_');
            if (dateElements.Length >= 3)
            {
                datePom = $"{dateElements[0]}.{dateElements[1]}.{dateElements[2]}";
            }
            return Convert.ToDateTime(datePom);
        }



        public static void CreateExcelReport(List<CsvRecord> data)
        {
            bool errorCatch = false;

            // Create a new Excel Application object
            Excel.Application excel = null;

            // Create a new workbook
            Excel.Workbook workbook = null;

            // Get the first worksheet in the workbook
            Excel.Worksheet worksheet = null;
            object misValue = System.Reflection.Missing.Value;

            string excelFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), $"WorkTimeLog_{Environment.UserName}.xlsx");

            try
            {
                excel = new Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }
                excel.DisplayAlerts = false;
                excel.UserControl = false;

                workbook = excel.Workbooks.Add(misValue);
                worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

                // Set the column headings
                worksheet.Cells[1, 1].Value = "StartTime";
                worksheet.Cells[1, 2].Value = "EndTime";
                worksheet.Cells[1, 3].Value = "Duration";
                worksheet.Cells[1, 4].Value = "Date";
                worksheet.Cells[1, 5].Value = "Activity";
                worksheet.Cells[1, 6].Value = "Description";

                // Fill the worksheet with data from the list of CsvRecord objects
                for (int i = 0; i < data.Count; i++)
                {
                    CsvRecord record = data[i];
                    worksheet.Cells[i + 2, 1].Value = record.StartTime;
                    worksheet.Cells[i + 2, 2].Value = record.EndTime;
                    worksheet.Cells[i + 2, 3].Value = record.Duration;
                    worksheet.Cells[i + 2, 4].Value = record.Date;
                    worksheet.Cells[i + 2, 5].Value = record.Activity;
                    worksheet.Cells[i + 2, 6].Value = record.Description;
                }

                // Auto-fit the columns to the contents
                worksheet.Columns.AutoFit();

                // Save the workbook, replace the file if it already exists
                workbook.SaveAs(excelFile);
            }
            catch (Exception ex)
            {
                errorCatch = true;
                MessageBox.Show(ex.Message, "Error while create/open excel file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excel != null) Marshal.ReleaseComObject(excel);

                // Release all Excel-related resources
                worksheet = null;
                workbook = null;
                excel = null;

                // Call garbage collector
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (errorCatch == false)
                {
                    // Open the Excel file using the default program for Excel files
                    Process.Start(new ProcessStartInfo(excelFile) { UseShellExecute = true });
                }

                // Quit the Excel application and release its resources
                if (excel != null)
                {
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                    excel = null;
                }
            }
        }

    }
}
