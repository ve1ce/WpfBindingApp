using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingDemo.ViewModels
{
    public class OneWayBindingViewModel : ViewModelBase
    {
        private string _sourceValue = "Исходное значение";
        private double _numberA = 10;
        private double _numberB = 5;

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
    }
}