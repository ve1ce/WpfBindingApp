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
using System.Windows;

namespace WpfBindingDemo.Views.Tabs
{
    public partial class TwoWayBindingView
    {
        public TwoWayBindingView()
        {
            InitializeComponent();
        }

        private void UpdateExplicitBinding_Click(object sender, RoutedEventArgs e)
        {
            // Получаем привязку и обновляем источник
            var bindingExpression = ExplicitTextBox.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty);
            bindingExpression?.UpdateSource();
        }
    }
}
