using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;

namespace WpfTemplate.Framework.Menu.Interface
{
    public interface IMenuItem: IComparable<IMenuItem>
    {
        string Name { get;}

        PackIconMaterialKind Icon { get; }

        bool IsActive { get; set; }

        void Click(EventArgs args);

        int Index { get; }
    }
}
