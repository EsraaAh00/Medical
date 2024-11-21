using Microsoft.EntityFrameworkCore;
using Shared_GeneralSharedData.Context;
using Shared_GeneralSharedData.Entities.Logger;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Mapping;
using Shared_GeneralSharedData.Models.Degree;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Shared_GeneralSharedData.Entities;
using SharedModels.Helpers;

namespace Shared_GeneralSharedData.Repositories
{
    public class DegreeRepository : BaseRespository<Degree, DegreeLogger, GeneralSharedDataContext>, IDegreeRepository
    {
        private readonly DbSet<Degree> _Set;
        public DegreeRepository(GeneralSharedDataContext context) : base(context, context.Degree)
        {
            _Set = context.Degree;
        }
        #region CURD
        public async Task<DegreeFullDataModel?> GetById(int? id)
        {
            Degree? entity = await GetEntityById(id);
            return DegreeMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(DegreeFullDataModel model)
        {
            Degree? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<DegreeFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.NameLocalized.Contains(filter.Name ?? "") || s.Name.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<DegreeFullDataModel?>.ToPagedList(query.Select(s => DegreeMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => DegreeMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => DegreeMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
