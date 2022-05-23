using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.BootStraper;

namespace WpfTemplateDemo.BootStrapper
{
    public class MyBootStrapper: AppBootStrapper
    {
        protected override IEnumerable<Assembly> ExtraAssemblies
        {
            get
            {
                yield return Assembly.GetAssembly(typeof(AppBootStrapper));
                // add more assemblies with exports as needed here
            }
        }
    }
}
