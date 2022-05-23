using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.MainWindow.Interface;
using WpfTemplate.Framework.Startup.Interface;
using WpfTemplate.Framework.Themes.Interface;

namespace WpfTemplate.Framework.Startup
{
    /// <summary>
    /// 程序启动后设置初始状态
    /// </summary>
    public abstract class StartupBase: IStartup
    {
        [Import]
        protected IMainWindow _mainWindow;
        [Import]
        protected IThemeManager _themeManager;

        public StartupBase()
        {
            
        }

        public virtual void PreInitialize()
        {
            _themeManager?.SetCurrentTheme("Dark");
        }

        public virtual void Initialize()
        {

        }
    }
}
