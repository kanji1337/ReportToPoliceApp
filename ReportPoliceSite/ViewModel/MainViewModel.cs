

namespace ReportPoliceSite.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand RegistrationViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }

        public RegistrationViewModel RegistrationVm { get; set; }
        public LoginViewModel LoginVm{ get; set; }
        public HomeViewModel HomeVm{ get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() {
            HomeVm = new HomeViewModel();
            RegistrationVm = new RegistrationViewModel();
            LoginVm = new LoginViewModel();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVm;
            });

            RegistrationViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegistrationVm;
            });
        }
    }
}
