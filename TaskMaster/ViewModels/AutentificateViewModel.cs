﻿using System;
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

namespace TaskMaster.ViewModels
{
    public class AutentificateViewModel : ViewModelBase
    {
        private string _name;
        private string _surname;
        private DateTime _birthday;
        private string _contactPhone;
        private string _login;
        private string _password;
        private string _department;

        public string Name
        {
            get => _name;

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Surname
        {
            get => _surname;

            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        public DateTime Birthday
        {
            get => _birthday;

            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged(nameof(Birthday));
                }
            }
        }

        public string ContactPhone
        {
            get => _contactPhone;

            set
            {
                if (_contactPhone != value)
                {
                    _contactPhone = value;
                    OnPropertyChanged(nameof(ContactPhone));
                }
            }
        }

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

        public string Department
        {
            get => _department;

            set
            {
                if (_department != value)
                {
                    _department = value;
                    OnPropertyChanged(nameof(Department));
                }
            }
        }

        public AutentificateViewModel()
        {
            AuthorisationCommand = new LambdaCommand((object p) => true, OnAuthoriseCommandExecute);
        }

        public ICommand AuthorisationCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }



        public void OnAuthoriseCommandExecute(object parameter)
        {
            ObservableCollection<Models.Task> allTasks = new ObservableCollection<Models.Task>();
            List<Models.Task> primaryTAskList = new List<Models.Task>();
            List<User> users = new List<User>();



            string userInfo = JsonOperations.JsonForLogin(Login, Password);

            HttpWork httpWork = new HttpWork();

            var info = httpWork.GetAuthInfo(userInfo).Result;

            CSVReader.InfoTotal(ref primaryTAskList, ref users, info);


        }

        //private string _login;
        //private string _password;

        //public string Login
        //{
        //    get => _login;

        //    set
        //    {
        //        if (_login != value)
        //        {
        //            _login = value;
        //            OnPropertyChanged(nameof(Login));
        //        }
        //    }
        //}


        //public string Password
        //{
        //    get => _password;

        //    set
        //    {
        //        if (_password != value)
        //        {
        //            _password = value;
        //            OnPropertyChanged(nameof(Password));
        //        }
        //    }
        //}



        //public AutentificateViewModel()
        //{
        //    ShowMainWindowCommand = new LambdaCommand((object p) => true, OnShowMainWindowCommandExecute);
        //}

        //public ICommand ShowMainWindowCommand { get; }

        //public void OnShowMainWindowCommandExecute(object parameter)
        //{
        //    if (Login == "user" && Password == "user")
        //    {
        //        Window current = Application.Current.MainWindow;
        //        Window window = new MainWindow(new Models.User("admin", "admin", new DateTime(2005, 4, 25), "777-777", Login, Password, "Administration"));
        //        window.Show();
        //        current.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("login or/and password is unknown");
        //    }
        //}
    }
}
