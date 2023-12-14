using Suyaa.Data.Dependency;
using Suyaa.Hosting.Common.DependencyInjection;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.EfCore.DbContexts;

namespace Jues.Infrastructure.EFCore
{
    /// <summary>
    /// 默认数据库连接上下文
    /// </summary>
    public class BasicDbContext : HostDbContext
    {
        private readonly IDependencyManager _dependencyManager;
        //private readonly IEntityModelFactory _entityModelFactory;
        private readonly IEnumerable<IEntityModelConvention> _entityModelConventions;

        /// <summary>
        /// 默认数据库连接上下文
        /// </summary>
        public BasicDbContext()
            : base(
                  DependencyManager.GetCurrent()!.ResolveRequired<IDbConnectionDescriptorManager>(),
                  DependencyManager.GetCurrent()!.ResolveRequired<IEntityModelConventionFactory>()
                  )
        {
            _dependencyManager = DependencyManager.GetCurrent()!;
            //_entityModelFactory = _dependencyManager.ResolveRequired<IEntityModelFactory>();
            _entityModelConventions = _dependencyManager.Resolves<IEntityModelConvention>();
        }
    }
}
