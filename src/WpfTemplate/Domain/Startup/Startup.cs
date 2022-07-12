using System.ComponentModel.Composition;
using WpfTemplate.Framework.Startup;

namespace WpfTemplate.Domain.Startup
{
    [Export(typeof(IStartup))]
    public class Startup : StartupBase
    {
        public override void PreInitialize()
        {
            //预留
        }
        
        public override void Initialize()
        {
            //初始化
            _mainWindow.Width = 1280.0;
            _mainWindow.Height = 720.0;
            _mainWindow.Title = "Template Project";
        }
    }
}
