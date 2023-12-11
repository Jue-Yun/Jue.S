using Suyaa.Configure;
using Suyaa.Hosting.Common.Configures.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Configures
{
    /// <summary>
    /// 上传配置
    /// </summary>
    [Configuration("Storage")]
    public sealed class StorageConfig : IConfig
    {
        /// <summary>
        /// 存储方式
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 存储路径
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// 默认配置
        /// </summary>
        public void Default()
        {
            Type = "folder";
            Path = "./upload";
        }
    }
}
