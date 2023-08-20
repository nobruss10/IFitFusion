namespace IFitFusion.Application.Models.Request
{
    public class PlannedExerciseRequestModel
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public Decimal Weight { get; set; }

    }
}
