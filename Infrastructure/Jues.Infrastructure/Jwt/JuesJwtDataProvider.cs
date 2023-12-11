using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.Jwt.Dependency;

namespace Jues.Infrastructure.Jwt
{
    /// <summary>
    /// jue.S专用Jwt数据
    /// </summary>
    public sealed class JuesJwtDataProvider : IJwtDataProvider<JuesJwtData>
    {
        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private IJwtBuilder<JuesJwtData>? _jwtBuilder;

        /// <summary>
        /// jue.S专用Jwt数据
        /// </summary>
        /// <param name="dependencyManager"></param>
        public JuesJwtDataProvider(IDependencyManager dependencyManager)
        {
            _dependencyManager = dependencyManager;
        }

        #endregion

        /// <summary>
        /// 获取Jwt创建器
        /// </summary>
        public IJwtBuilder<JuesJwtData> Builder => _jwtBuilder ??= _dependencyManager.ResolveRequired<IJwtBuilder<JuesJwtData>>();

        /// <summary>
        /// 创建Jwt数据对象
        /// </summary>
        /// <returns></returns>
        public JuesJwtData CreateJwtData()
        {
            return new JuesJwtData();
        }
    }
}
