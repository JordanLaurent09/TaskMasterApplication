using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Models;
using TaskMaster.ViewModels.BaseViewModel;

namespace TaskMaster.ViewModels
{
    public class CreateTaskViewModel : ViewModelBase
    {
        private string ?_title;
        private string ?_description;
        private DateTime _deadline;
        private string ?_priority;
        private ObservableCollection<Department> ?_departments;

        public string Title
        {
            get => _title!;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get => _description!;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime Deadline
        {
            get => _deadline;
            set
            {
                if (_deadline != value)
                {
                    _deadline = value;
                    OnPropertyChanged(nameof(Deadline));
                }
            }
        }

        public string Priority
        {
            get => _priority!;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        public ObservableCollection<Department> Departments
        {
            get => _departments!;
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged(nameof(Departments));
                }
            }
        }
    }
}
