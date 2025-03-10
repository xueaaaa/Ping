using System.Windows;
using System.Windows.Controls;
using Task = Ping.Models.Task.Task;

namespace Ping.Views.Controls
{
    public partial class TaskCard : UserControl
    {
        public static readonly DependencyProperty TaskProperty =
            DependencyProperty.Register("Task", typeof(Task), typeof(TaskCard));

        public Task Task
        {
            get => (Task)GetValue(TaskProperty);
            set => SetValue(TaskProperty, value);
        }

        public TaskCard()
        {
            InitializeComponent();
        }
    }
}
