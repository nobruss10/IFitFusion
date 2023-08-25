namespace IFitFusion.Service.Api.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            ResponseCode = string.Empty;
        }

        public ResponseModel(string responseCode, string? responseMessage, T? content)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            Result = content;
        }

        public string ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public T? Result { get; set; }
    }
}
