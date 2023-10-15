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
    public sealed class JuesJwtDataProvider : IJwtDataProvider
    {
        public IJwtData CreateJwtData()
        {
            return new JuesJwtData();
        }
    }
}
