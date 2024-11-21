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
namespace Vendor_ProfileManagement.Services
{
    public class VendorBusinessAreaAttractionService : IVendorBusinessAreaAttractionService
    {
        private readonly IVendorBusinessAreaAttractionRepository _VendorBusinessAreaAttractionRepository;
        public VendorBusinessAreaAttractionService(IVendorBusinessAreaAttractionRepository VendorBusinessAreaAttractionRepository)
        {
            _VendorBusinessAreaAttractionRepository = VendorBusinessAreaAttractionRepository;
        }
        #region CURD
        public async Task<VendorBusinessAreaAttractionFullDataModel?> GetById(int? id)
        {
            return await _VendorBusinessAreaAttractionRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            VendorBusinessAreaAttractionFullDataModel? model = await _VendorBusinessAreaAttractionRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _VendorBusinessAreaAttractionRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(VendorBusinessAreaAttractionFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            if (model.ImageFile != null)
            {
                model.Image = await UploadFilesHelper.UploadFile(model.ImageFile, "Vendor-ProfileManagement/Image", model.Image);
            }
            return await _VendorBusinessAreaAttractionRepository.Save(model);

        }
        public async Task<PagedList<VendorBusinessAreaAttractionFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _VendorBusinessAreaAttractionRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _VendorBusinessAreaAttractionRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _VendorBusinessAreaAttractionRepository.GetIncludeByIdsList(ids);
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
            return await _VendorBusinessAreaAttractionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _VendorBusinessAreaAttractionRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
