using IFitFusion.Service.Api.ApplicationModels.Request;
using IFitFusion.Service.Api.ApplicationModels.Response;

namespace IFitFusion.Service.Api.ApplicationInterfaces
{
    public interface ITrainingPlanAppService
    {
        Task<IEnumerable<TrainingPlanReponseModel>> GetAll(int userId);
        Task<IEnumerable<ExerciseResponseModel>> GetAllExercises();
        Task Add(int userId, TrainingPlanRequestModel request);
        Task AddPlannedExercises(int userId, int trainingPlanId, List<PlannedExerciseRequestModel> exercise);
        Task<int> AddPlannedExercise(int userId, int trainingPlanId, PlannedExerciseRequestModel exercise);
        Task Delete(int userId, int id);
        Task DeletePlanExercise(int userId, int trainingPlanId, int planExerciseId);
    }
}
