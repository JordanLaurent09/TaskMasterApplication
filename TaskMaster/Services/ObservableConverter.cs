using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Models;

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

        public static ObservableCollection<Department> ConvertToObservableDeps(List<Department> primaryDeps)
        {
            ObservableCollection<Department> deps = new ObservableCollection<Department>();

            foreach (var item in primaryDeps)
            {
                primaryDeps.Add(item);
            }

            return deps;
        }

        /// <summary>
        /// Получение списка названий отделов
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static ObservableCollection<string> GetDepartmentNames(List<Department> departments)
        {
            ObservableCollection<string> departmentsNames = new ObservableCollection<string>();

            foreach(Department item in departments)
            {
                departmentsNames.Add(item.Name);
            }

            return departmentsNames;
        }


        public static ObservableCollection<string> GetStatusTypes(List<Status> statuses)
        {
            ObservableCollection<string> statusesTypes = new ObservableCollection<string>();

            foreach (Status item in statuses)
            {
                statusesTypes.Add(item.StatusType);
            }

            return statusesTypes;
        }

        public static ObservableCollection<string> GetPriorities(List<Priority> priorities)
        {
            ObservableCollection<string> prioritiesNames = new ObservableCollection<string>();

            foreach (Priority item in priorities)
            {
                prioritiesNames.Add(item.PriorityType);
            }

            return prioritiesNames;
        }

        public static ObservableCollection<Models.Task> SortTasksCollection(ObservableCollection<Models.Task> initialCollection)
        {
            ObservableCollection<Models.Task> sortedTasks = new ObservableCollection<Models.Task>();

            ObservableCollection<Models.Task> enabledTasks = new ObservableCollection<Models.Task>();
            ObservableCollection<Models.Task> disabledTasks = new ObservableCollection<Models.Task>();


            foreach (var task in initialCollection)
            {
                if (task.Status == "Просрочена")
                {
                    disabledTasks.Add(task);
                }
                else
                {
                    enabledTasks.Add(task);
                }
            }

            foreach (var task in enabledTasks)
            {
                sortedTasks.Add(task);
            }

            foreach (var task in disabledTasks)
            {
                sortedTasks.Add(task);
            }

            return sortedTasks;
        }
    }
}
