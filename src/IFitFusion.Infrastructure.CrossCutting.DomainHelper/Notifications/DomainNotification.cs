namespace IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface
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
