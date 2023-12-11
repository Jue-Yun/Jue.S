using Suyaa.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jues.Base.Entities.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("user_info", Schema = "bas")]
    [Description("用户信息")]
    public sealed class UserInfo : UUIDKeyEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Column("name", TypeName = "varchar(128)")]
        [StringLength(128)]
        [Description("名称")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        [Column("pwd", TypeName = "varchar(32)")]
        [StringLength(32)]
        [Description("密码")]
        public string Pwd { get; set; } = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nick", TypeName = "varchar(128)")]
        [StringLength(128)]
        [Description("昵称")]
        public string? Nick { get; set; }
    }
}
