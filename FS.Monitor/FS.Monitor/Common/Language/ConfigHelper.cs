﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace FS.Monitor.Common.Language
{
    public class ConfigHelper : INotifyPropertyChanged
    {
        private ConfigHelper()
        {

        }

        public static ConfigHelper Instance = new Lazy<ConfigHelper>(() => new ConfigHelper()).Value;

        private XmlLanguage _lang = XmlLanguage.GetLanguage("zh-cn");

        public XmlLanguage Lang
        {
            get => _lang;
            set
            {
                if (!_lang.IetfLanguageTag.Equals(value.IetfLanguageTag))
                {
                    _lang = value;
                    OnPropertyChanged(nameof(Lang));
                }
            }
        }

        public void SetLang(string lang)
        {
            LangProvider.Culture = new CultureInfo(lang);
            Application.Current.Dispatcher.Thread.CurrentUICulture = new CultureInfo(lang);
            Lang = XmlLanguage.GetLanguage(lang);
        }

        public void SetConfig(HandyControlConfig config)
        {
            SetLang(config.Lang);
            SetTimelineFrameRate(config.TimelineFrameRate);
        }

        public void SetTimelineFrameRate(int rate) =>
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(rate));

        public void SetWindowDefaultStyle(object resourceKey = null)
        {
            var metadata = resourceKey == null
                ? new FrameworkPropertyMetadata(Application.Current.FindResource(typeof(Window)))
                : new FrameworkPropertyMetadata(Application.Current.FindResource(resourceKey));

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), metadata);
        }

        public void SetNavigationWindowDefaultStyle(object resourceKey = null)
        {
            var metadata = resourceKey == null
                ? new FrameworkPropertyMetadata(Application.Current.FindResource(typeof(NavigationWindow)))
                : new FrameworkPropertyMetadata(Application.Current.FindResource(resourceKey));

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(NavigationWindow), metadata);
        }

        public event PropertyChangedEventHandler PropertyChanged;

#if NET40
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#else
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endif
    }
}
