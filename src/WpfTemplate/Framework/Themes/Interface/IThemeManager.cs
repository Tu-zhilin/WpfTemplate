using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Framework.Themes.Interface
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
