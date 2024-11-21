using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Models;
using Vendor_ListingManagement.Models.ListingItemsTax;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.Enums;
namespace Vendor_ListingManagement.Services
{
    public class ListingItemsTaxService : IListingItemsTaxService
    {
        private readonly IListingItemsTaxRepository _ListingItemsTaxRepository;
        public ListingItemsTaxService(IListingItemsTaxRepository ListingItemsTaxRepository)
        {
            _ListingItemsTaxRepository = ListingItemsTaxRepository;
        }
        #region CURD
        public async Task<ListingItemsTaxFullDataModel?> GetById(int? id)
        {
            return await _ListingItemsTaxRepository.GetById(id);
        }
        public async Task<BaseResponse?> Save(ListingItemsTaxFullDataModel model)
        {
            return await _ListingItemsTaxRepository.Save(model); ;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _ListingItemsTaxRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ListingItemsTaxRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
