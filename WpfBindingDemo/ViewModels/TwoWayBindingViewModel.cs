using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace WpfBindingDemo.ViewModels
{
    public partial class TwoWayBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userName = "Иван Иванов";

        [ObservableProperty]
        private int _age = 25;

        [ObservableProperty]
        private bool _isActive = true;

        public string CurrentValues =>
            $"Имя: {UserName}, Возраст: {Age}, Активен: {(IsActive ? "Да" : "Нет")}";
    }
}