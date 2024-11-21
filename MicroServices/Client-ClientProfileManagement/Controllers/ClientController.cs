using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SharedModels.Models.Filter;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Models.Client;
using SharedModels.Helpers;
using System.Net.Http.Headers;
using System.Net.Http;
using Client_ClientProfileManagement.Models.Settings;
namespace Client_ClientProfileManagement.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("Client/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _ClientService;
        private readonly HttpClient _httpClient;
        public ClientController(IClientService ClientService, HttpClient httpClient)
        {
            _ClientService = ClientService;
            _httpClient = httpClient;
        }
        #region CURD
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int? id)
        {
            return Ok(await _ClientService.GetById(id));
        }

        [HttpPost("Save")]
        public async Task<ActionResult> Save([FromForm] ClientFullDataModel model/*, IFormFile? image*/)
        {


            if (model.Image != null)
            {
                // Ensure the file content is valid before making HTTP calls
                if (model.Image.Length > 0)
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var form = new MultipartFormDataContent())
                        {
                            // Add the image file to the form content
                            //var streamContent = new StreamContent(model.Image.OpenReadStream());
                            //streamContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);
                            //form.Add(streamContent, "file", model.Image.FileName);

                            //UploadFileModel modelFile = new UploadFileModel();
                            //modelFile.FormFile = model.Image;

                            // Make the HTTP call to the Upload endpoint in the other microservice
                            var response = await BaseHttpContext.PostObjectReturnBaseResponse("System/Files/Upload", model.Image);

                            if (!response.IsError)
                            {
                                string? path = response.ReturnedValue?.ToString();
                                model.ProfilePhoto = path; // Save the returned path in the model
                            }
                            else
                            {
                                return StatusCode(400, "Error uploading the image.");
                            }
                        }
                    }
                }
                else
                {
                    return BadRequest("The uploaded file is empty.");
                }
            }
            return Ok(await _ClientService.Save(model));
   
        }
            //var saveResult = await _ClientService.Save(model);
            //if (saveResult != null)
            //{
            //    return Ok(saveResult);
            //}
            //else
            //{
            //    return StatusCode(500, "An error occurred while saving the client data.");
            //}

            //if (model.Image != null)
            //{
            //    using (var httpClient = new HttpClient())
            //    {
            //        // Set up the HTTP content to send the image
            //        using (var form = new MultipartFormDataContent())
            //        {
            //            // Make the HTTP call to the Upload endpoint in the other microservice
            //            var response = await BaseHttpContext.PostObjectReturnBaseResponse("/System/Files/Upload", model.Image);

            //            if (response.IsError == false)
            //            {
            //                string? path = response.ReturnedValue.ToString();
            //                model.ProfilePhoto = path; // Save the returned path in the model
            //            }
            //            else
            //            {
            //                return StatusCode(400);
            //            }
            //        }
            //    }
            //}
            //return Ok(await _ClientService.Save(model));


        [HttpPost("GetPagedList")]
        public async Task<ActionResult> GetPagedList(NamePagedFilterModel filter)
        {
            return Ok(await _ClientService.GetPagedList(filter));
        }
        #endregion
        #region Logger
        [HttpGet("Undo")]
        public async Task<ActionResult> Undo(int? recordId, int? transactionId)
        {
            return Ok(await _ClientService.Undo(recordId, transactionId));
        }
        [HttpGet("GetRecordLogger")]
        public async Task<ActionResult> GetRecordLogger(int? recordId)
        {
            return Ok(await _ClientService.GetRecordLogger(recordId));
        }
        #endregion
    }
}
