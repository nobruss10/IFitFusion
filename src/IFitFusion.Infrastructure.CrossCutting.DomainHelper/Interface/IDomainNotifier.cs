namespace IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface
{
    public interface IDomainNotifier
    {
        bool HasNotification();
        List<DomainNotification> GetNotifications();
        void Handle(DomainNotification notification);
    }
}
