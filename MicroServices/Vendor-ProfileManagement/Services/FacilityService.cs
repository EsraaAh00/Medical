using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.Facility;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _FacilityRepository;
        public FacilityService(IFacilityRepository FacilityRepository)
        {
            _FacilityRepository = FacilityRepository;
        }
        #region CURD
        public async Task<FacilityFullDataModel?> GetById(int? id)
        {
            return await _FacilityRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            FacilityFullDataModel? model = await _FacilityRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _FacilityRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(FacilityFullDataModel model)
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
            return await _FacilityRepository.Save(model);
        }
        public async Task<PagedList<FacilityFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _FacilityRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _FacilityRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _FacilityRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
