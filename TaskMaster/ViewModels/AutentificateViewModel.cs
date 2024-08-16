using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskMaster.Infrastructure.Commands;
using TaskMaster.ViewModels.BaseViewModel;
using System.Windows.Controls;
using TaskMaster.Services;
using System.IO;
using System.Collections.ObjectModel;
using TaskMaster.Models;
using TaskMaster.Views.Windows;
using System.Runtime.CompilerServices;

namespace TaskMaster.ViewModels
{
    public class AutentificateViewModel : ViewModelBase
    {       
        private string _login;
        private string _password;
        
        public string Login
        {
            get => _login;

            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        public string Password
        {
            get => _password;

            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        

        public AutentificateViewModel()
        {
            AuthorisationCommand = new LambdaCommand((object p) => true, OnAuthoriseCommandExecute);
        }

        public ICommand AuthorisationCommand { get; set; }
        

        public void OnAuthoriseCommandExecute(object parameter)
        {
            
            List<Models.Task> primaryTaskList = new List<Models.Task>();

            List<User> users = new List<User>();

            List<Department> departments = new List<Department>();

            List<Status> statuses = new List<Status>();

            List<Priority> priorities = new List<Priority>();

            // Здесь будут шифроваться логин и пароль для пользователя

            string userInfo = JsonOperations.JsonForLogin(Login, Password);

            string cryptedUserInfo = Cypher.DecryptData(userInfo);

            HttpWork httpWork = new HttpWork();

            var info = httpWork.GetAuthInfo(cryptedUserInfo).Result;

            
            
            // Данные возвращаются уже расшифрованными

            Data allData = JsonOperations.GetAllData(info);

            


            primaryTaskList = allData.Tasks;

            users = allData.Users;

            departments = allData.Departments;

            statuses = allData.Statuses;

            priorities = allData.Priorities;

            ObservableCollection<Models.Task> allTasks = ObservableConverter.ConvertToObservable(primaryTaskList);

            Window autentificateViewModel = Application.Current.MainWindow;

            if (users.Count > 0)
            {
                MainViewModel mainViewModel = new MainViewModel(allTasks, users[0], departments, statuses, priorities);
                autentificateViewModel.Close();
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
            }         
            
        }
    }
}
