using Jues.Base.Entities.Files;
using Microsoft.EntityFrameworkCore;
using Suyaa;
using Suyaa.Data.Dependency;
using Suyaa.Data.Helpers;
using Suyaa.Data.Repositories.Dependency;
using Suyaa.Hosting.Common.Exceptions;
using Suyaa.Hosting.Core.Services;
using System.ComponentModel;

namespace Jues.Base.Cores.Files
{
    /// <summary>
    /// 文件存储
    /// </summary>
    [Description(ClassDescription)]
    public sealed class FileStorageCore : DomainServiceCore
    {
        /// <summary>
        /// 类描述
        /// </summary>
        private const string ClassDescription = "文件存储";

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

        #region 数据校验

        /// <summary>
        /// 检测文件Id是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> CheckIdExists(string id)
        {
            return await GetQuery().Where(d => d.Id == id).AnyAsync();
        }

        /// <summary>
        /// 检测Id是否存在, 不存在则抛出异常
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task VerifyIdExists(string id)
        {
            var exists = await CheckIdExists(id);
            if (!exists) throw new UserFriendlyException("{0}Id'{1}'不存在", ClassDescription, id);
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
