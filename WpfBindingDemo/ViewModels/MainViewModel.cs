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

            // Подписываемся на смену языка
            Localization.LanguageChanged += (s, e) => RefreshTabHeaders();
        }

        private void AddTabs()
        {
            // Вкладка OneTime Binding
            var oneTimeViewModel = new OneTimeBindingViewModel();
            var oneTimeView = new OneTimeBindingView();
            oneTimeView.DataContext = oneTimeViewModel;

            Tabs.Add(new TabViewModel(Localization.GetString("Tab_OneTimeBinding"), oneTimeView));

            // Вкладка TwoWay Binding
            var twoWayViewModel = new TwoWayBindingViewModel();
            var twoWayView = new TwoWayBindingView();
            twoWayView.DataContext = twoWayViewModel;

            Tabs.Add(new TabViewModel(Localization.GetString("Tab_TwoWayBinding"), twoWayView));

            // Вкладка OneWay Binding
            var oneWayViewModel = new OneWayBindingViewModel();
            var oneWayView = new OneWayBindingView();
            oneWayView.DataContext = oneWayViewModel;

            Tabs.Add(new TabViewModel(Localization.GetString("Tab_OneWayBinding"), oneWayView));

            // Вкладка Default Binding
            var defaultViewModel = new DefaultBindingViewModel();
            var defaultView = new DefaultBindingView();
            defaultView.DataContext = defaultViewModel;

            Tabs.Add(new TabViewModel(Localization.GetString("Tab_DefaultBinding"), defaultView));

            // Вкладка Triggers
            var triggersViewModel = new TriggersViewModel();
            var triggersView = new TriggersView();
            triggersView.DataContext = triggersViewModel;

            Tabs.Add(new TabViewModel(Localization.GetString("Tab_Triggers"), triggersView));
        }

        private void RefreshTabHeaders()
        {
            if (Tabs.Count >= 1) Tabs[0].TabName = Localization.GetString("Tab_OneTimeBinding");
            if (Tabs.Count >= 2) Tabs[1].TabName = Localization.GetString("Tab_TwoWayBinding");
            if (Tabs.Count >= 3) Tabs[2].TabName = Localization.GetString("Tab_OneWayBinding");
            if (Tabs.Count >= 4) Tabs[3].TabName = Localization.GetString("Tab_DefaultBinding");
            if (Tabs.Count >= 5) Tabs[4].TabName = Localization.GetString("Tab_Triggers");
        }
    }
}