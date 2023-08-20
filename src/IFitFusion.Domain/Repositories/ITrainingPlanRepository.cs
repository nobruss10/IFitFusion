using IFitFusion.Domain.Entities;

namespace IFitFusion.Domain.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<TrainingPlan> GetById(int userId, int id);
        Task<IEnumerable<TrainingPlan>> GetAllAsync(int userId);
        Task<IEnumerable<Exercise>> GetExercises();
        Task Add(int userId, TrainingPlan trainingPlan);
        Task AddPlannedExercises(int trainingPlanId, List<PlannedExercise> plannedExercises);
        Task<int> AddPlannedExercise(int trainingPlanId, PlannedExercise plannedExercise);
        Task Delete(TrainingPlan trainingPlan);
    }
}
