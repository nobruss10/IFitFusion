namespace IFitFusion.Service.Api.Domain.Entities
{
    public class Equipment : Entity
    {
        public Equipment(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
