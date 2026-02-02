using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingDemo.ViewModels
{
    public partial class TabViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _tabName;

        [ObservableProperty]
        private object _tabContent;

        public TabViewModel(string name, object content)
        {
            TabName = name;
            TabContent = content;
        }
    }
}