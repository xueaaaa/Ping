using Ping.Models.Task;
using Wpf.Ui.Controls;
using Task = Ping.Models.Task.Task;

namespace Ping.ViewModels.Pages
{
    public partial class MainViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private List<Task> _tasks;
        [ObservableProperty]
        private List<Tag> _tags;

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo()
        {
            Tasks = new();
            Tasks.Add(new Task()
            {
                Name = "Text",
                Description = "Text",
                LeadTime = DateTime.Now,
                IsCompleted = false,
                Priority = Priority.High
            });
        }
    }
}
