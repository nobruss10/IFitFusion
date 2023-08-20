namespace IFitFusion.Application.Models.Response
{
    public class TrainingPlanReponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlannedExerciseResponseModel> PlannedExercises { get; set; }
    }
}
