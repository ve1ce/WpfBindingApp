using CodingSeb.Localization;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Привязка по-умолчанию
    /// </summary>
    public class DefaultBindingViewModel : ViewModelBase
    {
        private string _demoValue;
        private string _testProperty;
        private string _defaultDemoValue;
        private string _defaultTestProperty;
        private double _numericValue = 50;
        private bool _isChecked = true;

        public DefaultBindingViewModel()
        {
            UpdateLocalizedDefaults(force: true);
            Loc.Instance.CurrentLanguageChanged += (_, __) => UpdateLocalizedDefaults(force: false);
        }

        public string DemoValue
        {
            get => _demoValue;
            set => SetField(ref _demoValue, value);
        }

        public string TestProperty
        {
            get => _testProperty;
            set => SetField(ref _testProperty, value);
        }

        public double NumericValue
        {
            get => _numericValue;
            set => SetField(ref _numericValue, value);
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => SetField(ref _isChecked, value);
        }

        private void UpdateLocalizedDefaults(bool force)
        {
            var newDemo = Loc.Tr("Default.DemoValue", "Измени это значение");
            var newTest = Loc.Tr("Default.TestProperty", "Тестовый текст");

            if (force || _demoValue == _defaultDemoValue)
            {
                _demoValue = newDemo;
                OnPropertyChanged(nameof(DemoValue));
            }

            if (force || _testProperty == _defaultTestProperty)
            {
                _testProperty = newTest;
                OnPropertyChanged(nameof(TestProperty));
            }

            _defaultDemoValue = newDemo;
            _defaultTestProperty = newTest;
        }
    }
}
