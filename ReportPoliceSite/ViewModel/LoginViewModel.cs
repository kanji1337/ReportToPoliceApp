using System.Xml.Linq;
using System.Windows.Input;
using ReportPoliceSite.Model;
using System.Windows;
using System.Collections.ObjectModel;

namespace ReportPoliceSite.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public User user;
        public User UserAuthInfo
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        protected void GetUser()
        {
            XDocument xdoc = XDocument.Load("DataBase.xml");
            XElement PoliceReportData = xdoc.Element("PoliceReportData");
            if (PoliceReportData != null) 
            {
                foreach (XElement user in PoliceReportData.Elements("user"))
                {
                    XAttribute name = user.Attribute("name");
                    XElement login = user.Element("login");
                    XElement password = user.Element("password");

                    MessageBox.Show($"Person: {login?.Value} Password: {password?.Value}");
                }
            }
        }
        private ICommand login_Click;
        public ICommand Login_Click
        {
            get
            {
                if (login_Click == null)
                {
                    login_Click = new RelayCommand(PerformLogin_Click);}
        
                return login_Click;
            }
        }

        public void PerformLogin_Click(object parametr)
        {
            GetUser();
        } 
    }
}


