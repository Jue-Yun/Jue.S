using Microsoft.EntityFrameworkCore;
using Suyaa.Data;
using Suyaa.Data.Dependency;
using Suyaa.Data.Helpers;
using Suyaa.Data.Sources;
using Suyaa.EFCore.Contexts;
using Suyaa.EFCore.Models;
using Suyaa.EFCore.Sources;
using Suyaa.Hosting.Common.DependencyInjection;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.EfCore.DbContexts;
using Suyaa.Hosting.EFCore.Dependency;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
