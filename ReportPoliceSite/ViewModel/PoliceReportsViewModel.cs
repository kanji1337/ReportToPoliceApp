using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ReportPoliceSite.Model;

namespace ReportPoliceSite.ViewModel
{
    public class PoliceReportsViewModel
    {
        private readonly ItemHandler _itemHandler;

        static Core Core;
        public Report Report { get; set; }
        public void GetEveryReportOfUser( ItemHandler _ItemHandler)
        {
            XDocument xdoc = XDocument.Load("ReportsDataBase.xml");
            XElement db = xdoc.Element("ArrayOfReport");
            if (db != null)
            {
                foreach (XElement report in db.Elements("Report"))
                {
                    XElement user_id = report.Element("RequestUserId");
                    int user_idI = (int)user_id;
                    XElement id = report.Element("ID");
                    int idI = (int)id;
                    XElement num_site = report.Element("NumberPoliceSite");
                    string num_siteS = (String)num_site;
                    XElement req_time = report.Element("RequestTime");
                    DateTime req_timeD = (DateTime)req_time;
                    string status = "В рассмотрении";
                    _ItemHandler.Add(new Item(idI, num_siteS, req_timeD, status));
                }
            }
        }

        public PoliceReportsViewModel()
        {
            _itemHandler = new ItemHandler();
            Core = new Core();
            Core.LoadReportsFromDB();
            GetEveryReportOfUser( _itemHandler);
        }
        public List<Item> Items
        {
            get { return _itemHandler.Items; }
        }
    }
}
