using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ListingItemPhotos;
namespace Vendor_ListingManagement.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ListingItemPhotosController : ControllerBase
    {


        private readonly IListingItemPhotosService _ListingItemPhotosService;
        public ListingItemPhotosController(IListingItemPhotosService ListingItemPhotosService)
        {
            _ListingItemPhotosService = ListingItemPhotosService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ListingItemPhotosService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] ListingItemPhotosFullDataModel model)
        {
            return Ok(await _ListingItemPhotosService.Save(model));
        }

        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ListingItemPhotosService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ListingItemPhotosService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
