using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Configure
{
    /// <summary>
    /// Jwt配置
    /// </summary>
    public sealed class JwtOption
    {
        /// <summary>
        /// Header
        /// </summary>
        public string Header { get; set; } = string.Empty;
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; } = string.Empty;
    }
}
