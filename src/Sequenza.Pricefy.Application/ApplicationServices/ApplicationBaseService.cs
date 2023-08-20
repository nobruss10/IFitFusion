﻿using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface;

namespace IFitFusion.Application.ApplicationServices
{
    public class ApplicationBaseService
    {
        private readonly IDomainNotifier _domainNotifier;
        public ApplicationBaseService(
            IDomainNotifier domainNotifier)
        {
            _domainNotifier = domainNotifier;
        }

        protected void NotificarErro(string errorMsg)
            => _domainNotifier.Handle(new DomainNotification(errorMsg));
        

        protected bool HasNotification()
            => _domainNotifier.HasNotification();
    }
}
