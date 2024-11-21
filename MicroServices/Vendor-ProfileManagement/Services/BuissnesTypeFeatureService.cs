using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.BusinessTypeFeature;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class BusinessTypeFeatureService : IBusinessTypeFeatureService
    {
        private readonly IBusinessTypeFeatureRepository _BusinessTypeFeatureRepository;
        public BusinessTypeFeatureService(IBusinessTypeFeatureRepository BusinessTypeFeatureRepository)
        {
            _BusinessTypeFeatureRepository = BusinessTypeFeatureRepository;
        }
        #region CURD
        public async Task<BusinessTypeFeatureFullDataModel?> GetById(int? id)
        {
            return await _BusinessTypeFeatureRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            BusinessTypeFeatureFullDataModel? model = await _BusinessTypeFeatureRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _BusinessTypeFeatureRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(BusinessTypeFeatureFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _BusinessTypeFeatureRepository.Save(model); 
        }
        public async Task<PagedList<BusinessTypeFeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _BusinessTypeFeatureRepository.GetPagedList(filter);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _BusinessTypeFeatureRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _BusinessTypeFeatureRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
