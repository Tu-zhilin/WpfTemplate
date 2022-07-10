using System.ComponentModel.Composition;
using WpfTemplate.Framework.MainWindow;
using WpfTemplate.Framework.ThemeManager;

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

        public StartupBase() { }

        public abstract void PreInitialize();

        public abstract void Initialize();
    }
}
