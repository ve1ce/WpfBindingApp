using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBindingDemo;
using System.Windows.Input;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Одноразовая привязка
    /// </summary>
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private string _oneTimeValue = Localization.GetString("OneTime_InitialValueFromViewModel");
        private Random _random = new Random();

        public string OneTimeValue
        {
            get => _oneTimeValue;
            set => SetField(ref _oneTimeValue, value);
        }

        public ICommand UpdateOneTimeValueCommand { get; }

        public OneTimeBindingViewModel()
        {
            UpdateOneTimeValueCommand = new RelayCommand(UpdateOneTimeValue);
        }

        private void UpdateOneTimeValue()
        {
            var format = Localization.GetString("OneTime_NewValue_Format");
            OneTimeValue = string.Format(format, _random.Next(1000));
        }
    }
}
