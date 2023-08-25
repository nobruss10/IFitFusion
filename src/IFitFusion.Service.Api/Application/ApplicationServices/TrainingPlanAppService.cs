using IFitFusion.Service.Api.Application.Adapters;
using IFitFusion.Service.Api.ApplicationInterfaces;
using IFitFusion.Service.Api.ApplicationModels.Request;
using IFitFusion.Service.Api.ApplicationModels.Response;
using IFitFusion.Service.Api.Domain.Repositories;
using IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface;
using IFitFusion.Service.Api.Application.ApplicationServices;

namespace IFitFusion.Service.Api.ApplicationApplicationServices
{
    public class TrainingPlanAppService : ApplicationBaseService, ITrainingPlanAppService
    {
        private readonly ITrainingPlanRepository _trainingPlanRepository;
        private readonly IPlannedExerciseRepository _plannedExerciseRepository;

        public TrainingPlanAppService(
            IDomainNotifier domainNotifier,
            ITrainingPlanRepository trainingPlanRepository,
            IPlannedExerciseRepository plannedExerciseRepository) 
            : base(domainNotifier)
        {
            _trainingPlanRepository = trainingPlanRepository;
            _plannedExerciseRepository = plannedExerciseRepository;
        }

        public async Task<IEnumerable<TrainingPlanReponseModel>> GetAll(int userId)
        {
            var result = await _trainingPlanRepository.GetAllAsync(userId);
            return result.ToModel();
        }

        public async Task<IEnumerable<ExerciseResponseModel>> GetAllExercises()
        {
            var result = await _trainingPlanRepository.GetExercises();
            return result.ToModel();
        }

        public async Task Add(int userId, TrainingPlanRequestModel request)
        {
            var trainigPlan = request.ToDomain(userId);
            await _trainingPlanRepository.Add(userId, trainigPlan);
        }

        public async Task AddPlannedExercises(int userId, int trainingPlanId, List<PlannedExerciseRequestModel> plannedExercise)
        {
            var trainingPlan = await _trainingPlanRepository.GetById(userId, trainingPlanId);
            if (trainingPlan is null)
            {
                NotificarErro("Ficha de treino não existe!");
                return;
            }

            await _trainingPlanRepository.AddPlannedExercises(trainingPlanId, plannedExercise.ToDomain());
        }


        public async Task<int> AddPlannedExercise(int userId, int trainingPlanId, PlannedExerciseRequestModel plannedExercise)
        {
            var trainingPlan = await _trainingPlanRepository.GetById(userId, trainingPlanId);
            if (trainingPlan is null)
            {
                NotificarErro("Ficha de treino não existe!");
                return 0;
            }

            return await _trainingPlanRepository.AddPlannedExercise(trainingPlanId, plannedExercise.ToDomain());
        }

        public async Task Delete(int userId, int id)
        {
            var trainigPlan = await _trainingPlanRepository.GetById(userId, id);
            if (trainigPlan is null)
            {
                NotificarErro("Item não foi encontrado no sistema");
                return;
            }

            await _trainingPlanRepository.Delete(trainigPlan);
        }

        public async Task DeletePlanExercise(int userId, int trainingPlanId, int planExerciseId)
        {
            var plannedExercise = await _plannedExerciseRepository.GetById(planExerciseId, userId, trainingPlanId);
            if (plannedExercise is null)
            {
                NotificarErro("Item não foi encontrado no sistema");
                return;
            }
            
            await _plannedExerciseRepository.DeleteExercise(plannedExercise, userId);
        }
    }
}
