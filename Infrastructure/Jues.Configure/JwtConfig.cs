using Suyaa.Configure;
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
    public sealed class JwtConfig : IConfig
    {
        /// <summary>
        /// Header
        /// </summary>
        public string Header { get; set; } = string.Empty;
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 默认配置
        /// </summary>
        public void Default()
        {
            Header = "Jwt-Token";
            Key = "0b26efe2c64e4eb8ae8e97384935cb2c";
        }
    }
}
