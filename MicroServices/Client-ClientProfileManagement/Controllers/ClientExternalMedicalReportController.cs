using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientExternalMedicalReport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientExternalMedicalReportController : ControllerBase
    {
        private readonly IClientExternalMedicalReportService _ClientExternalMedicalReportService;
        public ClientExternalMedicalReportController(IClientExternalMedicalReportService ClientExternalMedicalReportService)
        {
            _ClientExternalMedicalReportService = ClientExternalMedicalReportService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientExternalMedicalReportService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientExternalMedicalReportFullDataModel model)
        {
            return Ok(await _ClientExternalMedicalReportService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientExternalMedicalReportService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientExternalMedicalReportService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientExternalMedicalReportService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
