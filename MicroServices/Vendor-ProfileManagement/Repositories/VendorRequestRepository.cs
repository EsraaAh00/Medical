using Vendor_ProfileManagement.Models.VendorRequest;
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
using Vendor_ProfileManagement.MessageBrokerServices;
namespace Vendor_ProfileManagement.Repositories
{
    public class VendorRequestRepository : BaseRespository<VendorRequest, VendorRequestLogger, ProfileManagementContext>, IVendorRequestRepository
    {
        private readonly DbSet<VendorRequest> _Set;


        public VendorRequestRepository(ProfileManagementContext context ) : base(context, context.VendorRequest)
        {
            _Set = context.VendorRequest;
        }
        #region CURD
        public async Task<VendorRequestFullDataModel?> GetById(int? id)
        {
            VendorRequest? entity = await GetEntityById(id);
            return VendorRequestMapping.EntityToFullDataModel(entity);
        }
        public async Task<VendorRequestFullDataModel?> GetByName(string? name)
        {
            VendorRequest? entity = await _set.AsNoTracking().FirstOrDefaultAsync(s => s.Name == name);
            return VendorRequestMapping.EntityToFullDataModel(entity);
        }
        public async Task<VendorRequestFullDataModel?> GetByNameLocalized(string? name)
        {
            VendorRequest? entity = await _set.AsNoTracking().FirstOrDefaultAsync(s => s.NameLocalized == name);
            return VendorRequestMapping.EntityToFullDataModel(entity);
        }
        public async Task<BaseResponse?> Save(VendorRequestFullDataModel model)
        {
            VendorRequest? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            var issaved = await SaveAsync(entityWithLog);
            if(issaved?.IsError == false)
            {
                var requestid = _context.VendorRequest.Where(r => r.Phone == model.Phone).Select(r => r.Id).FirstOrDefault();
                var gettoken = await MessageBrokerService.GetGuestToken(requestid);
                if(gettoken?.IsError == false)
                {
                    var token = gettoken.ReturnedValue.ToString();
                    string emailBody = $"Please check your registration status using the following link: https://example.com/check-registration?token={Uri.EscapeDataString(token)}";
                    var sendtoken = await EmailHelper.SendEmail(model.Email, "Vendor Registration Status", emailBody);
                    if(sendtoken.IsError == false)
                    {
                        return issaved;
                    }
                    return new BaseResponse { IsError = true ,  Message = "Failed to Send Token Email" };
                }
                return new BaseResponse { IsError = true , Message = "No Token Returned" };
            }
            return new BaseResponse { IsError = true, Message = "Failed to Save The Request" };
        }
        public async Task<PagedList<VendorRequestFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().Include(s => s.BusinessTypeCategory).AsQueryable();
            if (!filter.Name.IsNullOrEmpty())
            {
                query = query.Where(s => s.Name.Contains(filter.Name ?? "") || s.NameLocalized.Contains(filter.Name ?? ""));
            }
            var pagedList = await PagedList<VendorRequestFullDataModel?>.ToPagedList(query.Select(s => VendorRequestMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            List<BaseDropDown>? dropDownList = await _Set.AsNoTracking().Where(s => s.IsDeleted != true).Select(s => VendorRequestMapping.EntityToDropDownModel(s)).ToListAsync();
            return dropDownList;
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            List<OuterIncludeModel>? list = await _Set.AsNoTracking().Where(s => s.IsDeleted != true && ids.Contains(s.Id)).Select(s => VendorRequestMapping.EntityToOuterIncludeModel(s)).ToListAsync();
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