using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusinessAreaAttraction;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Enums;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
using Vendor_ProfileManagement.Models.BusinessAffiliationInfo;

namespace Vendor_ProfileManagement.Services
{
    public class BusinessAffiliationInfoService : IBusinessAffiliationInfoService
    {
        private readonly IBusinessAffiliationInfoRepository _BusinessAffiliationInfoRepository;
        public BusinessAffiliationInfoService(IBusinessAffiliationInfoRepository BusinessAffiliationInfoRepository)
        {
            _BusinessAffiliationInfoRepository = BusinessAffiliationInfoRepository;
        }
        #region CURD
        public async Task<BusinessAffiliationInfoFullDataModel?> GetById(int? id)
        {
            return await _BusinessAffiliationInfoRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            BusinessAffiliationInfoFullDataModel? model = await _BusinessAffiliationInfoRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _BusinessAffiliationInfoRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(BusinessAffiliationInfoFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            if (model.AwardPhotoFile != null)
            {
                model.AwardPhoto = await UploadFilesHelper.UploadFile(model.AwardPhotoFile, "Vendor-ProfileManagement/Image", model.AwardPhoto);
            }
            return await _BusinessAffiliationInfoRepository.Save(model);

        }
        public async Task<PagedList<BusinessAffiliationInfoFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _BusinessAffiliationInfoRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _BusinessAffiliationInfoRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _BusinessAffiliationInfoRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetDistanceUnitEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(DistanceUnitEnum)).Cast<DistanceUnitEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _BusinessAffiliationInfoRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _BusinessAffiliationInfoRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
