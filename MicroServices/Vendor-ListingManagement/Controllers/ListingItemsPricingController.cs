using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItemsPricing;
using SharedModels.Helpers;
using Vendor_ListingManagement.Models;
using SharedModels.Models;
namespace Vendor_ListingManagement.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemsPricingController : ControllerBase
    {
        private readonly IListingItemsPricingService _ListingItemsPricingService;
        public ListingItemsPricingController(IListingItemsPricingService ListingItemsPricingService)
        {
            _ListingItemsPricingService = ListingItemsPricingService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ListingItemsPricingService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ListingItemsPricingFullDataModel model)
        {
            return Ok(await _ListingItemsPricingService.Save(model));
        }

        [HttpPost("GetPagedList")]
       public async Task<ActionResult> GetPagedList(ListingItemsPricingFilter filter)
      {
         return Ok(await _ListingItemsPricingService.GetPagedList(filter));
       }


      
    /*[HttpGet("GetPricingStateEnumDropDownList")]
    public ActionResult GetPricingStateEnumDropDownList()
    {
        return Ok(_ListingItemsPricingService.GetPricingStateEnumDropDownList());
    }*/
    [HttpGet("GetChargeFrequencyEnumDropDownList")]
        public ActionResult GetChargeFrequencyEnumDropDownList()
        {
            return Ok(_ListingItemsPricingService.GetChargeFrequencyEnumDropDownList());
        }
        [HttpGet("GetApplicableTypeEnumDropDownList")]
        public ActionResult GetApplicableTypeEnumDropDownList()
        {
            return Ok(_ListingItemsPricingService.GetApplicableTypeEnumDropDownList());
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemsPricingService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemsPricingService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
