using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingDemo.ViewModels
{
    public partial class OneWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _sourceValue = "Исходное значение";

        [ObservableProperty]
        private double _numberA = 10;

        [ObservableProperty]
        private double _numberB = 5;

        // Вычисляемые свойства (только get)
        public double Sum => NumberA + NumberB;
        public double Difference => NumberA - NumberB;
        public double Product => NumberA * NumberB;
    }
}