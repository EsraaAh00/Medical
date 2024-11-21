using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItemDetailSetting;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemDetailSettingController : ControllerBase
    {
        private readonly IListingItemDetailSettingService _ListingItemDetailSettingService;
        public ListingItemDetailSettingController(IListingItemDetailSettingService ListingItemDetailSettingService)
        {
            _ListingItemDetailSettingService = ListingItemDetailSettingService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ListingItemDetailSettingService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ListingItemDetailSettingFullDataModel model)
        {
            return Ok(await _ListingItemDetailSettingService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ListingItemDetailSettingService.GetPagedList(filter));
        }
        [HttpGet("GetItemSetting")]
        public async Task<ActionResult> GetItemSetting(int? id)
        {
            return Ok(await _ListingItemDetailSettingService.GetItemSetting(id));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _ListingItemDetailSettingService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _ListingItemDetailSettingService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemDetailSettingService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemDetailSettingService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
