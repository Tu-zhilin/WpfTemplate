using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.Shell.Interface;

namespace WpfTemplateDemo.AppDomain.Shell.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        public void Dispose()
        {
            //TODO:退出需要关闭的所有东西
        }
    }
}
