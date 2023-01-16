using ReportPoliceSite.ViewModel;
using ReportPoliceSite.Model;
using ReportPoliceSite.View;
using System.Xml.Linq;
using System;
using System.Collections.ObjectModel;

namespace ReportPoliceSite.ViewModel
{
    public class UserReportsViewModel : BaseViewModel
    {
        static Core Core;
        public Report Report { get; set; }

        public int IDForReport;
        public void GetUserAuthID(User user)
        {
            XDocument xdoc = XDocument.Load("UsersDataBase.xml");
            XElement db = xdoc.Element("ArrayOfUser");
            if (db != null)
            {
                foreach (XElement _user in db.Elements("User"))
                {
                    XElement login = _user.Element("Login");
                    string loginS = (String)login;
                    XElement id = _user.Element("ID");
                    int idS = (int)id;
                    if (user.Login == loginS)
                    {
                        IDForReport = idS;
                    }
                }
            }
        }

        public void GetEveryReportOfUser(int UserID, ObservableCollection<UserReports> items)
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
                    if (UserID == user_idI)
                    {
                        items.Add(new UserReports() { ReportID = idI, SelectedSite = num_siteS, RequestTime = req_timeD });
                        ReportID = idI;
                        SelectedSite = num_siteS;
                        RequestTime = req_timeD;
                    }
                }
            }
        }

        private int _ReportID;

        public int ReportID
        {
            get { return _ReportID; }
            set
            {
                _ReportID = value;
                OnPropertyChanged();
            }
        }

        private string _SelectedSite;

        public string SelectedSite
        {
            get { return _SelectedSite; }
            set
            {
                _SelectedSite = value;
                OnPropertyChanged();
            }
        }

        private DateTime _RequestTime;

        public DateTime RequestTime
        {
            get { return _RequestTime; }
            set
            {
                _RequestTime = value;
                OnPropertyChanged();
            }
        }


        public class UserReports
        { 
            public int ReportID { get; set; }
            public string SelectedSite { get; set; }
            public DateTime RequestTime { get; set; }
        }

        public UserReportsViewModel(User user)
        {
            ObservableCollection<UserReports> items = new ObservableCollection<UserReports>();
            Core = new Core();
            Report = new Report();
            Core.LoadReportsFromDB();
            GetUserAuthID(user);
            GetEveryReportOfUser(IDForReport, items);
        }
    }
}
