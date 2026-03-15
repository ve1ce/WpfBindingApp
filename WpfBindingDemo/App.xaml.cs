using System;
using System.Windows;
using CodingSeb.Localization;
using CodingSeb.Localization.Loaders;

namespace WpfBindingDemo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LocalizationLoader.Instance.FileLanguageLoaders.Add(new JsonFileLoader());
            var localizationDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Localization");
            if (System.IO.Directory.Exists(localizationDirectory))
            {
                LocalizationLoader.Instance.AddDirectory(localizationDirectory);
            }

            Loc.Instance.CurrentLanguage = "ru";
        }
    }
}
