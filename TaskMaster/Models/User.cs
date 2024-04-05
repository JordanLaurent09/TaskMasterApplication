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
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string ContactPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }

        public User() { }

        public User(string name, string surname, DateTime birthday, string phone, string login, string password, string department)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            ContactPhone = phone;
            Login = login;
            Password = password;
            Department = department;
        }
    }
}
