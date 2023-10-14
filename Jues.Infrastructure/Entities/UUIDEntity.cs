using Suyaa;
using Suyaa.Hosting.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Entities
{
    /// <summary>
    /// 自增长Id实例
    /// </summary>
    public abstract class UUIDEntity : Entity<string>
    {
        /// <summary>
        /// 自增长Id实例
        /// </summary>
        public UUIDEntity() : base(sy.Generator.GetNewUUID().ToString(false))
        {
        }

        /// <summary>
        /// Id
        /// </summary>
        [Column("id", TypeName = "varchar(32)")]
        [StringLength(32)]
        [Description("Id")]
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
