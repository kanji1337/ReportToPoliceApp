using ReportPoliceSite.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;
using ReportPoliceSite.Model;

namespace ReportPoliceSite.ViewModel
{
    public class PoliceReportsViewModel
    {
        private readonly ItemHandler _itemHandler;

        static Core Core;
        public string user_nameS;
        public Report Report { get; set; }

        public void GetEveryName(int report_us_idS)
        {
            XDocument xdoc = XDocument.Load("UsersDataBase.xml");
            XElement db = xdoc.Element("ArrayOfUser");
            if (db != null)
            {
                foreach (XElement user in db.Elements("User"))
                {
                    XElement user_id = user.Element("ID");
                    int user_idI = (int)user_id;
                    if (report_us_idS == user_idI)
                    {
                        XElement user_name = user.Element("Name");
                        user_nameS = (string)user_name;
                    }
                }
            }
        }

        public void GetEveryReportOfUser( ItemHandler _ItemHandler)
        {
            XDocument xdoc = XDocument.Load("ReportsDataBase.xml");
            XElement db = xdoc.Element("ArrayOfReport");
            if (db != null)
            {
                foreach (XElement report in db.Elements("Report"))
                {
                    XElement report_us_id = report.Element("RequestUserId");
                    int report_us_idS = (int)report_us_id;
                    GetEveryName(report_us_idS);
                    XElement id = report.Element("ID");
                    int idI = (int)id;
                    XElement phone_num = report.Element("PhoneNumber");
                    Int64 phone_numI = (Int64)phone_num;
                    XElement num_site = report.Element("NumberPoliceSite");
                    string num_siteS = (String)num_site;
                    XElement req_time = report.Element("RequestTime");
                    DateTime req_timeD = (DateTime)req_time;
                    string status = "В рассмотрении";
                    _ItemHandler.Add(new PoliceItem(idI, user_nameS, req_timeD, phone_numI, status));
                }
            }
        }
        public class PoliceItem 
        {
            public PoliceItem(int _ID, string _Name, DateTime _RequestTime, Int64 _PhoneNumber, string _Status)
            {
                PID = _ID;
                PName = _Name;
                PRequestTime = _RequestTime;
                PhoneNumber = _PhoneNumber;
                PStatus = _Status;
            }

            public string  PStatus{ get; set; }
            public int PID{ get; set; }
            public string PName { get; set; }
            public Int64 PhoneNumber { get; set; }
            public DateTime PRequestTime { get; set; }
        }
        public class ItemHandler
        {
            public ItemHandler()
            {
                Items = new List<PoliceItem>();
            }

            public List<PoliceItem> Items { get; private set; }

            public void Add(PoliceItem item)
            {
                Items.Add(item);
            }
        }
        public PoliceReportsViewModel()
        {
            _itemHandler = new ItemHandler();
            Core = new Core();
            Core.LoadReportsFromDB();
            GetEveryReportOfUser( _itemHandler);
        }
        public List<PoliceItem> Items
        {
            get { return _itemHandler.Items; }
        }

        private RelayCommand saveReports;

        public ICommand SaveReports
        {
            get
            {
                if (saveReports == null)
                {
                    saveReports = new RelayCommand(PerformSaveReports);
                }

                return saveReports;
            }
        }

        private void PerformSaveReports(object commandParameter)
        {
        }
    }
}
