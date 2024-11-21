using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientTherapyProgram;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientTherapyProgramController : ControllerBase
    {
        private readonly IClientTherapyProgramService _ClientTherapyProgramService;
        public ClientTherapyProgramController(IClientTherapyProgramService ClientTherapyProgramService)
        {
            _ClientTherapyProgramService = ClientTherapyProgramService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientTherapyProgramService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientTherapyProgramFullDataModel model)
        {
            return Ok(await _ClientTherapyProgramService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientTherapyProgramService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientTherapyProgramService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientTherapyProgramService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
