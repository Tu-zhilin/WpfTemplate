using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using WpfTemplate.Framework.MainWindow;
using WpfTemplate.Framework.Splash.ViewModels;
using WpfTemplate.Framework.Startup;

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
        private CompositionContainer _container;

        /// <summary>
        /// 是否启动Splash界面
        /// </summary>
        private readonly bool _use_splash = true;

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

            //通过主界面关闭程序
            Application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //加载程序集
            var _l = AssemblySource.Instance.Select(x => new AssemblyCatalog(x));
            var _catalog = new AggregateCatalog(_l);
            _container = new CompositionContainer(_catalog);
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);
            batch.AddExportedValue(this);
            _container.Compose(batch);
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
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();
            else
                return null;  
        }

        /// <summary>
        /// 获取一类对象
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetAllInstances(Type service) => _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="instance"></param>
        protected override void BuildUp(object instance) => _container.SatisfyImportsOnce(instance);

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Splashing
            if (_use_splash)
            {
                IoC.Get<IWindowManager>().ShowDialogAsync(new SplashViewModel());
            }
            else
            {
                var startUp = IoC.Get<IStartup>();
                startUp?.PreInitialize();
                startUp?.Initialize();
            }

            DisplayRootViewFor<IMainWindow>();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnExit(object sender, EventArgs e)
        {
            //nothing
        }
    }
}
