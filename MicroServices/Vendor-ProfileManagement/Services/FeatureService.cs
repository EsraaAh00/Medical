using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.Feature;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _FeatureRepository;
        public FeatureService(IFeatureRepository FeatureRepository)
        {
            _FeatureRepository = FeatureRepository;
        }
        #region CURD
        public async Task<FeatureFullDataModel?> GetById(int? id)
        {
            return await _FeatureRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            FeatureFullDataModel? model = await _FeatureRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _FeatureRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(FeatureFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            if (model.IconFile != null)
            {
                model.Icon = await UploadFilesHelper.UploadFile(model.IconFile, "Vendor-ProfileManagement/Icon", model.Icon);
            }
            return await _FeatureRepository.Save(model);      
        }
        public async Task<PagedList<FeatureFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _FeatureRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _FeatureRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _FeatureRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FeatureRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FeatureRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
