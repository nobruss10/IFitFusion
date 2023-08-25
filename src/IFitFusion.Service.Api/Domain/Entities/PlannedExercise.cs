namespace IFitFusion.Service.Api.Domain.Entities
{
    public class PlannedExercise : Entity
    {
        public int ExerciseId { get; set; }
        public int TrainingPlanId { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public Decimal Weight { get; set; }

        public Exercise Exercise { get; set; }
    }
}
