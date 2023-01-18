using System;
using ReportPoliceSite.Model;
using System.Windows.Input;
using ReportPoliceSite.ViewModel;

namespace ReportPoliceSite.ViewModel
{
    public class PoliceViewModel : BaseViewModel
    {
        public RelayCommand HomeViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public RelayCommand ViewReportsCommand { get; set; }
        public PoliceReportsViewModel ViewReportsVm { get; set; }

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

        private object _PoliceName;

        public object PoliceName
        {
            get { return _PoliceName; }
            set
            {
                _PoliceName = value;
                OnPropertyChanged();
            }
        }

        Core core;
        Action close;
        public PoliceViewModel(Core core, Action close, User police)
        {
            PoliceName = police.Name;
            this.close = close;
            this.core = core;

            ViewReportsVm = new PoliceReportsViewModel();
            HomeVm = new HomeViewModel();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            ViewReportsCommand = new RelayCommand(o =>
            {
                CurrentView = ViewReportsVm;
            });
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
