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
        private bool _isInitialized = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            this.Loaded += (s, e) =>
            {
                _isInitialized = true;
            };
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isInitialized) return;

            if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var culture = selectedItem.Tag as string;
                if (!string.IsNullOrEmpty(culture))
                {
                    Localization.SetLanguage(culture);
                }
            }
        }
    }
}
