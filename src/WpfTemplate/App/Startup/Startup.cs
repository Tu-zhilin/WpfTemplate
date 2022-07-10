using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.Startup;

namespace WpfTemplate.App.Startup
{
    [Export(typeof(IStartup))]
    public class Startup : StartupBase
    {
        public override void Initialize()
        {

        }

        public override void PreInitialize()
        {

        }
    }
}
