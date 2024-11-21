using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorBusinessFacility;
namespace Vendor_ProfileManagement.Interfaces.Repositories
{
    public interface IVendorBusinessFacilityRepository
    {
        #region CURD
        Task<VendorBusinessFacilityFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorBusinessFacilityFullDataModel model);
        Task<PagedList<VendorBusinessFacilityFullDataModel?>> GetPagedList(PagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
