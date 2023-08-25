namespace IFitFusion.Service.Api.ApplicationModels.Response
{
    public class UserResponseModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Phone { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Goal { get; set; }
        public string ProfilePhotoUrl { get; set; } 
    }
}
