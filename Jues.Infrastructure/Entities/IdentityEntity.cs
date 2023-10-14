using Suyaa.Hosting.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Entities
{
    /// <summary>
    /// 自增长Id实例
    /// </summary>
    public abstract class IdentityEntity : Entity<decimal>
    {
        /// <summary>
        /// 自增长Id实例
        /// </summary>
        public IdentityEntity() : base(0)
        {
        }

        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override decimal Id { get => base.Id; set => base.Id = value; }
    }
}
