using Ping.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Ping.Views.Pages
{
    public partial class MainPage : INavigableView<MainViewModel>
    {
        public MainViewModel ViewModel { get; }

        public MainPage(MainViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
