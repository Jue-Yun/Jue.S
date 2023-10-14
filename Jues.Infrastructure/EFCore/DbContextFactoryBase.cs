using Jues.Infrastructure.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Suyaa.Hosting.EFCore;
using Suyaa.Hosting.EFCore.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.EFCore
{
    public abstract class DbContextFactoryBase<T> : IDesignTimeDbContextFactory<T>
        where T : DbContext
    {
        /// <summary>
        /// 创建DbContext实例
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public abstract T CreateDbContext(IDbConnectionDescriptorFactory dbConnectionDescriptorFactory);

        /// <summary>
        /// 创建DbContext实例
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<T>();
            var configuration = Builder.CreateConfiguration(args);
            var dbConnectionDescriptorFactory = new DbConnectionDescriptorFactory(configuration);
            return this.CreateDbContext(dbConnectionDescriptorFactory);
        }
    }
}
