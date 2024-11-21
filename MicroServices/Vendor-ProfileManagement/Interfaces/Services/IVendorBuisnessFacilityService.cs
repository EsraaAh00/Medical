using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorBusinessFacilityService
    {
        #region CURD
        Task<VendorBusinessFacilityFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessFacilityFullDataModel model);
        Task<BaseResponse?> DeleteAndActivate(int? id);
        Task<PagedList<VendorBusinessFacilityFullDataModel?>> GetPagedList(PagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
