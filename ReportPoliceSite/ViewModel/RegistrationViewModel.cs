using System.Windows.Input;
using System.Windows;

namespace ReportPoliceSite.ViewModel
{
    public class RegistrationViewModel
    {
        private ICommand reg_Click;

        public ICommand Registration_Click
        {
            get
            {
                if (reg_Click == null)
                {
                    reg_Click = new RelayCommand(PerformRegistration_Click);
                }

                return reg_Click;
            }
        }

        private void PerformRegistration_Click(object commandParameter)
        {
            MessageBox.Show("Hello");
        }

    }
}
