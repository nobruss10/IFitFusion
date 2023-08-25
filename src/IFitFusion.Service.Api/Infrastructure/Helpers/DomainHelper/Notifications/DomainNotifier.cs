namespace IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface
{
    public class DomainNotifier : IDomainNotifier
    {
        private List<DomainNotification> _notificacoes;

        public DomainNotifier()
        {
            _notificacoes = new List<DomainNotification>();
        }

        public void Handle(DomainNotification notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notificacoes;
        }

        public bool HasNotification()
        {
            return _notificacoes.Any();
        }
    }
}
