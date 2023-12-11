using Microsoft.Extensions.Configuration;
using Suyaa.Data;
using Suyaa;
using Suyaa.Data.Dependency;
using Suyaa.Data.Factories;
using Suyaa.Data.Providers;
using Suyaa.Hosting.Data.Configures;
using Suyaa.Hosting.Common.Configures.Helpers;
using Suyaa.Hosting.Data.Helpers;
using Suyaa.EFCore.Contexts;

namespace Jues.Infrastructure.EFCore
{
    /// <summary>
    /// 数据库上下文工厂基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DesignTimeDbContextFactory<T> : Suyaa.EFCore.Factories.DesignTimeDbContextFactory<T>
        where T : DescriptorDbContext
    {
        /// <summary>
        /// 数据库上下文工厂基础类
        /// </summary>
        protected DesignTimeDbContextFactory() : base(GetDbConnectionDescriptorFactory())
        {
        }

        // 获取数据连接描述工厂
        private static IDbConnectionDescriptorFactory GetDbConnectionDescriptorFactory()
        {
            Console.WriteLine($"{nameof(GetDbConnectionDescriptorFactory)} start ...");
            var builder = new ConfigurationBuilder();
            var path = sy.Hosting.GetConfigurePath();
            Environment.CurrentDirectory = sy.Assembly.GetModulePath();
            Console.WriteLine($"{nameof(GetDbConnectionDescriptorFactory)} path {path}");
            var source = builder.SetBasePath(path).AddConfigurationSource<DatabaseConfig>();
            builder.Build();
            var config = source.GetConfig();
            if (config is null) throw new NullException<DatabaseConfig>();
            //List<IDbConnectionDescriptor> descriptors = new List<IDbConnectionDescriptor>();
            //if (actionConfigurationBuilder != null) actionConfigurationBuilder(builder);
            //return builder.Build();
            DbConnectionDescriptorProvider dbConnectionDescriptorProvider = new DbConnectionDescriptorProvider();
            foreach (var connection in config.Connections)
            {
                var descriptor = new DbConnectionDescriptor(connection.Key, connection.Value.GetDatabaseType(), connection.Value.ConnectionString);
                dbConnectionDescriptorProvider.AddDbConnection(descriptor);
            }
            DbConnectionDescriptorFactory dbConnectionDescriptorFactory = new DbConnectionDescriptorFactory(new List<IDbConnectionDescriptorProvider> { dbConnectionDescriptorProvider });
            return dbConnectionDescriptorFactory;
        }

        /// <summary>
        /// 创建DbContext实例
        /// </summary>
        /// <param name="dbConnectionDescriptorFactory"></param>
        /// <returns></returns>
        public abstract T CreateDbContext(IDbConnectionDescriptorFactory dbConnectionDescriptorFactory);

        /// <summary>
        /// 创建DbContext实例
        /// </summary>
        /// <param name="dbConnectionDescriptorFactory"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public override T CreateDbContext(IDbConnectionDescriptorFactory dbConnectionDescriptorFactory, string[] args)
        {
            return this.CreateDbContext(dbConnectionDescriptorFactory);
        }

        ///// <summary>
        ///// 创建DbContext实例
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public T CreateDbContext(string[] args)
        //{
        //    //var builder = new DbContextOptionsBuilder<T>();
        //    //var configuration = Builder.CreateConfiguration(args);
        //    //var dbConnectionDescriptorFactory = new DbConnectionDescriptorFactory(configuration);
        //    //return this.CreateDbContext(dbConnectionDescriptorFactory);
        //    Console.WriteLine(dbConnectionDescriptorFactory.DefaultConnection.ToConnectionString());
        //    return new TestDbContext(new DbConnectionDescriptorManager(dbConnectionDescriptorFactory));
        //}
    }
}
