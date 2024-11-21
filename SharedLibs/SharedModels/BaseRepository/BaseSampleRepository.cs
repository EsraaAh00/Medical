using Microsoft.EntityFrameworkCore;
using SharedModels.Entities;
using SharedModels.Models;
using System.Collections.Generic;

namespace SharedModels.BaseRepository
{
    public class BaseRepository<TEntity, CustomDbContext> where CustomDbContext : IDbContext
        where TEntity : Entities.BaseModel
    {
        protected CustomDbContext _context;
        protected DbSet<TEntity> _set;
        public BaseRepository(CustomDbContext context, DbSet<TEntity> set)
        {
            _context = context;
            _set = set;

        }
        public async Task<BaseResponse> SaveAsync(TEntity? entity)
        {
            try
            {
                if (entity?.Id == 0)
                {
                    await _context.AddAsync(entity);
                }
                await _context.SaveChangesAsync();
                return new BaseResponse { IsError = false, Message = "Saved Successfully", TargetId = entity?.Id };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<BaseResponse> HardDeleteAsync(int? recordId)
        {
            try
            {
                TEntity? entity = await _set.FirstOrDefaultAsync(s => s.Id == recordId);
                if (entity != null)
                {
                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                    return new BaseResponse { IsError = false, Message = "Deleted" };
                }
                return new BaseResponse { IsError = true, Message = "Error" };

            }
            catch (Exception)
            {

                return new BaseResponse { IsError = true, Message = "Error" };
            }
        }

        public async Task<TEntity?> GetById(int? recordId)
        {
            TEntity? entity = await _set.FirstOrDefaultAsync(s => s.Id == recordId);
            return entity;
        }

        public async Task<TEntity?> GetSetting()
        {
            TEntity? entity = await _set.AsNoTracking().FirstOrDefaultAsync();
            return entity;
        }
    }
}

