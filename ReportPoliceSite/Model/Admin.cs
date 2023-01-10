using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPoliceSite.Model
{
    class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }

        Admin(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
