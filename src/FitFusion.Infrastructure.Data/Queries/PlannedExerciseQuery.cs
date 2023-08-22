namespace IFitFusion.Infrastructure.Data.Queries
{
    public static class PlannedExerciseQuery
    {
        public const string GetById = @"
            SELECT
                Id
                ,TrainingPlanId
                ,ExerciseId
                ,Sets
                ,Repetitions
                ,Weight       
            FROM
                PlannedExercises
            WHERE
                Id = @Id
                AND TrainingPlanId IN(SELECT ID FROM TrainingPlans WHERE Id = @TrainingPlanId and UserId = @UserId)
        ";

        public const string Insert = @"
            INSERT INTO PlannedExercises (TrainingPlanId, ExerciseId, Sets, Repetitions, Weight)
            VALUES(@TrainingPlanId, @ExerciseId, @Sets, @Repetitions, @Weight)
			SELECT @@IDENTITY
        ";

        public const string Delete = @"
           DELETE 
                PlannedExercises 
           WHERE 
                Id = @Id
                AND TrainingPlanId IN(SELECT ID FROM TrainingPlans WHERE Id = @TrainingPlanId and UserId = @UserId)
        ";
    }
}
