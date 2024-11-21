using Vendor_ProfileManagement.Models.Option;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Entities;
using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Context;
using Vendor_ProfileManagement.Mapping;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Vendor_ProfileManagement.Entities.Logger;
using SharedModels.BaseRepository;
using SharedModels.Models.Filter;
namespace Vendor_ProfileManagement.Repositories
{
    public class OptionRepository : BaseRespository<Option, OptionLogger, ProfileManagementContext>, IOptionRepository
    {
        private readonly DbSet<Option> _Set;
        public OptionRepository(ProfileManagementContext context) : base(context, context.Option)
        {
            _Set = context.Option;
        }
        #region CURD
        public async Task<OptionFullDataModel?> GetById(int? id)
        {
            Option? entity = await GetEntityById(id);
            return OptionMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(OptionFullDataModel model)
        {
            Option? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }
        public async Task<PagedList<OptionFullDataModel?>> GetPagedList(ParentPagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.Feature).AsQueryable();
            if (filter.ParentId.HasValue)
            {
                query = query.Where(s => (s.FeatureId == filter.ParentId));
            }
            var pagedList = await PagedList<OptionFullDataModel?>.ToPagedList(query.Select(s => OptionMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => OptionMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => OptionMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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
