using Microsoft.AspNetCore.Mvc;
using System_FilesManagement.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using SharedModels.Models;

namespace System_FilesManagement.Controllers
{
    [ApiController]
    [Route("System/[controller]")]
    public class FilesController : ControllerBase
    {
        public FilesController(){}

        //[HttpPost("Upload")]
        //public async Task<ActionResult> Upload([FromForm] UploadFileModel model)
        //{
        //    var file = model.FormFile;

        //    var folderName = Path.Combine("wwwroot");
        //    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //    if (!Directory.Exists(pathToSave))
        //    {
        //        Directory.CreateDirectory(pathToSave);
        //    }
        //    pathToSave = Path.Combine(pathToSave, model?.DirPath??"");
        //    if (!Directory.Exists(pathToSave))
        //    {
        //        Directory.CreateDirectory(pathToSave);
        //    }
        //    if (file?.Length > 0)
        //    {
        //        var fileName = $"{DateTime.Now.Ticks}{ContentDispositionHeaderValue.Parse(file?.ContentDisposition ?? "")?.FileName?.Trim('"')}";
        //        var fullPath = Path.Combine(pathToSave, fileName);
        //        var dbPath = Path.Combine(folderName, fileName);

        //        using (var stream = new FileStream(fullPath, FileMode.Create))
        //        {
        //            await file?.CopyToAsync(stream);
        //        }
        //        if (!string.IsNullOrEmpty(model?.OldFilePath)) {
        //            DeleteBody(model.OldFilePath);
        //        }

        //        BaseResponse res =  new BaseResponse();

        //        res.IsError = false;
        //        res.ReturnedValue = model?.DirPath + "/" + fileName;

        //        return Ok(res);
        //    }
        //    return Ok("");
        //}


        [HttpPost("Upload")]
        public async Task<ActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            // تحديد مسار الحفظ
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // إرجاع رابط الملف
            var fileUrl = $"/uploads/{fileName}";
            return Ok(new { FilePath = fileUrl });
        }

        [HttpPost("Move")]
        public ActionResult Move([FromForm] MoveFileModel model)
        {
            var folderName = Path.Combine("wwwroot");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var sourcePath = Path.Combine(pathToSave, model.SourcePath ?? "");
            var destPath = Path.Combine(pathToSave, model.DestinationPath ?? "");

            if (!System.IO.File.Exists(sourcePath))
            {
                return NotFound("Source file not found.");
            }

            var destDir = Path.GetDirectoryName(destPath);
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            System.IO.File.Move(sourcePath, destPath);

            return Ok("");
        }


    [HttpGet("Delete")]
        public async Task<ActionResult> Delete(string ?filePath)
        {
            DeleteBody(filePath);
            return Ok("");
        }
        private string DeleteBody(string? filePath) {
            var folderName = Path.Combine("wwwroot");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var ImageFullPath = Path.Combine(pathToSave, filePath ?? "");
            System.IO.File.Delete(ImageFullPath);
            return "";
        }


    }
}
