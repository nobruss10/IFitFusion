namespace IFitFusion.Service.Api.Exceptions
{
    public class AppException : Exception
    {
        public int Code { get; set; }

        public AppException() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, Exception innerException) : base(message, innerException) { }
        public AppException(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}
    