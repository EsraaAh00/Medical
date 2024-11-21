using SharedModels.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedModels.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SharedModels.BaseRepository
{
    public class BaseRespository<TEntity, LogType, CustomDbContext> where CustomDbContext : IDbContext where LogType : LogModel where TEntity : Entities.BaseModel
    {

        protected CustomDbContext _context;
        protected DbSet<TEntity> _set;
        public BaseRespository(CustomDbContext context, DbSet<TEntity> set)
        {
            _context = context;
            _set = set;


        }
        private string ReadTableName()
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            return entityType?.GetTableName() ?? "";
        }
        private string ReadLogTableName()
        {
            var entityType = _context.Model.FindEntityType(typeof(LogType));
            return entityType?.GetTableName() ?? "";
        }
        public async Task<BaseResponse?> SaveAsync(Pair<TEntity, LogModel> entityWithLog)
        {
            try
            {
                if (entityWithLog.First?.Id == 0)
                {
                    await _set.AddAsync(entityWithLog.First);
                }
                await _context.SaveChangesAsync();
                if (entityWithLog.Second != null)
                {
                    entityWithLog.Second.JsonAfter = JsonConvert.SerializeObject(entityWithLog.First);
                    entityWithLog.Second.RecordId = entityWithLog.First?.Id;
                    SaveLog(entityWithLog.Second);
                }
                return new BaseResponse { IsError = false, Message = Helpers.DicHelper.GetMessage("Saved Successfully"), TargetId = entityWithLog.First?.Id };

            }
            catch (Exception)
            {
                return new BaseResponse { IsError = true, Message = "Error" };
            }
        }
        private async Task<int> HardDeleteAsync(int? id, List<LogModel?>? logs)
        {
            try
            {
                if (id != null)
                {
                    TEntity? entity = await GetEntityByIdWithTracking(id);
                    if (entity != null)
                    {
                        _context.Remove(entity);
                        await _context.SaveChangesAsync();
                        if (logs != null)
                        {
                            await DeleteLogsAsync(logs);
                        }
                        return 1;
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        private async Task<int> DeleteLogsAsync(List<LogModel?>? logs)
        {
            try
            {
                if (logs != null)
                {
                    foreach (LogModel? log in logs)
                    {
                        LogType? logEntity = (LogType?)Activator.CreateInstance(typeof(LogType), new object[] { log });
                        if (logEntity != null)
                        {
                            _context.Remove(logEntity);
                            await _context.SaveChangesAsync();
                        }
                    }

                    return 0;
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int SaveLog(LogModel log)
        {
            try
            {
                LogType? logEntity = (LogType?)Activator.CreateInstance(typeof(LogType), new object[] { log });
                if (logEntity != null)
                {
                    logEntity.EntityName = ReadTableName();
                    _context.AddAsync(logEntity);
                    _context.SaveChangesAsync();
                    return logEntity.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<List<LogModel?>?> GetEntityLogByRecordIdOrTranactionsId(int? recordId, int? transactionId)
        {

            return await _context.GetRecordLog(ReadTableName(), recordId, ReadLogTableName(), transactionId);

        }
        public async Task<TEntity?> GetEntityByIdWithTracking(int? recordId)
        {
            TEntity? entity = await _set.FirstOrDefaultAsync(s => s.Id == recordId);
            return entity;
        }
        public async Task<TEntity?> GetEntityById(int? recordId)
        {
            TEntity? entity = await _set.AsNoTracking().FirstOrDefaultAsync(s => s.Id == recordId);
            return entity;
        }

        public async Task<List<TEntity>> GetEntitiesByIds(List<int> recordIds)
        {
            if (recordIds == null || recordIds.Count == 0)
            {
                return new List<TEntity>();
            }

            List<TEntity> entities = await _set.AsNoTracking()
                                               .Where(s => recordIds.Contains(s.Id))
                                               .ToListAsync();

            return entities;
        }

        public async Task<TEntity?> GetEntityByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = await _set.AsNoTracking().FirstOrDefaultAsync(predicate);
            return entity;
        }

        public async Task<List<TEntity>> GetEntitiesByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = await _set.AsNoTracking().Where(predicate).ToListAsync();
            return entities;
        }

        public async Task<TEntity?> GetEntitySetting()
        {
            TEntity? entity = await _set.AsNoTracking().FirstOrDefaultAsync();
            return entity;
        }

        public async Task<TEntity?> GetSettingEntityWithTracking()
        {
            TEntity? entity = await _set.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<BaseResponse> UndoEntity(int? recordId, int? transactionId)
        {
            try
            {
                List<LogModel?>? logger = await GetEntityLogByRecordIdOrTranactionsId(recordId, transactionId);
                LogModel? selectedVersion;
                TEntity? currentEnitity = await GetEntityById(recordId);
                if (logger == null || logger?.Count() == 0 || currentEnitity == null)
                {
                    return new BaseResponse { IsError = true, Message = "Can't Roleback" };
                }
                else
                {
                    if (transactionId != null)
                    {
                        selectedVersion = logger?.FirstOrDefault(s => s?.Id == transactionId);
                    }
                    else
                    {
                        selectedVersion = logger?.LastOrDefault();
                    }

                    if (selectedVersion != null)
                    {
                        currentEnitity = selectedVersion.GetModelFromJsonBefore<TEntity>();
                        if (currentEnitity == null)
                        {
                            await HardDeleteAsync(recordId, logger);

                        }
                        else
                        {
                            _context.Entry(currentEnitity).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        return new BaseResponse { IsError = false, Message = "Undo Successfully" };
                    }
                    else
                    {

                        return new BaseResponse { IsError = true, Message = "Cant RoleBack To This Version" };
                    }


                }
            }
            catch (Exception)
            {
                return new BaseResponse { IsError = true, Message = "Error" };
            }
        }



    }
}

