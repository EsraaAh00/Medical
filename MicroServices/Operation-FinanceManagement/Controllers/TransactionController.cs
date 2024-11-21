using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Operation_FinanceManagement.Interfaces.Services;
using Operation_FinanceManagement.Models.Transaction;
using SharedModels.Models.Filter;


namespace Operation_FinanceManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Finance/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _TransactionService;
        public TransactionController(ITransactionService TransactionService)
        {
            _TransactionService = TransactionService;
        }

        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _TransactionService.GetById(id));
        }
        [HttpPost("Save")]
        public async Task<ActionResult> Save(TransactionFullDataModel model)
        {
            return Ok(await _TransactionService.Save(model));
        }
        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _TransactionService.GetPagedList(filter));
        }
        #endregion

        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _TransactionService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _TransactionService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
