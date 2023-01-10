using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPoliceSite.Model
{
    class Police
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Police(string login, string password, string name)
        {
            this.Name = name;
            this.Login = login;
            this.Password = password;
        }
    }
}
