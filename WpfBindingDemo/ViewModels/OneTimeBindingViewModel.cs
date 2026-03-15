using System;
using System.Windows.Input;
using CodingSeb.Localization;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Одноразовая привязка
    /// </summary>
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private string _oneTimeValue;
        private string _defaultOneTimeValue;
        private readonly Random _random = new Random();

        public string OneTimeValue
        {
            get => _oneTimeValue;
            set => SetField(ref _oneTimeValue, value);
        }

        public ICommand UpdateOneTimeValueCommand { get; }

        public OneTimeBindingViewModel()
        {
            UpdateLocalizedDefaults(force: true);
            UpdateOneTimeValueCommand = new RelayCommand(UpdateOneTimeValue);
            Loc.Instance.CurrentLanguageChanged += (_, __) => UpdateLocalizedDefaults(force: false);
        }

        private void UpdateOneTimeValue()
        {
            var format = Loc.Tr("OneTime.NewValueFormat", "Новое значение: {0}");
            OneTimeValue = string.Format(format, _random.Next(1000));
        }

        private void UpdateLocalizedDefaults(bool force)
        {
            var newDefault = Loc.Tr("OneTime.InitialValue", "Начальное значение из ViewModel");
            if (force || _oneTimeValue == _defaultOneTimeValue)
            {
                _oneTimeValue = newDefault;
                OnPropertyChanged(nameof(OneTimeValue));
            }

            _defaultOneTimeValue = newDefault;
        }
    }
}
