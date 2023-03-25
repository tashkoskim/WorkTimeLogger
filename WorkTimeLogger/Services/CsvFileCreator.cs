using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTimeLogger.Constants;
using WorkTimeLogger.Models;

namespace WorkTimeLogger.Services
{
    public static class CsvFileCreator
    {
        public static List<CsvRecord>? CreateCsvFile()
        {
            string csvFileName = GetCsvFilePath();
            
            if (!File.Exists(csvFileName))
            {
                // Creates a new csv file
                using (StreamWriter writer = new StreamWriter(csvFileName))
                {
                    writer.WriteLine("StartTime,EndTime,Duration,Activity,Description");
                }
            }else
            {
                // read the existing csv
                return ReadCsv(csvFileName);
            }
            return null;
        }

        public static string[] GetLastCsvRow(string filePath)
        {
            string[] lastRow = null;

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lastRow = line.Split(',');
                    }
                }
            }

            return lastRow;
        }

        public static void InsertCsvRow(string description, string activityType, int edit)
        {
            string csvFilePath = GetCsvFilePath();

            CsvRecord record = new CsvRecord()
            {
                StartTime = DateTime.Now.ToString("HH:mm"),
                EndTime = "-",
                Duration = 0,
                Activity = activityType,
                Description = description
            };

            if(edit == 0)
            {
                // The first time when the file is created
                if (GeneralConstants.listRecords == null)
                {
                    // Just insert the row in the list
                    GeneralConstants.listRecords = new List<CsvRecord>();
                    GeneralConstants.listRecords.Add(record);
                    WriteCsvRow(csvFilePath);
                }
                else if (GeneralConstants.listRecords.Count >= 0)
                {
                    CsvRecord lastRecord = GeneralConstants.listRecords.Last();
                    // If there are other records already, first you must close the previous event
                    if (DateTime.TryParseExact(lastRecord.StartTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime) &&
            DateTime.TryParseExact(DateTime.Now.ToString("HH:mm"), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endTime))
                    {
                        if(lastRecord.EndTime == "-")
                        {
                            lastRecord.EndTime = endTime.ToString("HH:mm");
                            lastRecord.Duration = CalculateDuration(startTime, endTime);
                        }
                        // Add the new record
                        GeneralConstants.listRecords.Add(record);
                        WriteCsvRow(csvFilePath);

                    }

                }
            }else if(edit == 1)
            {
                // Edit description
                WriteCsvRow(csvFilePath);
            }else if(edit == 2)
            {
                // Close the today's log
                CsvRecord lastRecord = GeneralConstants.listRecords.Last();
                // If there are other records already, first you must close the previous event
                if (DateTime.TryParseExact(lastRecord.StartTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime) &&
        DateTime.TryParseExact(DateTime.Now.ToString("HH:mm"), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endTime))
                {
                    lastRecord.EndTime = endTime.ToString("HH:mm");
                    lastRecord.Duration = CalculateDuration(startTime, endTime);                   
                    WriteCsvRow(csvFilePath);

                }
            }

        }

        private static void WriteCsvRow(string csvPath)
        {            
            // Write the rows to the CSV file
            using (StreamWriter sw = new StreamWriter(csvPath))
            {
                sw.WriteLine("StartTime,EndTime,Duration,Activity,Description");
                foreach (CsvRecord r in GeneralConstants.listRecords)
                {
                    string row = r.StartTime + "," + r.EndTime + "," + r.Duration.ToString().Replace(",",".") + "," + r.Activity + "," + r.Description.Replace(","," ");

                    sw.WriteLine(row);
                }
                
            }
        }

        public static List<decimal> GetTotalHrs()
        {
            // coding, meeting, break
            List<decimal> totalHrs = new List<decimal> { 0.0m, 0.0m, 0.0m };

            if (GeneralConstants.listRecords != null)
            {
                foreach (CsvRecord r in GeneralConstants.listRecords)
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
                        if (DateTime.TryParseExact(r.StartTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime) &&
                DateTime.TryParseExact(DateTime.Now.ToString("HH:mm"), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endTime))
                        {

                            decimal pomDuration = CalculateDuration(startTime, endTime);

                            if (r.Activity == "Coding")
                            {
                                totalHrs[0] += pomDuration;
                            }
                            else if (r.Activity == "Meeting")
                            {
                                totalHrs[1] += pomDuration;
                            }
                            else if (r.Activity == "Break")
                            {
                                totalHrs[2] += pomDuration;
                            }
                        }
                    }
                }
            }

            return totalHrs;
        }

        private static decimal CalculateDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;
            decimal durationInHours = (decimal)duration.TotalMinutes / 60;
            return Math.Round(durationInHours, 2);
        }

        private static List<CsvRecord> ReadCsv(string filePath)
        {
            List<CsvRecord> records = new List<CsvRecord>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int no = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(no>0)
                        {
                            string[] fields = line.Split(',');
                            if (fields.Length == 5)
                            {
                                CsvRecord record = new CsvRecord()
                                {
                                    StartTime = fields[0],
                                    EndTime = fields[1],
                                    Duration = Decimal.Parse(fields[2].Replace(".",",")),
                                    Activity = fields[3],
                                    Description = fields[4]
                                };
                                records.Add(record);
                            }
                        }
                        no++;
                    }
                }
            }
            return records;
        }

        private static string GetCsvFilePath()
        {
            string logFolder = GeneralConstants.logsFolder;

            // Create Logs folder if it doesn't exist
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            // Create subfolder for the current year if it doesn't exist
            string yearFolder = Path.Combine(logFolder, DateTime.Now.Year.ToString());
            if (!Directory.Exists(yearFolder))
            {
                Directory.CreateDirectory(yearFolder);
            }

            // Create subfolder for the current month if it doesn't exist
            string monthFolder = Path.Combine(yearFolder, DateTime.Now.ToString("MM"));
            if (!Directory.Exists(monthFolder))
            {
                Directory.CreateDirectory(monthFolder);
            }

            // Create CSV file for the current date and logged-in user if it doesn't exist
            string csvFileName = Path.Combine(monthFolder, $"{DateTime.Now.ToString("dd_MM_yyyy")}_{Environment.UserName}.csv");

            return csvFileName;
        }
    }
}
