using IFitFusion.Application.Models.Request;
using IFitFusion.Application.Models.Response;

namespace IFitFusion.Application.Interfaces
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
