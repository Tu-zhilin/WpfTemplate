using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;
using WpfTemplate.Framework.Menu;
using WpfTemplate.Framework.Menu.Interface;

namespace WpfTemplateDemo.AppDomain.Module.DataSearch.Menu
{
    [Export(typeof(IMenuItem))]
    public class MenuItem : MenuItemBase
    {
        public override int Index => 1;

        public override string Name => "DataBase";

        public override PackIconMaterialKind Icon =>  PackIconMaterialKind.Database;

        public override void Click(EventArgs args)
        {
            
        }
    }
}
