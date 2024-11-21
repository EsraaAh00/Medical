using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SharedModels.Helpers
{
    public class UploadFilesHelper
    {

        public async static Task<string> UploadFile(IFormFile? formFile, string DirPath, string? OldFilePath)
        {
            string Seshat_URL = BaseHttpContext.path + "/System/Files/Upload";


            var formData = new MultipartFormDataContent();

            // Add form fields
            formData.Add(new StringContent(DirPath), "DirPath");
            formData.Add(new StringContent(OldFilePath??""), "OldFilePath");

            // Add file
            byte[] ff = { };
            if (formFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    ff = ms.ToArray();
                }
            }

            var fileContent = new ByteArrayContent(ff);
            formData.Add(fileContent, "FormFile", formFile.FileName);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer",AuthenticationHelper.GetToken());
            var response = await client.PostAsync(Seshat_URL, formData);
            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;

        }
        public static string DeleteFile( string DirPath,string ImagePath)
        {
            var folderName = Path.Combine("wwwroot");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            pathToSave = Path.Combine(pathToSave, DirPath);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            System.IO.File.Delete(@ImagePath);
            return "";
        }
        public static string DeleteFile( string ImagePath)
        {
            var folderName = Path.Combine("wwwroot");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var ImageFullPath = Path.Combine(pathToSave, ImagePath); 
            System.IO.File.Delete(ImageFullPath);
            return "";
        }
    }
}
