using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPoliceSite.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string login, string password, string email, string name)
        {
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.Email = email;
        }

    }
}
