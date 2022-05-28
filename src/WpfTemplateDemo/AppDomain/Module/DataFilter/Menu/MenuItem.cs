using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;
using WpfTemplate.Framework.Menu;
using WpfTemplate.Framework.Menu.Interface;

namespace WpfTemplateDemo.AppDomain.Module.DataFilter.Menu
{
    [Export(typeof(IMenuItem))]
    public class MenuItem : MenuItemBase
    {
        public override int Index => 2;

        public override PackIconMaterialKind Icon => PackIconMaterialKind.Magnify;

        public override string Name => "Data Search";

        public override void Click(EventArgs args)
        {
            //TODO:
        }
    }
}
