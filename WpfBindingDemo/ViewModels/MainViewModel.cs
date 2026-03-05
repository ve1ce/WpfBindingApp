using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfBindingDemo.Views.Tabs;

namespace WpfBindingDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TabViewModel> Tabs { get; } = new ObservableCollection<TabViewModel>();

        public MainViewModel()
        {
            // Добавляем вкладки
            AddTabs();
            UpdateTabTitles();
        }

        private void AddTabs()
        {
            // Вкладка OneTime Binding
            var oneTimeViewModel = new OneTimeBindingViewModel();
            var oneTimeView = new OneTimeBindingView();
            oneTimeView.DataContext = oneTimeViewModel;

            Tabs.Add(new TabViewModel(string.Empty, oneTimeView));

            // Вкладка TwoWay Binding
            var twoWayViewModel = new TwoWayBindingViewModel();
            var twoWayView = new TwoWayBindingView();
            twoWayView.DataContext = twoWayViewModel;

            Tabs.Add(new TabViewModel(string.Empty, twoWayView));

            // Вкладка OneWay Binding
            var oneWayViewModel = new OneWayBindingViewModel();
            var oneWayView = new OneWayBindingView();
            oneWayView.DataContext = oneWayViewModel;

            Tabs.Add(new TabViewModel(string.Empty, oneWayView));

            // Вкладка Default Binding
            var defaultViewModel = new DefaultBindingViewModel();
            var defaultView = new DefaultBindingView();
            defaultView.DataContext = defaultViewModel;

            Tabs.Add(new TabViewModel(string.Empty, defaultView));

            // Вкладка Triggers
            var triggersViewModel = new TriggersViewModel();
            var triggersView = new TriggersView();
            triggersView.DataContext = triggersViewModel;

            Tabs.Add(new TabViewModel(string.Empty, triggersView));
        }

        public void UpdateTabTitles()
        {
            try
            {
                if (Tabs.Count > 0)
                {
                    Tabs[0].TabName = GetString("Tab_OneTime");
                }

                if (Tabs.Count > 1)
                {
                    Tabs[1].TabName = GetString("Tab_TwoWay");
                }

                if (Tabs.Count > 2)
                {
                    Tabs[2].TabName = GetString("Tab_OneWay");
                }

                if (Tabs.Count > 3)
                {
                    Tabs[3].TabName = GetString("Tab_Default");
                }

                if (Tabs.Count > 4)
                {
                    Tabs[4].TabName = GetString("Tab_Triggers");
                }
            }
            catch
            {
                // Игнорируем ошибки загрузки ресурсов
            }
        }

        private string GetString(string key)
        {
            try
            {
                var value = Application.Current.FindResource(key) as string;
                return value ?? key;
            }
            catch
            {
                return key;
            }
        }
    }
}
