namespace IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface
{
    public interface IDomainNotifier
    {
        bool HasNotification();
        List<DomainNotification> GetNotifications();
        void Handle(DomainNotification notification);
    }
}
