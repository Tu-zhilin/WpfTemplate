using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows;
using WpfTemplate.Framework.Shell;

namespace WpfTemplate.Framework.MainWindow.ViewModels
{
    [Export(typeof(IMainWindow))]
    public class MainWindowViewModel: Conductor<IShell>.Collection.OneActive, IMainWindow, IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// 窗口标题
        /// </summary>
        private string _title = "Template Project";
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

        public MainWindowViewModel() { }

        /// <summary>
        /// 导入完成通知
        /// </summary>
        public void OnImportsSatisfied() => ActivateItemAsync(IoC.Get<IShell>());

        public void Close()
        {
            ActiveItem?.Dispose();
            //TODO:是否关闭程序
            Application.Current.Shutdown();
        }
    }
}
