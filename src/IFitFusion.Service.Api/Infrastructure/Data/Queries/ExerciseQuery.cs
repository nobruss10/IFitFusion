namespace IFitFusion.Service.Api.Infrastructure.Data.Queries
{
    public static class ExerciseQuery
    {
        public const string GetAll = @"
            SELECT
                Id
                ,Name
                ,Description
                ,MuscleGroup
                ,DifficultyLevel
                ,ImagemUrl
            FROM
                Exercises
        ";
    }
}
