using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingDemo.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        private string _tabName;
        private object _tabContent;

        public string TabName
        {
            get => _tabName;
            set => SetField(ref _tabName, value);
        }

        public object TabContent
        {
            get => _tabContent;
            set => SetField(ref _tabContent, value);
        }

        public TabViewModel(string name, object content)
        {
            TabName = name;
            TabContent = content;
        }
    }
}
