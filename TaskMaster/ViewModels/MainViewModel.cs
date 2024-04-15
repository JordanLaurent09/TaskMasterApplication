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

namespace TaskMaster.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Models.Task> _tasks;
        private Models.Task _currentTask;
        private User _currentUser;
        private ObservableCollection<Department> _departments;

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

        public MainViewModel() { }

        public MainViewModel(ObservableCollection<Models.Task> tasks, User currentUser)
        {
            Tasks = tasks;
            CurrentUser = currentUser;
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = this;
            mainWindow.Show();
        }

        public ICommand ShowDepartmentsList { get; set; }
        public ICommand CreateTask { get; set; }



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
}
