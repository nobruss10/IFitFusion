namespace IFitFusion.Application.Models.Request
{
    public class TrainingPlanRequestModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlannedExerciseRequestModel> PlannedExercises { get; set; }
    }
}
