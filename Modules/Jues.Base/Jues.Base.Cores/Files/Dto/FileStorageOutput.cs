using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting.AutoMapper.Attributes;
using Jues.Base.Entities.Files;

namespace Jues.Base.Cores.Files.Dto
{
    /// <summary>
    /// 文件存储输出信息
    /// </summary>
    [MapFrom(typeof(FileStorage))]
    public sealed class FileStorageOutput
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 存储路径
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// MIMI类型
        /// </summary>
        public string MimeType { get; set; } = string.Empty;
        /// <summary>
        /// 文件大小
        /// </summary>
        public decimal Size { get; set; } = 0;
        /// <summary>
        /// MD5校验值
        /// </summary>
        public string Md5 { get; set; } = string.Empty;
    }
}
