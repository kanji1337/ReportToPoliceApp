using ReportPoliceSite.ViewModel;
using ReportPoliceSite.Model;
using ReportPoliceSite.View;
using System.Xml.Linq;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ReportPoliceSite.ViewModel
{
    public class UserReportsViewModel : BaseViewModel
    {
        private readonly ItemHandler _itemHandler;

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

        public void GetEveryReportOfUser(int UserID, ItemHandler _ItemHandler)
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
                    if (UserID == user_idI)
                    {
                        _ItemHandler.Add(new Item(idI, num_siteS, req_timeD, status));
                    }

                }
            }
        }

        public UserReportsViewModel(User user)
        {
            _itemHandler = new ItemHandler();
            Core = new Core();
            GetUserAuthID(user);
            GetEveryReportOfUser(IDForReport, _itemHandler);
        }
        public List<Item> Items
        {
            get { return _itemHandler.Items; }
        }
    }
    public class Item
    {
        public Item(int _ID, string _NumberPoliceSite, DateTime _RequestTime, string _Status)
        {
            Status = _Status;
            ID = _ID;
            NumberPoliceSite = _NumberPoliceSite;
            RequestTime = _RequestTime;
        }
        public string Status { get; set; }
        public int ID { get; set; }
        public string NumberPoliceSite { get; set; }
        public DateTime RequestTime { get; set; }
    }

    public class ItemHandler
    {
        public ItemHandler()
        {
            Items = new List<Item>();
        }

        public List<Item> Items { get; private set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
    }
}