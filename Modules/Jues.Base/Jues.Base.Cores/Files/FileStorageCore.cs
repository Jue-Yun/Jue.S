using Jues.Base.Entities.Files;
using Microsoft.EntityFrameworkCore;
using Suyaa;
using Suyaa.Hosting.Data.Dependency;
using Suyaa.Hosting.Jwt.Dependency;
using Suyaa.Hosting.Kernel;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Files
{
    /// <summary>
    /// 文件存储
    /// </summary>
    public sealed class FileStorageCore : ServiceCore
    {
        #region DI注入

        private readonly IRepository<FileStorage, string> _fileStorageRepository;

        /// <summary>
        /// Jwt信息
        /// </summary>
        public FileStorageCore(
            IRepository<FileStorage, string> fileStorageRepository
            )
        {
            _fileStorageRepository = fileStorageRepository;
        }

        #endregion

        /// <summary>
        /// 获取查询
        /// </summary>
        /// <returns></returns>
        public IQueryable<FileStorage> GetQuery()
        {
            return _fileStorageRepository.Query().AsNoTracking();
        }

        #region 获取单实例

        /// <summary>
        /// 按照分类Id获取文件存储信息
        /// </summary>
        /// <param name="id">分类Id</param>
        /// <returns></returns>
        public async Task<FileStorage?> GetDataById(string id)
        {
            var data = await GetQuery()
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
            return data;
        }

        /// <summary>
        /// 按照分类Id获取分类信息
        /// </summary>
        /// <param name="id">分类Id</param>
        /// <returns></returns>
        public async Task<FileStorage> GetDataRequiredById(string id)
        {
            var data = await GetDataById(id);
            if (data is null) throw new UserFriendlyException($"文章分类'{id}'不存在");
            return data;
        }

        #endregion

        #region 新增数据

        /// <summary>
        /// 根据实例添加单行数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task InsertData(FileStorage data)
        {
            await _fileStorageRepository.InsertAsync(data);
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 根据实例更新单行数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task UpdateData(FileStorage data)
        {
            await _fileStorageRepository.UpdateAsync(data);
        }

        #endregion

        #region 删除数据

        /// <summary>
        /// 根据实例删除单行数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task DeleteData(FileStorage data)
        {
            await _fileStorageRepository.DeleteAsync(data);
        }

        /// <summary>
        /// 根据实例删除单行数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDataById(string id)
        {
            var data = await GetDataById(id);
            if (data is null) return;
            await _fileStorageRepository.DeleteAsync(data);
        }

        #endregion
    }
}
