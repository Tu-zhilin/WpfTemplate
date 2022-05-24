using Caliburn.Micro;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTemplate.Framework.MainWindow.Interface;
using WpfTemplate.Framework.MainWindow.Views;
using WpfTemplate.Framework.Shell.Interface;
using WpfTemplate.Framework.Startup.Interface;

namespace WpfTemplate.Framework.MainWindow.ViewModels
{
    [Export(typeof(IMainWindow))]
    public class MainWindowViewModel: Conductor<IShell>.Collection.OneActive, IMainWindow, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// 主视图
        /// </summary>
        private MainWindowView _view;
        /// <summary>
        /// 窗口标题
        /// </summary>
        private string _title = "Wpf Template";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyOfPropertyChange();
            }
        }
        /// <summary>
        /// 窗体宽度
        /// </summary>
        private double _width = 1280.0;
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyOfPropertyChange();
            }
        }
        /// <summary>
        /// 窗体高度
        /// </summary>
        private double _height = 720.0;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                NotifyOfPropertyChange();
            }
        }
        /// <summary>
        /// 窗体初始状态
        /// </summary>
        private WindowState _state = WindowState.Normal;
        public WindowState State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyOfPropertyChange();
            }
        }

        private PackIconMaterialKind _icon = PackIconMaterialKind.Robot;
        public PackIconMaterialKind Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                NotifyOfPropertyChange();
            }
        }

        public MainWindowViewModel()
        {
            
        }

        protected override void OnViewLoaded(object view)
        {
            _view = view as MainWindowView;
        }

        /// <summary>
        /// 部件导入完成通知
        /// </summary>
        public void OnImportsSatisfied()
        {
            ActivateItemAsync(IoC.Get<IShell>());
        }

        public void Dispose()
        {
            ActiveItem?.Dispose();
        }
    }
}
