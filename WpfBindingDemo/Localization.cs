using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WpfBindingDemo
{
    public static class Localization
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("WpfBindingDemo.Resources.Strings",
                               typeof(Localization).Assembly);

        public static event EventHandler LanguageChanged;

        public static string GetString(string key)
        {
            try
            {
                return ResourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture) ?? $"[{key}]";
            }
            catch
            {
                return $"[{key}]";
            }
        }

        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Обновляем язык для всех окон
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }
    }

    public class LocExtension : MarkupExtension
    {
        public string Key { get; set; }

        public LocExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Подписываемся на событие изменения языка для динамического обновления
            if (serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget target)
            {
                if (target.TargetObject is FrameworkElement element)
                {
                    // Создаем привязку для динамического обновления
                    var binding = new System.Windows.Data.Binding
                    {
                        Source = new LocalizationBindingSource(Key),
                        Path = new PropertyPath("Value"),
                        Mode = System.Windows.Data.BindingMode.OneWay
                    };
                    return binding.ProvideValue(serviceProvider);
                }
            }

            // Fallback
            return Localization.GetString(Key);
        }
    }

    // Вспомогательный класс для привязки
    public class LocalizationBindingSource : System.ComponentModel.INotifyPropertyChanged
    {
        private string _key;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public string Value => Localization.GetString(_key);

        public LocalizationBindingSource(string key)
        {
            _key = key;
            Localization.LanguageChanged += (s, e) =>
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Value)));
        }
    }
}
