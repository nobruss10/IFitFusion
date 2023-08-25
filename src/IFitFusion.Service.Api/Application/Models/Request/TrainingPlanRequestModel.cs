namespace IFitFusion.Service.Api.ApplicationModels.Request
{
    public class TrainingPlanRequestModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlannedExerciseRequestModel> PlannedExercises { get; set; }
    }
}
