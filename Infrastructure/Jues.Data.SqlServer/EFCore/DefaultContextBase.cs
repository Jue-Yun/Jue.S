using Suyaa.Data;

namespace Jues.Data.SqlServer.EFCore
{
    /// <summary>
    /// 默认数据库连接上下文
    /// </summary>
    public class DefaultContextBase : Suyaa.EFCore.SqlServer.SqlServerContext
    {
        /// <summary>
        /// 默认数据库连接上下文
        /// </summary>
        /// <param name="dbConnectionDescriptor"></param>
        public DefaultContextBase(DbConnectionDescriptor dbConnectionDescriptor) : base(dbConnectionDescriptor)
        {
            DbConnectionDescriptor = dbConnectionDescriptor;
        }

        /// <summary>
        /// 数据库连接描述
        /// </summary>
        public DbConnectionDescriptor DbConnectionDescriptor { get; }
    }
}
