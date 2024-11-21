using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItemsTax;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemsTaxController : ControllerBase
    {
        private readonly IListingItemsTaxService _ListingItemsTaxService;
        public ListingItemsTaxController(IListingItemsTaxService ListingItemsTaxService)
        {
            _ListingItemsTaxService = ListingItemsTaxService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ListingItemsTaxService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ListingItemsTaxFullDataModel model)
        {
            return Ok(await _ListingItemsTaxService.Save(model));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemsTaxService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemsTaxService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
