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
    public sealed class UuidOption
    {
        /// <summary>
        /// 机器Id
        /// </summary>
        public int MachineId { get; set; } = 1;
        /// <summary>
        /// 应用Id
        /// </summary>
        public int AppId { get; set; } = 1;
    }
}
