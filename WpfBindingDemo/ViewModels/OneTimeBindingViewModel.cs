using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Input;

namespace WpfBindingDemo.ViewModels
{
    public class OneTimeBindingViewModel : ViewModelBase
    {
        private string _oneTimeValue = "Начальное значение из ViewModel";
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
            OneTimeValue = $"Новое значение: {_random.Next(1000)}";
        }
    }
}
