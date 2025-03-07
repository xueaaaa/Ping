using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Ping.Models;
using Task = Ping.Models.Task.Task;

namespace Ping.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        private ObservableCollection<Task> _tasks;
        #endregion

        public MainWindowViewModel()
        {
            Tasks = new(StorageManager.ReadFromJson<Task>(StorageManager.TASKS_FOLDER).Result);
        }
    }
}
