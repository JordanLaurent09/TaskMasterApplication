using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Services
{
    public static class ObservableConverter
    {
        public static ObservableCollection<Models.Task> ConvertToObservable(List<Models.Task> primaryTasks)
        {
            ObservableCollection<Models.Task> tasks = new ObservableCollection<Models.Task>();

            foreach(var item in primaryTasks)
            {
                tasks.Add(item);
            }

            return tasks;
        }
    }
}
