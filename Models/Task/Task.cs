namespace Ping.Models.Task
{
    public partial class Task : ObservableObject
    {
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string? _description;
        [ObservableProperty]
        private DateTime _leadTime;
        [ObservableProperty]
        private Tag _tag;
        [ObservableProperty]
        private Priority _priority;
        [ObservableProperty]
        private bool _isCompleted;
    }
}
