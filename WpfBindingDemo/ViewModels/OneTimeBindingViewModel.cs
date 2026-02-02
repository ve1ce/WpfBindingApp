using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WpfBindingDemo.ViewModels
{
    public partial class OneTimeBindingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _oneTimeValue = "Начальное значение из ViewModel";

        private Random _random = new Random();

        [RelayCommand]
        private void UpdateOneTimeValue()
        {
            OneTimeValue = $"Новое значение: {_random.Next(1000)}";
        }
    }
}