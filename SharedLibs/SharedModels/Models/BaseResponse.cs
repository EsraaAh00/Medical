namespace SharedModels.Models
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            IsError = false;
            Message = "";
            Errors = new List<ReposneError>() ;

        }
        public bool IsError { set; get; }
        public string Message { set; get; }
        public int? TargetId { set; get; } = 0;
        public object ReturnedValue { get; set; } = 0;
        public List<ReposneError> Errors { set; get; }



    }
}
