using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfBindingDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Это свойство будет содержать все вкладки
        public ObservableCollection<TabViewModel> Tabs { get; } = new ObservableCollection<TabViewModel>();

        public MainViewModel()
        {
            // Позже добавим сюда создание вкладок
        }
    }
}
