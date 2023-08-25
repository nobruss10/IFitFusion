namespace IFitFusion.Service.Api.ApplicationModels.Response
{
    public class PlannedExerciseResponseModel
    {
        public int Id { get; set; }
        public int TrainingPlanId { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public Decimal Weight { get; set; }

        public ExerciseResponseModel Exercise { get; set; }

    }
}
