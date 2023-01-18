using System.Windows.Input;
using ReportPoliceSite.Model;
using System.Windows.Controls;
using System.Xml.Linq;
using System;
using System.Windows;
using System.Linq;
using ReportPoliceSite.View;
using ReportPoliceSite.ViewModel;

namespace ReportPoliceSite.ViewModel
{

    public class LoginViewModel : BaseViewModel
    {
        static Core Core;
        public User User { get; set; }
        public Police Police { get; set; }
        public Admin Admin { get; set; }

        public LoginViewModel() 
        {
            Core = new Core();
            User = new User();
            Police = new Police();
            Admin = new Admin();

            Core.LoadFromDB();
        }

        private void Auth(object obj)
        {
            var passwordBox = obj as PasswordBox;
            if (passwordBox == null) { return; }
            var password = passwordBox.Password;


            void GetUserAuth(XElement db)
            {
                foreach (XElement user in db.Elements("User"))
                {
                    XElement role = user.Element("Role");
                    string roleS = (String)role;
                    XElement login = user.Element("Login");
                    string loginS = (String)login;
                    XElement pass = user.Element("Password");
                    string passS = (String)pass;
                    if ((User.Login == loginS) && (password == passS) && (roleS == "User"))
                    {
                        XElement name = user.Element("Name");
                        string nameS = (String)name;
                        User.Name = nameS;

                        UserView user_view = new UserView();
                        UserViewModel dataContext = new UserViewModel(Core, user_view.Close, User);
                        user_view.DataContext = dataContext;
                        user_view.Show();
                    }
                }
            }

            void GetAdminAuth(XElement db)
            {
                foreach (XElement admin in db.Elements("User"))
                {
                    XElement role = admin.Element("Role");
                    string roleS = (String)role;
                    XElement login = admin.Element("Login");
                    string loginS = (String)login;
                    XElement pass = admin.Element("Password");
                    string passS = (String)pass;
                    if ((User.Login == loginS) && (password == passS) && (roleS == "Admin"))
                    {
                        XElement name = admin.Element("Name");
                        string nameS = (String)name;
                        User.Name = nameS;

                        AdminManView admin_view = new AdminManView();
                        AdminViewModel dataContext = new AdminViewModel(Core, admin_view.Close, User);
                        admin_view.DataContext = dataContext;
                        admin_view.Show();
                    }
                }
            }

            void GetPoliceAuth(XElement db)
            {
                foreach (XElement police in db.Elements("User"))
                {
                    XElement role = police.Element("Role");
                    string roleS = (String)role;
                    XElement login = police.Element("Login");
                    string loginS = (String)login;
                    XElement pass = police.Element("Password");
                    string passS = (String)pass;
                    if ((User.Login == loginS) && (password == passS) && (roleS == "PoliceMan"))
                    {
                        XElement name = police.Element("Name");
                        string nameS = (String)name;
                        User.Name = nameS;
                        PoliceManView police_view = new PoliceManView();
                        PoliceViewModel dataContext = new PoliceViewModel(Core, police_view.Close, User);
                        police_view.DataContext = dataContext;
                        police_view.Show();
                    }
                }
            }

            void GetUserAuthInfo()
            {
                XDocument xdoc = XDocument.Load("UsersDataBase.xml");
                XElement db = xdoc.Element("ArrayOfUser");
                if (db != null)
                {
                    GetAdminAuth(db);
                    GetUserAuth(db);
                    GetPoliceAuth(db);
                }
            }
            GetUserAuthInfo();
        }


        public ICommand AuthCommand
        {
            get
            {   
                return new RelayCommand((obj) =>
                {
                    Auth(obj);
                });
            }
        }

        private ICommand regCommand;

        public ICommand RegCommand
        {
            get
            {
                if (regCommand == null)
                {
                    regCommand = new RelayCommand(Reg);
                }

                return regCommand;
            }
        }

        private void Reg(object commandParameter)
        {
            Registration reg_view = new Registration();
            RegistrationViewModel dataContext = new RegistrationViewModel(Core, reg_view.Close);
            reg_view.DataContext = dataContext;
            reg_view.Show();
        }
        ~LoginViewModel() 
        {
            Core.SaveToFileData();  
        }
    }
}


