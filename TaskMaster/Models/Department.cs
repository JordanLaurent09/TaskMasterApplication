using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User currentUser { get; set; } //?
        public List<User> Users { get; set; } = new List<User>();
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
