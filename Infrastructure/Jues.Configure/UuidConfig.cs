using Suyaa.Configure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Configure
{
    /// <summary>
    /// UUID配置
    /// </summary>
    [Configurtion("")]
    public sealed class UuidConfig : IConfig
    {
        /// <summary>
        /// 机器Id
        /// </summary>
        public int MachineId { get; set; } = 0;
        /// <summary>
        /// 应用Id
        /// </summary>
        public int AppId { get; set; } = 0;

        /// <summary>
        /// 默认配置
        /// </summary>
        public void Default()
        {
            MachineId = 1;
            AppId = 1;
        }
    }
}
