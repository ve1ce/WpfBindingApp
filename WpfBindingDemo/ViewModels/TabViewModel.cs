using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Вкладки
    /// </summary>
    public partial class TabViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _tabName; // Наименование

        [ObservableProperty]
        private object _tabContent; // Содержимое

        public TabViewModel(string name, object content) // Конструктор
        {
            TabName = name;
            TabContent = content;
        }
    }
}