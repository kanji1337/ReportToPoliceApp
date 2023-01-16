using System.Windows.Input;
using System.Windows;
using System;
using ReportPoliceSite.Model;

namespace ReportPoliceSite.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        Core core;
        Action close;
        public User User { get; set; }


        public RegistrationViewModel(Core core, Action close)
        {
            this.core = core;
            this.close = close;

            User = new User();
        }

        private ICommand reg_Click;

        public ICommand Registration_Click
        {
            get
            {
                if (reg_Click == null)
                {
                    reg_Click = new RelayCommand(Registration);
                }

                return reg_Click;
            }
        }

        private void Registration(object commandParameter)
        {
            if ((String)User.Name != null
                && (String)User.Login != null
                && (String)User.Password != null
                && (String)User.Email != null)
            {
                User.ID = core.Users.Count;
                User.Role = UserRoles.User;
                core.Users.Add(User);
                core.SaveToFileData();
                MessageBox.Show($"Пользователь {User.Name} зарегестрирован");
                close();
            }
            else
            {
                MessageBox.Show("Пожалуйста заполните все поля");
            }
        }

    }
}
