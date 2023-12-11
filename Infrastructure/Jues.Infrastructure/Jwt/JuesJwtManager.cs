using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Jwt;

namespace Jues.Infrastructure.Jwt
{
    /// <summary>
    /// Jwt管理器
    /// </summary>
    public sealed class JuesJwtManager : JwtManager<JuesJwtData>
    {
        /// <summary>
        /// Jwt管理器
        /// </summary>
        /// <param name="dependency"></param>
        public JuesJwtManager(IDependencyManager dependency) : base(dependency)
        {
        }
    }
}
