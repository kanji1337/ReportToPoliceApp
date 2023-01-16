using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPoliceSite.Model
{
    public partial class Report
    {
        public int ID { get; set; }
        public int RequestUserId { get; set; }
        public string NumberPoliceSite { get; set; }
        public Int64 PhoneNumber { get; set; }
        public DateTime RequestTime { get; set; }
        public string SelectedRegion { get; set; }
        public string Content { get; set; }
    }
}
