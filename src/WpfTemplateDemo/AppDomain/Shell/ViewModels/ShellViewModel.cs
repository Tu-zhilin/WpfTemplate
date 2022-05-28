using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTemplate.Framework.Shell.Interface;
using WpfTemplateDemo.AppDomain.Shell.Interface;

namespace WpfTemplateDemo.AppDomain.Shell.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : ViewAware, IShell, IShow
    {
        private object _content;
        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyOfPropertyChange();
            }
        }

        public void Dispose()
        {
            //TODO:退出需要关闭的所有东西
        }

        public void Show(object viewModel)
        {
            Content = viewModel;
        }
    }
}
