using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class User
    {
        public string UsernameType { get; set; }
        public string Password { get; set; }

        public User (string username, string password)
        {
            this.UsernameType = username;
            this.Password = password;
        }


    }
}
