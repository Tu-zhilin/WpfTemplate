using System.ComponentModel;
using System.Threading;
using Caliburn.Micro;
using WpfTemplate.Framework.Startup;

namespace WpfTemplate.Framework.Splash.ViewModels
{
    public class SplashViewModel:Screen
    {
        private BackgroundWorker _worker;

        public SplashViewModel()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.WorkerReportsProgress = true;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.DoWork += _worker_DoWork;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);

            var _startup = IoC.Get<IStartup>();
            _startup?.PreInitialize();
            _startup?.Initialize();

            Thread.Sleep(5000);
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var _process = e.ProgressPercentage;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TryCloseAsync();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            _worker.RunWorkerAsync();
        }
    }
}
