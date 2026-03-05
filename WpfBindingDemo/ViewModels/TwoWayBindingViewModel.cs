using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBindingDemo;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Двусторонняя привязка
    /// </summary>
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private string _userName = Localization.GetString("TwoWay_UserName_Default");
        private int _age = 25;
        private bool _isActive = true;

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
                var yes = Localization.GetString("TwoWay_Active_Yes");
                var no = Localization.GetString("TwoWay_Active_No");
                var format = Localization.GetString("TwoWay_CurrentValues_Format");
                var activeText = IsActive ? yes : no;
                return string.Format(format, UserName, Age, activeText);
            }
        }
    }
}
