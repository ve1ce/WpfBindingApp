using CodingSeb.Localization;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Класс для отображения вкладок
    /// </summary>
    public class TabViewModel : ViewModelBase
    {
        private readonly string _tabTextId;
        private object _tabContent;

        public string TabName => Loc.Tr(_tabTextId); // Наименование вкладки

        public object TabContent // Содержимок вкладки
        {
            get => _tabContent;
            set => SetField(ref _tabContent, value);
        }

        public TabViewModel(string textId, object content) // Конструктор вкладки
        {
            _tabTextId = textId;
            TabContent = content;

            Loc.Instance.CurrentLanguageChanged += (_, __) => OnPropertyChanged(nameof(TabName));
        }
    }
}
