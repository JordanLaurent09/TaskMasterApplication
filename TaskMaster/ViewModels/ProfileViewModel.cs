using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskMaster.Infrastructure.Commands;
using TaskMaster.Models;
using TaskMaster.ViewModels.BaseViewModel;
using TaskMaster.Views.Windows;

namespace TaskMaster.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private User _currentUser;


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

        public ProfileWindow profileWindow { get; set; }


        public ProfileViewModel(User user)
        {
            BackToMainWindowCommand = new LambdaCommand((object p) => true, OnReturning);

            CurrentUser = user;

            
            profileWindow = new ProfileWindow();
            profileWindow.DataContext = this;
            profileWindow.Show();
            
        }

        /// <summary>
        /// Команда, закрывающая окно личного кабинета
        /// </summary>
        public ICommand BackToMainWindowCommand { get; set; }


        public void OnReturning(object parameter)
        {                    
           profileWindow.Close();
        }

    }
}
