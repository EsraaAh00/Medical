using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItemDetail;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemDetailController : ControllerBase
    {
        private readonly IListingItemDetailService _ListingItemDetailService;
        public ListingItemDetailController(IListingItemDetailService ListingItemDetailService)
        {
            _ListingItemDetailService = ListingItemDetailService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ListingItemDetailService.GetById(id));
        }
        [HttpPost("Save")]
    //    public async Task<ActionResult> Save(ListingItemDetailFullDataModel model)
      //  {
      //      return Ok(await _ListingItemDetailService.Save(model));
     //   }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(PagedFilterModel filter)
        {
            return Ok(await _ListingItemDetailService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemDetailService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemDetailService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
