namespace IFitFusion.Application.Models.Response
{
    public class ExerciseResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? MuscleGroup { get; set; }
        public string? RequiredEquipment { get; set; }
        public string? DifficultyLevel { get; set; }
        public string? DemonstrationVideoUrl { get; set; }
        public string? ImgUrl { get; set; }
    }
}
