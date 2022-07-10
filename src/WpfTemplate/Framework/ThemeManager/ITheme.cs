using System;
using System.Collections.Generic;

namespace WpfTemplate.Framework.ThemeManager
{
    public interface ITheme
    {
        /// <summary>
        /// 样式名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 样式资源文件
        /// </summary>
        IEnumerable<Uri> Resources { get; }
    }
}
