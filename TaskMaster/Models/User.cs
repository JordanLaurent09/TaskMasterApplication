using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ContactPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

        public bool IsResponsible { get; set; }

        public User() { }

        public User(string firstName, string lastName, DateTime birthday, string phone, string login, string password, string department, bool isResponsible)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            ContactPhone = phone;
            Login = login;
            Password = password;
            Department = department;
            IsResponsible = isResponsible;
        }
    }
}
