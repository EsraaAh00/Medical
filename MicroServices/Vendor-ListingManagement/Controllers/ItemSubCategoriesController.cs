using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Models.ItemSubCategories;
using SharedModels.Models.Filter;
namespace Vendor_ListingManagement.Controllers
{
    [ApiController]
    [Route("Vendor/[controller]")]
    public class ItemSubCategoriesController : ControllerBase
    {
        private readonly IItemSubCategoriesService _ItemSubCategoriesService;
        public ItemSubCategoriesController(IItemSubCategoriesService ItemSubCategoriesService)
        {
            _ItemSubCategoriesService = ItemSubCategoriesService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ItemSubCategoriesService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(ItemSubCategoriesFullDataModel model)
        {
            return Ok(await _ItemSubCategoriesService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ItemSubCategoriesService.GetPagedList(filter));
        }
        [HttpGet("GetDropDownList")]
        public async Task<ActionResult> GetDropDownList()
        {
            return Ok(await _ItemSubCategoriesService.GetDropDownList());
        }
        [HttpGet("GetIncludeByIdsList")]
        public async Task<ActionResult> GetIncludeByIdsList(List<int> ids)
        {
            return Ok(await _ItemSubCategoriesService.GetIncludeByIdsList(ids));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ItemSubCategoriesService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ItemSubCategoriesService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
