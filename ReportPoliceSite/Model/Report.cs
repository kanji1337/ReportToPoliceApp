using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPoliceSite.Model
{
    class Report
    {
        public int NumberPoliceSite { get; set; }
        public string RequestTime { get; set; }
        public string Content { get; set; }

        Report(int numb_of_police_site, string req_time, string content) {
            this.NumberPoliceSite = numb_of_police_site;
            this.RequestTime = req_time;
            this.Content = content;
        }
    }
}
