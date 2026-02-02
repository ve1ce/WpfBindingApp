using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingDemo.ViewModels
{
    public partial class DefaultBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _demoValue = "Измени это значение";

        [ObservableProperty]
        private string _testProperty = "Тестовый текст";

        [ObservableProperty]
        private double _numericValue = 50;

        [ObservableProperty]
        private bool _isChecked = true;
    }
}