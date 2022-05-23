using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.Startup;
using WpfTemplate.Framework.Startup.Interface;

namespace WpfTemplateDemo.Startup
{
    /// <summary>
    /// 在此类中初始化
    /// </summary>
    [Export(typeof(IStartup))]
    public class Startup : StartupBase
    {
        public override void Initialize()
        {
            _mainWindow.Title = "Wpf Template Demo";
        }
    }
}
