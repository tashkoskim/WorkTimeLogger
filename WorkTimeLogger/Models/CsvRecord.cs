using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLogger.Models
{
    public class CsvRecord
    {
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public decimal? Duration { get; set; }
        public string? Activity { get; set; }
        public string? Description { get; set; }
    }
}
