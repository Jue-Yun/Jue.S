using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Suyaa.Data.Entities;
using Suyaa.Hosting.Data.Entities;

namespace Jues.Base.Entities.Files
{
    /// <summary>
    /// 文件存储信息
    /// </summary>
    [Table("file_storage", Schema = "bas")]
    [Description("文件存储信息")]
    public sealed class FileStorage : NonModifiableEntity
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [Column("name", TypeName = "varchar(512)")]
        [StringLength(512)]
        [Description("文件名")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 存储路径
        /// </summary>
        [Column("path", TypeName = "varchar(512)")]
        [StringLength(512)]
        [Description("存储路径")]
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// MIMI类型
        /// </summary>
        [Column("mime_type", TypeName = "varchar(64)")]
        [StringLength(64)]
        [Description("MIMI类型")]
        public string MimeType { get; set; } = string.Empty;
        /// <summary>
        /// 文件大小
        /// </summary>
        [Column("size", TypeName = "decimal(18,0)")]
        [Description("文件大小")]
        public decimal Size { get; set; } = 0;
        /// <summary>
        /// MD5校验值
        /// </summary>
        [Column("md5", TypeName = "varchar(32)")]
        [Description("MD5校验值")]
        public string Md5 { get; set; } = string.Empty;
    }
}
