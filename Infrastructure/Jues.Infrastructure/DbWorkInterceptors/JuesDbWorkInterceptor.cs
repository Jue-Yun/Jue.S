using Suyaa;
using Suyaa.Data.DbWorks.Dependency;
using Suyaa.Data.Dependency;
using Suyaa.Data.Models;
using Suyaa.Logs.Dependency;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfCoreHosting.DbWorkInterceptors
{
    /// <summary>
    /// 数据库作业拦截器
    /// </summary>
    public sealed class JuesDbWorkInterceptor : IDbWorkInterceptor
    {
        private readonly ILogger _logger;

        /// <summary>
        /// 数据库作业拦截器
        /// </summary>
        /// <param name="logger"></param>
        public JuesDbWorkInterceptor(
            ILogger logger
            )
        {
            _logger = logger;
        }

        /// <summary>
        /// 数据库命令创建
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DbCommand? DbCommandCreating(DbCommand? command)
        {
            //throw new NotImplementedException();
            //_logger.Debug($"{nameof(DbCommandCreating)}");
            return command;
        }

        /// <summary>
        /// 数据库命令执行
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DbCommand DbCommandExecuting(DbCommand command)
        {
            //throw new NotImplementedException();
            _logger.Debug($"{nameof(DbCommandExecuting)} - {command.CommandText}");
            return command;
        }
    }
}
