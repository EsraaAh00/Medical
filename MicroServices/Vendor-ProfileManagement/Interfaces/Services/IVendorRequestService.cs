using Vendor_ProfileManagement.Models;
using SharedModels.Models;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Models.VendorRequest;
using Microsoft.AspNetCore.Mvc;

namespace Vendor_ProfileManagement.Interfaces.Services
{
    public interface IVendorRequestService
    {
        #region CURD
        Task<VendorRequestFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(VendorRequestFullDataModel model);
        Task<BaseResponse?> AccountSetup(VendorAccountDataModel model);
        Task<BaseResponse?> BusinessIdentifiaction(BusinessIdentifiactionModel model);
        Task<BaseResponse?> RequestSetRejected(RejectionModel rejection);
        Task<BaseResponse?> RequestSetAccepted(int id);
        Task<BaseResponse?> VendorBusinessLocation(VendorBusinessLocationModel model);
        Task<BaseResponse?> VendorRequestDocumentation(VendorRequestDocumentationModel model);
        Task<PagedList<VendorRequestFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        Task<List<BaseDropDown>?> GetDropDownList();
        Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids);
        List<BaseDropDown>? GetRequestStatusEnumDropDownList();
        List<BaseDropDown>? GetRejectionReasonDropDownList();
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}