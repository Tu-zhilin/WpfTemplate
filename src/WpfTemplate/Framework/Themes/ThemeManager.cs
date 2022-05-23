﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTemplate.Framework.Themes.Interface;

namespace WpfTemplate.Framework.Themes
{
    [Export(typeof(IThemeManager))]
    public class ThemeManager : IThemeManager
    {
        [ImportMany]
        private List<ITheme> _themes;

        public List<ITheme> Themes => _themes;

        public EventHandler ThemeChangeHander { get; set; }

        private ITheme _currentTheme;

        public ITheme CurrentTheme
        {
            get => _currentTheme;
            set => _currentTheme = value;
        }

        private ResourceDictionary _applicationResourceDictionary;

        public ThemeManager()
        {

        }

        public void SetCurrentTheme(string name)
        {
            var theme = Themes.FirstOrDefault(x => x.Name == name);
            if (null == theme)
                return;

            if (theme == CurrentTheme)
                return;

            if (!Themes.Contains(theme))
                return;

            if(null == _applicationResourceDictionary)
            {
                _applicationResourceDictionary = new ResourceDictionary();
                Application.Current.Resources.MergedDictionaries.Add(_applicationResourceDictionary);
            }

            _applicationResourceDictionary.BeginInit();
            _applicationResourceDictionary.MergedDictionaries.Clear();
            //增加样式文件
            foreach (var uri in theme.Resources)
                _applicationResourceDictionary.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = uri
                });

            _applicationResourceDictionary.EndInit();
            //更新事件通知
            ThemeChangeHander?.Invoke(this, EventArgs.Empty);
        }

        public void Register(EventHandler handle)
        {
            ThemeChangeHander += handle;
        }

        public void LogOut(EventHandler handle)
        {
            ThemeChangeHander -= handle;
        }
    }
}
