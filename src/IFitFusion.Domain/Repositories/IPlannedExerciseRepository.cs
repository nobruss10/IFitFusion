using IFitFusion.Domain.Entities;

namespace IFitFusion.Domain.Repositories
{
    public interface IPlannedExerciseRepository
    {
        Task Add(List<PlannedExercise> plannedExercises);
        Task<PlannedExercise> GetById(int id, int userId, int trainingPlanId);
        Task DeleteExercise(PlannedExercise plannedExercise, int userId);
    }
}
