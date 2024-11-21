using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ItemCategories;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly IItemCategoriesService _ItemCategoriesService;
        public ItemCategoriesController(IItemCategoriesService ItemCategoriesService)
        {
            _ItemCategoriesService = ItemCategoriesService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ItemCategoriesService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ItemCategoriesFullDataModel model)
        {
            return Ok(await _ItemCategoriesService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ItemCategoriesService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _ItemCategoriesService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _ItemCategoriesService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ItemCategoriesService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ItemCategoriesService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
