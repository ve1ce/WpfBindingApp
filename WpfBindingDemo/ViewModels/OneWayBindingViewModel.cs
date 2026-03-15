using CodingSeb.Localization;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Односторонняя привязка
    /// </summary>
    public class OneWayBindingViewModel : ViewModelBase
    {
        private string _sourceValue;
        private string _defaultSourceValue;
        private double _numberA = 10;
        private double _numberB = 5;

        public OneWayBindingViewModel()
        {
            UpdateLocalizedDefaults(force: true);
            Loc.Instance.CurrentLanguageChanged += (_, __) => UpdateLocalizedDefaults(force: false);
        }

        public string SourceValue
        {
            get => _sourceValue;
            set => SetField(ref _sourceValue, value);
        }

        public double NumberA
        {
            get => _numberA;
            set
            {
                if (SetField(ref _numberA, value))
                {
                    OnPropertyChanged(nameof(Sum));
                    OnPropertyChanged(nameof(Difference));
                    OnPropertyChanged(nameof(Product));
                }
            }
        }

        public double NumberB
        {
            get => _numberB;
            set
            {
                if (SetField(ref _numberB, value))
                {
                    OnPropertyChanged(nameof(Sum));
                    OnPropertyChanged(nameof(Difference));
                    OnPropertyChanged(nameof(Product));
                }
            }
        }

        // Вычисляемые свойства (только get)
        public double Sum => NumberA + NumberB;
        public double Difference => NumberA - NumberB;
        public double Product => NumberA * NumberB;

        private void UpdateLocalizedDefaults(bool force)
        {
            var newSource = Loc.Tr("OneWay.SourceDefault", "Исходное значение");
            if (force || _sourceValue == _defaultSourceValue)
            {
                _sourceValue = newSource;
                OnPropertyChanged(nameof(SourceValue));
            }

            _defaultSourceValue = newSource;
        }
    }
}
