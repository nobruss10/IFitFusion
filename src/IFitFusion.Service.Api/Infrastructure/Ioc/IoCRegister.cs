using IFitFusion.Service.Api.Domain.Repositories;
using IFitFusion.Service.Api.ApplicationApplicationServices;
using IFitFusion.Service.Api.ApplicationInterfaces;
using IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface;
using IFitFusion.Service.Api.Infrastructure.Data.Repositories;

namespace IFitFusion.Service.Api.Infrastructure.Ioc
{
    public static class IoCRegister
    {
        public static IServiceCollection AddDependenciesExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            RegisterRepository(services);
            RegisterInfrastructure(services, configuration);
            RegisterAppServices(services);

            return services;
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
            services.AddScoped<IPlannedExerciseRepository, PlannedExerciseRepository>();
        }

        private static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITrainingPlanAppService, TrainingPlanAppService>();
        }

        private static void RegisterInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomainNotifier, DomainNotifier>();
        }
    }
}
