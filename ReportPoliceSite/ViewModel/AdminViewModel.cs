using System;
using ReportPoliceSite.Model;
using System.Windows.Input;
using ReportPoliceSite.ViewModel;

namespace ReportPoliceSite.ViewModel
{
    class AdminViewModel
    {
        Core core;
        Action close;
        string AdminName { get; set; }
        public AdminViewModel(Core core, Action close, User admin)
        {
            AdminName = admin.Name;
            this.core = core;
            this.close = close;
        }

        private ICommand exitUserCommand;

        public ICommand ExitUserCommand
        {
            get
            {
                if (exitUserCommand == null)
                {
                    exitUserCommand = new RelayCommand(ExitUser);
                }

                return exitUserCommand;
            }
        }

        private void ExitUser(object commandParameter)
        {
            close();
        }
    }
}
