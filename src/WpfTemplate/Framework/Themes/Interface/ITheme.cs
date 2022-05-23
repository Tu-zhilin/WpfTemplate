using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Framework.Themes.Interface
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
