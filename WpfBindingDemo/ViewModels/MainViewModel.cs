using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void AddTabs()
        {
            // Вкладка OneTime Binding
            var oneTimeViewModel = new OneTimeBindingViewModel();
            var oneTimeView = new OneTimeBindingView();
            oneTimeView.DataContext = oneTimeViewModel;

            Tabs.Add(new TabViewModel("OneTime Binding", oneTimeView));

            // Вкладка TwoWay Binding
            var twoWayViewModel = new TwoWayBindingViewModel();
            var twoWayView = new TwoWayBindingView();
            twoWayView.DataContext = twoWayViewModel;

            Tabs.Add(new TabViewModel("TwoWay Binding", twoWayView));

            // Вкладка OneWay Binding
            var oneWayViewModel = new OneWayBindingViewModel();
            var oneWayView = new OneWayBindingView();
            oneWayView.DataContext = oneWayViewModel;

            Tabs.Add(new TabViewModel("OneWay Binding", oneWayView));

            // Вкладка Default Binding
            var defaultViewModel = new DefaultBindingViewModel();
            var defaultView = new DefaultBindingView();
            defaultView.DataContext = defaultViewModel;

            Tabs.Add(new TabViewModel("Default Binding", defaultView));

            // Вкладка Triggers
            var triggersViewModel = new TriggersViewModel();
            var triggersView = new TriggersView();
            triggersView.DataContext = triggersViewModel;

            Tabs.Add(new TabViewModel("Triggers", triggersView));
        }
    }
}
