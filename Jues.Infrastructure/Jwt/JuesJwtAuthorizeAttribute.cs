using Suyaa.Hosting.Jwt.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Jwt
{
    /// <summary>
    /// Jwt授权
    /// </summary>
    public sealed class JuesJwtAuthorizeAttribute : JwtAuthorizeAttribute
    {
        /// <summary>
        /// Jwt授权
        /// </summary>
        public JuesJwtAuthorizeAttribute() : base(typeof(JuesJwtData))
        {
        }
    }
}
