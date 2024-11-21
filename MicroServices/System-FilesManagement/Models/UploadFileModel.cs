namespace System_FilesManagement.Models
{
    public class UploadFileModel
    {
        public IFormFile? FormFile { set; get; }
        public string? DirPath { set; get; }
        public string? OldFilePath { set; get; }
    }
}
