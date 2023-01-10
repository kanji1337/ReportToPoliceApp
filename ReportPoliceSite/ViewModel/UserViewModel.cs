using ReportPoliceSite.Model;

namespace ReportPoliceSite.ViewModel
{
    class UserViewModel : BaseViewModel
    {
        public User User;

        public UserViewModel(User user)
        {
            this.User = user;
        }

        public string Name
        {
            get { return User.Name; }
            set 
            {
                User.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Login
        {
            get { return User.Login; }
            set
            {
                User.Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Email
        {
            get { return User.Email; }
            set
            {
                User.Email = value;
                OnPropertyChanged("Email");
            }
        }

       
    }
}
