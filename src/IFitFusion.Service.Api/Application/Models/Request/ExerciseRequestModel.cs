namespace IFitFusion.Service.Api.ApplicationModels.Request
{
    public class ExerciseRequestModel
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}
