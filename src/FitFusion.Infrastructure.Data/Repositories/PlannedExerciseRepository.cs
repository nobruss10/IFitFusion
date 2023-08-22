using IFitFusion.Infrastructure.Data.Queries;
using IFitFusion.Domain.Entities;
using IFitFusion.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace IFitFusion.Infrastructure.Data.Repositories
{
    public class PlannedExerciseRepository : BaseRepository, IPlannedExerciseRepository
    {
        public PlannedExerciseRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlannedExercise> GetById(int id, int userId, int trainingPlanId)
        {
            var parametersList = new List<dynamic>();
            return await QueryFirstOrDefaultAsync<PlannedExercise>(PlannedExerciseQuery.GetById, new { id, userId, trainingPlanId });
        }

        public async Task Add(List<PlannedExercise> plannedExercises)
        {
            var parametersList = new List<dynamic>();
            foreach (var item in plannedExercises)
            {
                parametersList.Add(new
                {
                    item.TrainingPlanId,
                    item.ExerciseId,
                    item.Sets,
                    item.Repetitions,
                    item.Weight
                });
            }

            await ExecuteAsync(PlannedExerciseQuery.Insert, parametersList);
        }
        public async Task DeleteExercise(PlannedExercise plannedExercise, int userId)
        {
            var parametersList = new List<dynamic>();
            await ExecuteAsync(PlannedExerciseQuery.Delete, new { plannedExercise.Id, userId, plannedExercise.TrainingPlanId });
        }
    }
}
