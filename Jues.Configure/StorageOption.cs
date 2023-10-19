using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Configure
{
    /// <summary>
    /// 上传配置
    /// </summary>
    public sealed class StorageOption
    {
        /// <summary>
        /// 存储方式
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 存储路径
        /// </summary>
        public string Path { get; set; } = string.Empty;
    }
}
