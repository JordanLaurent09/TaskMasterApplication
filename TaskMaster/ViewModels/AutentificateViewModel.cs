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
        private string _login ;
        private string _password;


        public string Login
        {
            get => _login;

            set
            {
                if(_login != value)
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
            if (Login == "user" && Password == "user")
            {
                ShowMainWindowCommand = new LambdaCommand(CanShowMainWindow, OnShowMainWindowCommandExecute);
            }
        }

        public ICommand ShowMainWindowCommand { get; }

        // этот метод нужно убрать!!!
        public bool CanShowMainWindow(object parameter)
        {
            if (Login == "user" && Password == "user") return true;
            return false;
        }
        public void OnShowMainWindowCommandExecute(object parameter)
        {          
            Window current = Application.Current.MainWindow;
            Window window = new MainWindow();
            window.Show();
            current.Close();
        }
    }
}
