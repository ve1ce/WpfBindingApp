using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace WpfBindingDemo.ViewModels
{
    /// <summary>
    /// Двусторонняя привязка
    /// </summary>
    public class TwoWayBindingViewModel : ViewModelBase
    {
        private string _userName = "Иван Иванов";
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

        public string CurrentValues =>
            $"Имя: {UserName}, Возраст: {Age}, Активен: {(IsActive ? "Да" : "Нет")}";
    }
}
