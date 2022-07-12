using System;
using WpfTemplate.Framework.Shell;

namespace WpfTemplate.Framework.MainWindow
{
    public interface IMainWindow
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
    }
}
