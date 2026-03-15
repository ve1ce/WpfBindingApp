using CodingSeb.Localization;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Двусторонняя привязка
    /// </summary>
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private string _userName;
        private string _defaultUserName;
        private int _age = 25;
        private bool _isActive = true;

        public TwoWayBindingViewModel()
        {
            UpdateLocalizedDefaults(force: true);
            Loc.Instance.CurrentLanguageChanged += (_, __) =>
            {
                UpdateLocalizedDefaults(force: false);
                OnPropertyChanged(nameof(CurrentValues));
            };
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (SetField(ref _userName, value))
                {
                    OnPropertyChanged(nameof(CurrentValues));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (SetField(ref _age, value))
                {
                    OnPropertyChanged(nameof(CurrentValues));
                }
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (SetField(ref _isActive, value))
                {
                    OnPropertyChanged(nameof(CurrentValues));
                }
            }
        }

        public string CurrentValues
        {
            get
            {
                var activeText = IsActive
                    ? Loc.Tr("Common.Yes", "Да")
                    : Loc.Tr("Common.No", "Нет");
                var format = Loc.Tr("TwoWay.CurrentValuesFormat", "Имя: {0}, Возраст: {1}, Активен: {2}");
                return string.Format(format, UserName, Age, activeText);
            }
        }

        private void UpdateLocalizedDefaults(bool force)
        {
            var newUserName = Loc.Tr("TwoWay.DefaultUserName", "Иван Иванов");
            if (force || _userName == _defaultUserName)
            {
                _userName = newUserName;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CurrentValues));
            }

            _defaultUserName = newUserName;
        }
    }
}
