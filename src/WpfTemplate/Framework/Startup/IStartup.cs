using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.MainWindow;
using WpfTemplate.Framework.ThemeManager;

namespace WpfTemplate.Framework.Startup
{
    public interface IStartup
    {
        /// <summary>
        /// 准备
        /// </summary>
        void PreInitialize();
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
