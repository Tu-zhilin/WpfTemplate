namespace WpfTemplate.Framework.Startup
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
