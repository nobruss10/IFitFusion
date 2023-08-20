using IFitFusion.Application.Models.Response;
using IFitFusion.Domain.Entities;

namespace IFitFusion.Application.Adapters
{
    public static class ModelAdapter
    {
        public static IEnumerable<TrainingPlanReponseModel> ToModel(this IEnumerable<TrainingPlan> domain)
        {
            return domain.Select(x => x.ToModel()); 
        }

        public static TrainingPlanReponseModel ToModel(this TrainingPlan domain)
        {
            return new TrainingPlanReponseModel
            {
                Id = domain.Id,
                UserId = domain.UserId,
                EndDate = domain.EndDate,
                StartDate = domain.StartDate,
                PlannedExercises = domain.PlannedExercises.Select(p => p.ToModel()).ToList()
            };
        }

        public static PlannedExerciseResponseModel ToModel(this PlannedExercise domain)
        {
            return new PlannedExerciseResponseModel
            {
                Id = domain.Id,
                TrainingPlanId = domain.TrainingPlanId,
                Exercise = domain.Exercise.ToModel(),
                Repetitions = domain.Repetitions,
                Sets = domain.Sets,
                Weight = domain.Weight
            };
        }

        public static IEnumerable<ExerciseResponseModel> ToModel(this IEnumerable<Exercise> domain)
        {
            return domain.Select(x => x.ToModel());
        }

        public static ExerciseResponseModel ToModel(this Exercise domain)
        {
            return new ExerciseResponseModel
            {
                Id = domain.Id,
                Name = domain.Name,
                DemonstrationVideoUrl = domain.DemonstrationVideoUrl,
                Description = domain.Description,
                DifficultyLevel = domain.DifficultyLevel,
                ImgUrl = domain.ImagemUrl,
                MuscleGroup = domain.MuscleGroup
            };
        }
    }
}
