using ReportPoliceSite.Model;
using System;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;

namespace ReportPoliceSite.ViewModel
{
    public class MakeReportViewModel : BaseViewModel
    {
        Core Core;
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

        public MakeReportViewModel(User user)
        {
            GetUserAuthID(user);
            Core = new Core();
            Report = new Report();
            Core.LoadReportsFromDB();
        }

        private RelayCommand _GenerateReportCommand;

        public RelayCommand GenerateReportCommand
        {
            get
            {
                if (_GenerateReportCommand == null)
                {
                    _GenerateReportCommand = new RelayCommand(MakeReport);
                }

                return _GenerateReportCommand;
            }
        }

        private void MakeReport(object commandParameter)
        {
            if ((String)Report.Content != null
                && (Int64)Report.PhoneNumber != 7
                && (String)Report.NumberPoliceSite != null
                && (String)Report.SelectedRegion != null)
            {
                Core.LoadReportsFromDB();
                string s = Report.Content;
                string[] part = s.Split(':');
                Report.Content = part[1];
                Report.RequestUserId = IDForReport;
                Report.ID = Core.Reports.Count;
                DateTime date = DateTime.Now;
                Report.RequestTime = date;
                Core.Reports.Add(Report);
                Core.SaveToFileReports();
                MessageBox.Show($"Заявление №{Report.ID} успешно сформировано");
            }
            else { MessageBox.Show("Заполните все поля для заявления"); }
        }
    }
}
