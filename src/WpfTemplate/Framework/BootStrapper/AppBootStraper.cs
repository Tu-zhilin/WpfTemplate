using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using WpfTemplate.Framework.MainWindow;
using WpfTemplate.Framework.Startup.Interface;

namespace WpfTemplate.Framework.BootStraper
{
    /// <summary>
    /// 引导程序,用于处理程序启动前的所有准备工作
    /// </summary>
    public class AppBootStrapper : BootstrapperBase
    {
        /// <summary>
        /// 容器
        /// </summary>
        private CompositionContainer container;

        /// <summary>
        /// 用以添加额外的程序集
        /// </summary>
        protected virtual IEnumerable<Assembly> ExtraAssemblies => Enumerable.Empty<Assembly>();

        public AppBootStrapper() => Initialize();

        /// <summary>
        /// 配置IOC（MEF）
        /// </summary>
        protected override void Configure()
        {
            base.Configure();

            //加载程序集
            var l = AssemblySource.Instance.Select(x => new AssemblyCatalog(x));
            var catalog = new AggregateCatalog(l);
            container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);
            batch.AddExportedValue(this);
            container.Compose(batch);

            //初始化,用户根据自己的需求增加初始化功能
            var startUp = IoC.Get<IStartup>();
            startUp?.PreInitialize();
            startUp?.Initialize();
        }

        /// <summary>
        /// 获取程序集合
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.AddRange(base.SelectAssemblies());
            assemblies.AddRange(ExtraAssemblies); 
            return assemblies;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="service"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override object GetInstance(Type service, string key = null)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();
            else
                //不报错,用户自行处理
                return null; 
        }

        /// <summary>
        /// 获取一类对象
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetAllInstances(Type service) => container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="instance"></param>
        protected override void BuildUp(object instance) => container.SatisfyImportsOnce(instance);

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IMainWindow>();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnExit(object sender, EventArgs e)
        {
            IoC.Get<IMainWindow>().Dispose();
            base.OnExit(sender, e);
        }
    }
}

//TODO:设计界面加载动画 -> backgroundworker
