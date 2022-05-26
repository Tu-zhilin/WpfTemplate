using Caliburn.Micro;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTemplate.Component
{
    /// <summary>
    /// WindowButton.xaml 的交互逻辑
    /// </summary>
    public partial class NormalWindowButton : UserControl
    {
        public NormalWindowButton()
        {
            InitializeComponent();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Window window = button.CommandParameter as Window;
            if (window == null)
                return;
            window.WindowState = WindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Window window = button.CommandParameter as Window;
            if (window == null)
                return;
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    this.maximizeIcon.Kind = PackIconMaterialKind.DockWindow;
                    break;
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    this.maximizeIcon.Kind = PackIconMaterialKind.WindowMaximize;
                    break;
                default:
                    break;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Window window = button.CommandParameter as Window;
            if (window == null)
                return;
            window.Close();
        }
    }
}
