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

namespace TaskMaster.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Task> _tasks;

        public ObservableCollection<Task> Tasks
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

        public MainViewModel()
        {
            _tasks = new ObservableCollection<Task>();
        }
    }
}
