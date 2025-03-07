using System.Globalization;
using System.IO;
using System.Windows;
using Ping.Models;
using Ping.Properties;

namespace Ping
{
    public partial class App : Application
    {
        public App()
        {
            StorageManager.EnsureCreated();

            LocalizationManager.AddLang(CultureInfo.GetCultureInfo("ru"));
            LocalizationManager.AddLang(CultureInfo.GetCultureInfo("en"));

            LocalizationManager.LanguageChanged += LanguageChanged;
        }

        private void LanguageChanged(object? sender, EventArgs e)
        {
            
        }

        public static void Restart()
        {
            System.Diagnostics.Process.Start(ResourceAssembly.Location);
            Current.Shutdown();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var lang = Settings.Default.Language;
            LocalizationManager.CurrentLanguage = lang == null ?
                Settings.Default.DefaultLanguage :
                lang;
        }
    }
}
