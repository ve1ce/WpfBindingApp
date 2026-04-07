using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfBindingDemo.ViewModels;

namespace WpfBindingDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboBoxItem = LanguageComboBox.SelectedItem as ComboBoxItem;
            if (selectedComboBoxItem == null)
            {
                return;
            }

            var languageTag = selectedComboBoxItem.Tag as string;
            if (string.IsNullOrEmpty(languageTag))
            {
                return;
            }

            var dictionaries = Application.Current.Resources.MergedDictionaries;
            if (dictionaries == null || dictionaries.Count == 0)
            {
                return;
            }

            string source;
            if (languageTag == "en")
            {
                source = "Resources/StringResources.en.xaml";
            }
            else
            {
                source = "Resources/StringResources.ru.xaml";
            }

            try
            {
                var dictionary = new ResourceDictionary();
                dictionary.Source = new Uri(source, UriKind.Relative);
                dictionaries[0] = dictionary;

                var mainViewModel = DataContext as MainViewModel;
                if (mainViewModel != null)
                {
                    mainViewModel.UpdateTabTitles();
                }
            }
            catch
            {
                // Игнорируем ошибки загрузки словаря
            }
        }
    }
}