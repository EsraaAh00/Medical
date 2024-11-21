using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.Vendor;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Enums;
namespace Vendor_ProfileManagement.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _VendorRepository;
        public VendorService(IVendorRepository VendorRepository)
        {
            _VendorRepository = VendorRepository;
        }
        #region CURD
        public async Task<VendorFullDataModel?> GetById(int? id)
        {
            return await _VendorRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorFullDataModel? model = await _VendorRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorFullDataModel model)
        {
            if (model.LogoFile != null)
            {
                model.Logo = await UploadFilesHelper.UploadFile(model.LogoFile, "Vendor-ProfileManagement/Logo", model.Logo);
            }
            if (model.CoverFile != null)
            {
                model.Cover = await UploadFilesHelper.UploadFile(model.CoverFile, "Vendor-ProfileManagement/Cover", model.Cover);
            }
            if (model.ManagerNationalIdFrontFile != null)
            {
                model.ManagerNationalIdFront = await UploadFilesHelper.UploadFile(model.ManagerNationalIdFrontFile, "Vendor-ProfileManagement/ManagerNationalIdFront", model.ManagerNationalIdFront);
            }
            if (model.ManagerNationalIdBackFile != null)
            {
                model.ManagerNationalIdBack = await UploadFilesHelper.UploadFile(model.ManagerNationalIdBackFile, "Vendor-ProfileManagement/ManagerNationalIdBack", model.ManagerNationalIdBack);
            }
            return await _VendorRepository.Save(model); ;
        }
        public async Task<BaseResponse?> StateSetInactive(int id)
        {
            var model = await _VendorRepository.GetById(id);
            model.StateCode = (int)StateEnum.Inactive;
            model.State = StateEnum.Inactive.ToString();
            return await _VendorRepository.Save(model);
        }
        public async Task<BaseResponse?> StateSetBlocked(int id)
        {
            var model = await _VendorRepository.GetById(id);
            model.StateCode = (int)StateEnum.Blocked;
            model.State = StateEnum.Blocked.ToString();
            return await _VendorRepository.Save(model);
        }
        public async Task<PagedList<VendorFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _VendorRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _VendorRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetStateEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(StateEnum)).Cast<StateEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _VendorRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
