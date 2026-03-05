using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Класс для отображения вкладок
    /// </summary>
    public class TabViewModel : ViewModelBase
    {
        private string _tabName;
        private object _tabContent;

        public string TabName // Наименование вкладки
        {
            get => _tabName;
            set => SetField(ref _tabName, value);
        }

        public object TabContent // Содержимок вкладки
        {
            get => _tabContent;
            set => SetField(ref _tabContent, value);
        }

        public TabViewModel(string name, object content) // Конструктор вкладки
        {
            TabName = name;
            TabContent = content;
        }
    }
}
