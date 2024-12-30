using Ping.Models.Task;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace Ping.ViewModels.Pages
{
    public partial class MainViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private List<Tag> _tags;

        public void OnNavigatedFrom()
        {
            
        }

        public void OnNavigatedTo()
        {

        }
    }
}
