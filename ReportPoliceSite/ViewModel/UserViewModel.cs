using ReportPoliceSite.Model;
using ReportPoliceSite.ViewModel;
using System;

namespace ReportPoliceSite.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public RelayCommand HomeViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public RelayCommand GenerateReportCommand { get; set; }
        public MakeReportViewModel MakeReportVm { get; set; }
        public RelayCommand ViewReportsCommand { get; set; }
        public UserReportsViewModel ViewReportsVm { get; set; }

        Core core;
        Action close;

        private string _user_name;

        public string UserName
        {
            get { return _user_name; }
            set
            {
                _user_name = value;
                OnPropertyChanged();
            }
        }



        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel(Core core, Action close, User user)
        {
            UserName = user.Name;
            this.core = core;
            this.close = close;

            ViewReportsVm = new UserReportsViewModel(user);
            HomeVm = new HomeViewModel();
            MakeReportVm = new MakeReportViewModel(user);
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            ViewReportsCommand = new RelayCommand(o =>
            {
                CurrentView = ViewReportsVm;
            });

            GenerateReportCommand = new RelayCommand(o =>
            {
                CurrentView = MakeReportVm;
            });
        }

        private RelayCommand _exitUserCommand;

        public RelayCommand ExitUserCommand
        {
            get
            {
                if (_exitUserCommand == null)
                {
                    _exitUserCommand = new RelayCommand(Exit_Click);
                }

                return _exitUserCommand;
            }
        }

        private void Exit_Click(object commandParameter)
        {
            close();
        }
    }
}
