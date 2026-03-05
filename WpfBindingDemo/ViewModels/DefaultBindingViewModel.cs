using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBindingDemo;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Привязка по-умолчанию
    /// </summary>
    public class DefaultBindingViewModel : ViewModelBase
    {
        private string _demoValue = Localization.GetString("Default_DemoValue_Initial");
        private string _testProperty = Localization.GetString("Default_TestProperty_Initial");
        private double _numericValue = 50;
        private bool _isChecked = true;

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
    }
}
