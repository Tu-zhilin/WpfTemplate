using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTemplate.Framework.Startup.Interface
{
    public interface IStartup
    {
        /// <summary>
        /// 准备
        /// </summary>
        void PreInitialize();
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
