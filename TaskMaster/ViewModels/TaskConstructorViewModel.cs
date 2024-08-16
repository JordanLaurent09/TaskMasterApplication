using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TaskMaster.Infrastructure.Commands;
using TaskMaster.Models;
using TaskMaster.Services;
using TaskMaster.ViewModels.BaseViewModel;
using TaskMaster.Views.Windows;

namespace TaskMaster.ViewModels
{
    public class TaskConstructorViewModel : ViewModelBase
    {
        private string _title;
        private string _description;
        private DateTime _deadLine;
        private string _priority;
        private string _departmentName;


        private ObservableCollection<string> _priorities;

        private ObservableCollection<string> _departments;



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

        public string DepartmentName
        {
            get => _departmentName;

            set
            {
                if (_departmentName != value)
                {
                    _departmentName = value;
                    OnPropertyChanged(nameof(DepartmentName));
                }
            }
        }

        public ObservableCollection<string> Priorities
        {
            get => _priorities;
            set
            {
                if(_priorities != value)
                {
                    _priorities = value;
                    OnPropertyChanged(nameof(Priorities));
                }
            }
        }

        public ObservableCollection<string> Departments
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


        private ObservableCollection<Models.Task> _tasks;
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

        public AddNewTaskWindow newWindow { get; set; }

        public TaskConstructorViewModel(ObservableCollection<Models.Task> tasks, List<Priority> priorities, List<Department> departments)
        {
            Priorities = ObservableConverter.GetPriorities(priorities);
            Departments = ObservableConverter.GetDepartmentNames(departments);

            CreatingTaskCommand = new LambdaCommand((object p) => true, OnCreatingTask);
            BackToMainWindowCommand = new LambdaCommand((object p) => true, OnBackToMainWindow);

            Tasks = tasks;

            newWindow = new AddNewTaskWindow();
            newWindow.DataContext = this;
            newWindow.Show();

        }


        public ICommand CreatingTaskCommand { get; set; }

        public ICommand BackToMainWindowCommand { get; set; }

        public void OnCreatingTask(object parameter)
        {
            Models.Task newTask = new Models.Task()
            {
                Title = Title,
                Description = Description,
                StartDate = DateTime.Now,
                DeadLine = DeadLine,
                Priority = Priority,
                Department = DepartmentName,
                Status = "Создана"
            };

            string taskJsonString = JsonOperations.JsonForNewTask(newTask);


            string cryptedTaskJsonString = Cypher.DecryptData(taskJsonString);

            HttpWork httpWork = new HttpWork();

            var serverResponse = httpWork.AddNewTAsk(cryptedTaskJsonString).Result;

            string serverResponseString = CSVReader.AddTaskServerResponse(serverResponse);
                
            string cryptedServerResponseString = Cypher.GetEncryptData(serverResponseString);


            if (cryptedServerResponseString == "Задача успешно добавлена")
            {
                MessageBox.Show(cryptedServerResponseString, "Удача", MessageBoxButton.OK, MessageBoxImage.Information);
                Tasks.Add(newTask);
            }
            else
            {
                
                MessageBox.Show(cryptedServerResponseString, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Title = string.Empty;
            Description = string.Empty;
            Priority = string.Empty;
            DepartmentName = string.Empty;
        }


        public void OnBackToMainWindow(object parameter)
        {
            newWindow.Close();
        }
    }
}
