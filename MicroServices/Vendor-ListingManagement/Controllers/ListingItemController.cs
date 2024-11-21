using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItem;
using SharedModels.Models.Filter;
using Vendor_ListingManagement.RefModels;

namespace Vendor_ListingManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemController : ControllerBase
    {
        private readonly IListingItemService _ListingItemService;
        public ListingItemController(IListingItemService ListingItemService)
        {
            _ListingItemService = ListingItemService;
        }
        #region CURD
        [HttpGet("GetFormByItemId")]
        public async Task<ActionResult> GetFormByItemId(int? id, int vendorBuissnesId)
        {
            return Ok(await _ListingItemService.GetFormByItemId(id, vendorBuissnesId));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ListingItemFullDataModel model)
        {
            return Ok(await _ListingItemService.Save(model));
        }
        [HttpGet("StateSetItemDeactivate")]
        public async Task<ActionResult> StateSetItemDeactivate(int id)
        {
            return Ok(await _ListingItemService.StateSetItemDeactivate(id));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ListingItemService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _ListingItemService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _ListingItemService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
