namespace TaskMaster.Models
{
    public class Data
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Priority> Priorities { get; set; } = new List<Priority>();
        public List<Status> Statuses { get; set; } = new List<Status>();
    }
}
