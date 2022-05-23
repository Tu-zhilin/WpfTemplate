using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Framework.MainWindow.Interface
{
    public interface IMainWindow: IDisposable
    {
        /// <summary>
        /// 主窗口标题
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 窗口宽度
        /// </summary>
        double Width { get; set; }
        /// <summary>
        /// 窗口高度
        /// </summary>
        double Height { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        PackIconMaterialKind Icon { get; set; }
    }
}
