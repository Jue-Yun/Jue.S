using Suyaa.DependencyInjection;
using Suyaa.Hosting.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
