using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskMaster.ViewModels.BaseViewModel;
using TaskMaster.Infrastructure.Commands;
using System.Collections.ObjectModel;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Models.Task> _tasks;
        private Models.Task _currentTask;        
        private User _currentUser;
        private ObservableCollection<Department> _departments;

        // Данные пользователя
        //private string _firstName;
        //private string _lastName;
        //private DateTime _birthday;
        //private string _contactPhone;
        //private string _login;
        //private string _password;
        //private string _department;
        //private bool _isResponsible;

        // данные отдела
        private string _departmentName;

        // данные добавляемой задачи

        private string _title;
        private string _description;
        private DateTime _deadLine;
        private string _priority;





        private ObservableCollection<Prior> _priorities;

        public ObservableCollection<Prior> Priorities
        {
            get => _priorities;
            set
            {
                if (_priorities != value)
                {
                    _priorities = value;
                    OnPropertyChanged(nameof(Priorities));
                }
            }
        }



        public string DepartmentName
        {
            get => _departmentName;
            set
            {
                if(_departmentName != value)
                {
                    _departmentName = value;
                    OnPropertyChanged(nameof(DepartmentName));
                }
            }
        }


        public string Title
        {
            get => _title;
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
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public DateTime DeadLine
        {
            get => _deadLine;
            set
            {
                if (_deadLine != value)
                {
                    _deadLine = value;
                    OnPropertyChanged(nameof(DeadLine));
                }
            }
        }

        public string Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }


        public ObservableCollection<Models.Task> Tasks
        {
            get => _tasks;
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }

        public Models.Task CurrentTask
        {
            get => _currentTask;
            set
            {
                if (_currentTask != value)
                {
                    _currentTask = value;
                    OnPropertyChanged(nameof(CurrentTask));
                }
            }
        }
       

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged(nameof(CurrentUser));
                }
            }
        }

        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged(nameof(Departments));
                }
            }
        }

        

        public MainViewModel(ObservableCollection<Models.Task> tasks, User currentUser)
        {
            Tasks = tasks;
            CurrentUser = currentUser;

            CreateTaskCommand = new LambdaCommand((object p) => true, OnCreatingTask);
            CloseTheApplicationCommand = new LambdaCommand((object p) => true, OnClosingAnApp);

            // Тестовая область
            Priorities = new ObservableCollection<Prior>();
            Priorities.Add(new Prior() { PriorityType = "ВЫСОКИЙ" });
            Priorities.Add(new Prior() { PriorityType = "СРЕДНИЙ" });
            Priorities.Add(new Prior() { PriorityType = "НИЗКИЙ" });


            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = this;
            mainWindow.Show();
            
        }

        public ICommand ShowDepartmentsListCommand { get; set; }

        public ICommand CreateTaskCommand { get; set; }

        public ICommand CloseTheApplicationCommand { get; set; }

        public ICommand MakeTheReportCommand { get; set; }


        public void OnCreatingTask(object parameter)
        {
            Models.Task newTask = new Models.Task() {Title = Title, Description = Description, 
                StartDate = DateTime.Now, DeadLine = DeadLine, Priority = Priority, Department = DepartmentName};

            string taskJsonString = JsonOperations.JsonForNewTask(newTask);

            HttpWork httpWork = new HttpWork();

            var serverResponse = httpWork.AddNewTAsk(taskJsonString).Result;

            string serverResponseString = CSVReader.AddTaskServerResponse(serverResponse);

            MessageBox.Show(serverResponseString);
        }

        public void OnClosingAnApp(object parameter)
        {
            Application.Current.Shutdown();
        }

        //private ObservableCollection<Task> _tasks;

        //public ObservableCollection<Task> Tasks
        //{
        //    get => _tasks;

        //    set
        //    {
        //        if (_tasks != value)
        //        {
        //            _tasks = value;
        //            OnPropertyChanged(nameof(Tasks));
        //        }
        //    }
        //}

        //public MainViewModel()
        //{
        //    _tasks = new ObservableCollection<Task>();
        //}
    }

    public class Prior
    {
        public string ?PriorityType { get; set; }
    }
}
