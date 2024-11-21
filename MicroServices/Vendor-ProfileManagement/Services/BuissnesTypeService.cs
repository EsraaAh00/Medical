using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.BusinessType;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class BusinessTypeService : IBusinessTypeService
    {
        private readonly IBusinessTypeRepository _BusinessTypeRepository;
        public BusinessTypeService(IBusinessTypeRepository BusinessTypeRepository)
        {
            _BusinessTypeRepository = BusinessTypeRepository;
        }
         #region CURD
        public async Task<BusinessTypeFullDataModel?> GetById(int? id)
        {
            return await _BusinessTypeRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(BusinessTypeFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _BusinessTypeRepository.Save(model);
        }
        public async Task<PagedList<BusinessTypeFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _BusinessTypeRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _BusinessTypeRepository.GetDropDownList();
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            BusinessTypeFullDataModel? model = await _BusinessTypeRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _BusinessTypeRepository.Save(model);
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _BusinessTypeRepository.GetIncludeByIdsList(ids);
        }
        #endregion 
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _BusinessTypeRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _BusinessTypeRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
