using System.Text.Json.Serialization;
using System.Windows.Media;

namespace Ping.Models.Task
{
    public partial class Tag : ObservableObject
    {
        public Guid Id { get; set; }

        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private SolidColorBrush _color;

        private SolidColorBrush _backgroundColor;
        [JsonIgnore]
        public SolidColorBrush BackgroundColor
        {
            get 
            {
                var c = Color.Color;
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(30, c.R, c.G, c.B));
            }
        }

    }
}
