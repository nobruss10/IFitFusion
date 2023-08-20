using IFitFusion.Infrastructure.CrossCutting.DomainHelper;

namespace IFitFusion.Domain.Entities
{
    public class Exercise : Entity
    {
        protected Exercise() { }    
        public Exercise(string? name, string? description, string? muscleGroup, string? requiredEquipment, string? difficultyLevel, string? demonstrationVideo)
        {
            Name = name;
            Description = description;
            MuscleGroup = muscleGroup;
            RequiredEquipment = requiredEquipment;
            DifficultyLevel = difficultyLevel;
            DemonstrationVideoUrl = demonstrationVideo;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? MuscleGroup { get; private set; }
        public string? RequiredEquipment { get; private set; }
        public string? DifficultyLevel { get; private set; }
        public string? DemonstrationVideoUrl { get; private set; }
        public string? ImagemUrl { get; private set; }

    }
}
