using IFitFusion.Infrastructure.Data.Repositories;
using IFitFusion.Application.ApplicationServices;
using IFitFusion.Application.Interfaces;
using IFitFusion.Domain.Repositories;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IFitFusion.Infrastructure.CrossCutting.IoC
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
