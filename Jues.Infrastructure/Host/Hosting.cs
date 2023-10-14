namespace Jues.Infrastructure.Host
{
    /// <summary>
    /// 主机
    /// </summary>
    public static class Hosting
    {
        /// <summary>
        /// 创建一个新的构建器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Builder<T> CreateBuilder<T>(string[]? args)
            where T : StartupBase
        {
            return new Builder<T>(args);
        }
    }
}
