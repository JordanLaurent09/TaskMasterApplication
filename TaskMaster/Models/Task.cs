using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Models
{
    public enum Status
    {
        INPROCESS,
        DONE,
        OVERDUE
    }

    public enum Priority
    {
        ВЫСОКИЙ,
        СРЕДНИЙ,
        НИЗКИЙ
    }


    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }
}
