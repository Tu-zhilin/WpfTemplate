using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.Themes.Interface;

namespace WpfTemplate.Framework.Themes
{
    [Export(typeof(ITheme))]
    public class Dark : ITheme
    {
        public string Name => "Dark";

        public IEnumerable<Uri> Resources
        {
            get
            {
                yield return new Uri("pack://application:,,,/WpfTemplate;component/Themes/Dark.xaml"); 
            }
        }
    }
}
