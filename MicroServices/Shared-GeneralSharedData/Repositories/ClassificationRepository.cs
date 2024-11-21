using Microsoft.EntityFrameworkCore;
using Shared_GeneralSharedData.Context;
using Shared_GeneralSharedData.Entities.Logger;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Mapping;
using Shared_GeneralSharedData.Models.Classification;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Shared_GeneralSharedData.Entities;
using SharedModels.Helpers;

namespace Shared_GeneralSharedData.Repositories
{
    public class ClassificationRepository : BaseRespository<Classification, ClassificationLogger, GeneralSharedDataContext>, IClassificationRepository
    {
        private readonly DbSet<Classification> _Set;
        public ClassificationRepository(GeneralSharedDataContext context) : base(context, context.Classification)
        {
            _Set = context.Classification;
        }
        #region CURD
        public async Task<ClassificationFullDataModel?> GetById(int? id)
        {
            Classification? entity = await GetEntityById(id);
            return ClassificationMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(ClassificationFullDataModel model)
        {
            Classification? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<ClassificationFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<ClassificationFullDataModel?>.ToPagedList(query.Select(s => ClassificationMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => ClassificationMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => ClassificationMapping.EntityToOuterIncludeModel(s)).ToListAsync();
            return list;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await UndoEntity(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            List<LogModel?>? logger = await GetEntityLogByRecordIdOrTranactionsId(recordId, null);
            return logger;
        }
        #endregion
    }
}
