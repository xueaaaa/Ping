using System.Drawing;

namespace Ping.Models.Task
{
    public partial class Tag : ObservableObject
    {
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private Color _color;
    }
}
