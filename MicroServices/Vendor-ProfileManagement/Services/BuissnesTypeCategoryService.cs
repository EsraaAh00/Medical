using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.BusinessTypeCategory;
using SharedModels.Models.Filter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using Vendor_ProfileManagement.Validation;

namespace Vendor_ProfileManagement.Services
{
    public class BusinessTypeCategoryService : IBusinessTypeCategoryService
    {
        private readonly IBusinessTypeCategoryRepository _BusinessTypeCategoryRepository;
        public BusinessTypeCategoryService(IBusinessTypeCategoryRepository BusinessTypeCategoryRepository)
        {
            _BusinessTypeCategoryRepository = BusinessTypeCategoryRepository;
        }
        #region CURD
        public async Task<BusinessTypeCategoryFullDataModel?> GetById(int? id)
        {
            return await _BusinessTypeCategoryRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            BusinessTypeCategoryFullDataModel? model = await _BusinessTypeCategoryRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _BusinessTypeCategoryRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(BusinessTypeCategoryFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _BusinessTypeCategoryRepository.Save(model);
           
        }

        public async Task<PagedList<BusinessTypeCategoryFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _BusinessTypeCategoryRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList(int ?BusinessTypeId)
        {
            return await _BusinessTypeCategoryRepository.GetDropDownList(BusinessTypeId);
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _BusinessTypeCategoryRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _BusinessTypeCategoryRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _BusinessTypeCategoryRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
