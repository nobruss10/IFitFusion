namespace IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface
{
    public class DomainNotification
    {
        public DomainNotification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
