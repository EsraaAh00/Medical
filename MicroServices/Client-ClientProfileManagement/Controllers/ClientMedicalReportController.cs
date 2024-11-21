using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientMedicalReport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientMedicalReportController : ControllerBase
    {
        private readonly IClientMedicalReportService _ClientMedicalReportService;
        public ClientMedicalReportController(IClientMedicalReportService ClientMedicalReportService)
        {
            _ClientMedicalReportService = ClientMedicalReportService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientMedicalReportService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientMedicalReportFullDataModel model)
        {
            return Ok(await _ClientMedicalReportService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientMedicalReportService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientMedicalReportService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientMedicalReportService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
