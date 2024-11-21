using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using Client_ClientProfileManagement.Models.ClientMedicalProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models.Filter;

namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientMedicalProfileController : ControllerBase
    {
        private readonly IClientMedicalProfileService _ClientMedicalProfileService;
        public ClientMedicalProfileController(IClientMedicalProfileService ClientMedicalProfileService)
        {
            _ClientMedicalProfileService = ClientMedicalProfileService;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientMedicalProfileService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save(ClientMedicalProfileFullDataModel model)
        {
            return Ok(await _ClientMedicalProfileService.Save(model));
        }

        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientMedicalProfileService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientMedicalProfileService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientMedicalProfileService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
