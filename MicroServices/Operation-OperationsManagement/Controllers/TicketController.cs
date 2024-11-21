using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Operation_OperationsManagement.Interfaces.Services;
using SharedModels.Models.Filter;
using Operation_OperationsManagement.Models.Ticket;
namespace Operation_OperationsManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Operation/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _TicketService;
        public TicketController(ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _TicketService.GetById(id));
        }

        [HttpPost("GetListByProviderId")]
        public async Task<ActionResult> GetListByProviderId(int id, int State)
        {
            return Ok(await _TicketService.GetListByProviderId(id,State));
        }

        [HttpPost("GetListByClientId")]
        public async Task<ActionResult> GetListByClientId(int id, int State)
        {
            return Ok(await _TicketService.GetListByClientId(id, State));
        }

        [HttpPost("TicketSetRejected")]
        public async Task<ActionResult> TicketSetRejected(int id)
        {
            return Ok(await _TicketService.TicketSetRejected(id));
        }

        [HttpPost("TicketSetAccepted")]
        public async Task<ActionResult> TicketSetAccepted(int id)
        {
            return Ok(await _TicketService.TicketSetAccepted(id));
        }


        [HttpPost("Save")]
        public async Task<ActionResult> Save(TicketFullDataModel model)
        {
            return Ok(await _TicketService.Save(model));
        }


        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _TicketService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _TicketService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
