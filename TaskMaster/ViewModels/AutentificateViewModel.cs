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
            ShowMainWindowCommand = new LambdaCommand((object p) => true, OnShowMainWindowCommandExecute);
        }

        public ICommand ShowMainWindowCommand { get; }

        public void OnShowMainWindowCommandExecute(object parameter)
        {
            if (Login == "user" && Password == "user")
            {
                Window current = Application.Current.MainWindow;
                Window window = new MainWindow(new Models.User("admin", "admin", new DateTime(2005, 4, 25), "777-777", Login, Password, "Administration"));
                window.Show();
                current.Close();
            }
            else
            {
                MessageBox.Show("login or/and password is unknown");
            }
        }
    }
}
