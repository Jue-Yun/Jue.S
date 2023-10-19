using Suyaa.DependencyInjection;
using Suyaa.Hosting.Jwt;
using Suyaa.Hosting.Jwt.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public JuesJwtDataProvider(IDependencyManager dependencyManager)
        {
            _dependencyManager = dependencyManager;
        }

        #endregion

        public IJwtBuilder<JuesJwtData> Builder => _jwtBuilder ??= _dependencyManager.Resolve<IJwtBuilder<JuesJwtData>>();

        public JuesJwtData CreateJwtData()
        {
            return new JuesJwtData();
        }
    }
}
