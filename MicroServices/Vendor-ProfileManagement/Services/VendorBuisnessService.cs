using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.VendorBusiness;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Enums;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessService : IVendorBusinessService
    {
        private readonly IVendorBusinessRepository _VendorBusinessRepository;
        public VendorBusinessService(IVendorBusinessRepository VendorBusinessRepository)
        {
            _VendorBusinessRepository = VendorBusinessRepository;
        }
        #region CURD
        public async Task<VendorBusinessFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorBusinessFullDataModel? model = await _VendorBusinessRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorBusinessRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorBusinessFullDataModel model)
        {
           BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            if (model.LogoFile != null)
            {
                model.Logo = await UploadFilesHelper.UploadFile(model.LogoFile, "Vendor-ProfileManagement/Logo", model.Logo);
            }
            if (model.CoverFile != null)
            {
                model.Cover = await UploadFilesHelper.UploadFile(model.CoverFile, "Vendor-ProfileManagement/Cover", model.Cover);
            }
            return await _VendorBusinessRepository.Save(model); 
            
        }
        public async Task<BaseResponse?> BusinessStatusSetInactive(int id)
        {
            var model = await _VendorBusinessRepository.GetById(id);
            model.BusinessStatusCode = (int)BusinessStatusEnum.Inactive;
            model.BusinessStatus = BusinessStatusEnum.Inactive.ToString();
            return await _VendorBusinessRepository.Save(model);
        }
        public async Task<PagedList<VendorBusinessFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorBusinessRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _VendorBusinessRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _VendorBusinessRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetBusinessStatusEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(BusinessStatusEnum)).Cast<BusinessStatusEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorBusinessRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
