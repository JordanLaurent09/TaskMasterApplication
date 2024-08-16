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
using System.Windows.Threading;

namespace TaskMaster.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Models.Task> _tasks;
        private Models.Task _currentTask;        
        private User _currentUser;      
        private ObservableCollection<string> _statuses;
        private List<Priority> _primaryPriorities = new List<Priority>();
        private List<Department> _primaryDepartments = new List<Department>();

        private Dispatcher _dispatcher = Application.Current.Dispatcher;

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

        
        public ObservableCollection<string> Statuses
        {
            get => _statuses;
            set
            {
                if(_statuses != value)
                {
                    _statuses = value;
                    OnPropertyChanged(nameof(Statuses));
                }
            }
        }

        public MainViewModel(ObservableCollection<Models.Task> tasks, User currentUser, List<Department> departments, List<Status> statuses, List<Priority> priorities)
        {
            Tasks = ObservableConverter.SortTasksCollection(tasks);
            CurrentUser = currentUser;


            CurrentTask = tasks[0];

            Statuses = ObservableConverter.GetStatusTypes(statuses);

            _primaryDepartments = departments;

            _primaryPriorities = priorities;

            CreateTaskCommand = new LambdaCommand((object p) => true, OnCreatingTask);
            CloseTheApplicationCommand = new LambdaCommand((object p) => true, OnClosingAnApp);            
            ShowUserDataCommand = new LambdaCommand((object p) => true, OnOpenProfileCommand);
            ChangeStatusCommand = new LambdaCommand((object p) => true, OnChangingStatus);
            MakeTheReportCommand = new LambdaCommand((object p) => true, OnMakeReport);
           


            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = this;
            mainWindow.Show();
            
        }

        
        /// <summary>
        /// Команда, обеспечивающая переход к окну с функционалом создания новой задачи
        /// </summary>
        public ICommand CreateTaskCommand { get; set; }

        /// <summary>
        /// Команда, завершающая работу с приложением
        /// </summary>
        public ICommand CloseTheApplicationCommand { get; set; }

        /// <summary>
        /// Команда, формирующая отчет о задачах
        /// </summary>
        public ICommand MakeTheReportCommand { get; set; }

        /// <summary>
        /// Команда для загрузки окна личного кабинета
        /// </summary>
        public ICommand ShowUserDataCommand { get; set; }

        /// <summary>
        /// Команда для изменения статуса конкретной задачи
        /// </summary>
        public ICommand ChangeStatusCommand { get; set; }



        public void OnCreatingTask(object parameter)
        {          
            TaskConstructorViewModel taskConstructorViewModel  = new TaskConstructorViewModel(Tasks, _primaryPriorities, _primaryDepartments);
        }


        public void OnClosingAnApp(object parameter)
        {
            Application.Current.Shutdown();
        }

        public void OnOpenProfileCommand(object parameter)
        {          
            ProfileViewModel profileViewModel = new ProfileViewModel(CurrentUser);                 
        }


       
        public void OnChangingStatus(object parameter)
        {           
            string taskJsonString = JsonOperations.JsonForNewTask(CurrentTask);

            // Здесь шифруется информация о задаче

            string encryptedString = Cypher.DecryptData(taskJsonString);

            HttpWork httpWork = new HttpWork();

            var serverResponse = httpWork.ChangeTaskStatus(encryptedString).Result;

            string serverResponseString = CSVReader.AddTaskServerResponse(serverResponse);

            // Проверить правильность DecryptData (возможно, потребуется GetEncryptData)
            string cryptedServerResponse = Cypher.DecryptData(serverResponseString);

            //// так можно обозначать результат попытки добавить новую задачу 
            MessageBox.Show(cryptedServerResponse, "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        public async void OnMakeReport(object parameter)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                _dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Отчет формируется");
                });
                ReportMaker.MakeReport(Tasks);
                MessageBox.Show("Отчет сформирован");
            });
        }
    }
}