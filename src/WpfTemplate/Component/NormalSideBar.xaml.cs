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
using System.Collections.ObjectModel;
using WpfTemplate.Framework.Menu.Interface;
using Caliburn.Micro;

namespace WpfTemplate.Component
{
    /// <summary>
    /// NormalSideBar.xaml 的交互逻辑
    /// </summary>
    public partial class NormalSideBar : UserControl
    {
        public NormalSideBar()
        {
            InitializeComponent();
            this.DataContext = this;

            var list = IoC.GetAll<IMenuItem>().ToList();
            list.Sort();
            Items = new ObservableCollection<IMenuItem>(list);
        }

        public ObservableCollection<IMenuItem> Items { get; set; }

        private IMenuItem _activeItem;
        public IMenuItem ActiveItem
        {
            get => _activeItem;
            set => ItemChange(value);
        }

        private void ItemChange(IMenuItem item)
        {
            _activeItem = item;
            _activeItem.Click(EventArgs.Empty);
        }
    }
}
