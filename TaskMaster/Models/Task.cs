﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Models
{
    

    public class Task
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string ?Status { get; set; }
        public string ?Priority { get; set; }
    }
}
