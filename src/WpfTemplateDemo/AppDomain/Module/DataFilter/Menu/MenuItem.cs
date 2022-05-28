﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.IconPacks;
using WpfTemplate.Framework.Menu;
using WpfTemplate.Framework.Menu.Interface;
using WpfTemplate.Framework.Shell.Interface;
using WpfTemplateDemo.AppDomain.Module.DataFilter.ViewModels;
using WpfTemplateDemo.AppDomain.Shell.Interface;

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
            //实现异步操作
            (IoC.Get<IShell>() as IShow).Show(IoC.Get<DataFilterViewModel>());
        }
    }
}