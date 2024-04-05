using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskMaster.Infrastructure.Commands;
using TaskMaster.ViewModels.BaseViewModel;

namespace TaskMaster.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
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

        public RegistrationViewModel()
        {
            RegistrateCommand = new LambdaCommand((object p) => true, OnRegistrateCommandExecute);
        }

        public ICommand RegistrateCommand { get; }

        public void OnRegistrateCommandExecute(object parameter)
        {
            if (Login != "user" && Password != "user")
            {
                Window current = Application.Current.MainWindow;
                Window window = new MainWindow(new Models.User(Name, Surname, Birthday, ContactPhone, Login, Password, Department));
                window.Show();
                current.Close();
            }
            else
            {
                MessageBox.Show("user with desirable loginor/and password is exists yet");
            }
        }
    }
}
