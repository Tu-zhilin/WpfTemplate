using System;
using System.Collections.Generic;

namespace WpfTemplate.Framework.ThemeManager
{
    public interface IThemeManager
    {
        /// <summary>
        /// 当前样式
        /// </summary>
        ITheme CurrentTheme { get; set; }
        /// <summary>
        /// 样式集合
        /// </summary>
        List<ITheme> Themes { get; }
        /// <summary>
        /// 设置当前
        /// </summary>
        /// <param name="theme"></param>
        void SetCurrentTheme(string name);
        /// <summary>
        /// 事件注册
        /// </summary>
        /// <param name="handle"></param>
        void Register(EventHandler handle);
        /// <summary>
        /// 事件注销
        /// </summary>
        /// <param name="handle"></param>
        void LogOut(EventHandler handle);
    }
}
