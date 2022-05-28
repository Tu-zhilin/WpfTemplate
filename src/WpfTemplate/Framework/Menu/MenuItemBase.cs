using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;
using WpfTemplate.Framework.Menu.Interface;

namespace WpfTemplate.Framework.Menu
{
    public abstract class MenuItemBase : IMenuItem
    {
        public virtual int Index { get; } = 0;

        public abstract string Name { get; }

        public abstract PackIconMaterialKind Icon { get; }

        private bool _isActive;
        public virtual bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public abstract void Click(EventArgs args);

        public int CompareTo(IMenuItem other)
        {
            if (other.Index > this.Index)
                return -1;

            if (other.Index == this.Index)
                return 0;

            if (other.Index < this.Index)
                return -1;

            return 0;
        }
    }
}
