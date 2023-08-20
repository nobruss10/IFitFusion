using FitFusion.Infrastructure.Data.Queries;
using IFitFusion.Domain.Entities;
using IFitFusion.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace FitFusion.Infrastructure.Data.Repositories
{
    public class TrainingPlanRepository : BaseRepository, ITrainingPlanRepository
    {
        public TrainingPlanRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task Add(int userId, TrainingPlan trainingPlan)
        {
            var id = await ExecuteScalarAsync(TrainingPlanQuery.Insert, new { trainingPlan.UserId, trainingPlan.StartDate, trainingPlan.EndDate });
            await AddPlannedExercises(trainingPlan.PlannedExercises, id);
        }

        public async Task AddPlannedExercises(int trainingPlanId, List<PlannedExercise> plannedExercises)
        {
            await AddPlannedExercises(plannedExercises, trainingPlanId);
        }

        public async Task<int> AddPlannedExercise(int trainingPlanId, PlannedExercise plannedExercises)
        {
   
            return await ExecuteScalarAsync(PlannedExerciseQuery.Insert, new
            {
                TrainingPlanId = trainingPlanId,
                plannedExercises.ExerciseId,
                plannedExercises.Sets,
                plannedExercises.Repetitions,
                plannedExercises.Weight
            });
        }

        public async Task Delete(TrainingPlan trainingPlan)
        {
            await ExecuteScalarAsync(TrainingPlanQuery.Delete, new { trainingPlan.Id, trainingPlan.UserId});
        }

        public async Task<TrainingPlan> GetById(int userId, int id)
        {
            return await QueryFirstOrDefaultAsync<TrainingPlan>(TrainingPlanQuery.GetById, new { id, userId });
        }

        public async Task<IEnumerable<TrainingPlan>> GetAllAsync(int userId)
        {
            var lookup = new Dictionary<int, TrainingPlan>();

            var result = await ExecuteQueryAsync<TrainingPlan, PlannedExercise, Exercise, TrainingPlan>(TrainingPlanQuery.GetAll, (trainingPlan, plannedExercise, exercise) => {
                if (!lookup.TryGetValue(trainingPlan.Id, out TrainingPlan? _trainingPlan))
                {
                    _trainingPlan = trainingPlan;
                    lookup.Add(trainingPlan.Id, _trainingPlan);
                }

                if (plannedExercise is not null)
                {
                    plannedExercise.Exercise = exercise;
                    _trainingPlan.PlannedExercises.Add(plannedExercise);
                }

                return _trainingPlan;

            }, new { userId });

            return lookup.Values;
        }

        private async Task AddPlannedExercises(IList<PlannedExercise> plannedExercises, int id)
        {
            if (id > 0)
            {
                var parametersList = new List<dynamic>();
                foreach (var item in plannedExercises)
                {
                    parametersList.Add(new
                    {
                        TrainingPlanId = id,
                        item.ExerciseId,
                        item.Sets,
                        item.Repetitions,
                        item.Weight
                    });
                }

                await ExecuteAsync(PlannedExerciseQuery.Insert, parametersList);
            }
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await QueryAsync<Exercise>(ExerciseQuery.GetAll);
        }
    }
}
