namespace IFitFusion.Service.Api.Infrastructure.Data.Queries
{
    public class TrainingPlanQuery
    {
        public const string Insert = @"
            INSERT INTO TrainingPlans (UserId, StartDate, EndDate)
            VALUES(@UserId, @StartDate, @EndDate)
			SELECT @@IDENTITY
        ";

        public const string Delete = @"
             BEGIN
				BEGIN
					DELETE PlannedExercises WHERE TrainingPlanId in(SELECT ID FROM TrainingPlans WHERE Id = @Id and UserId = @UserId)
				END
				BEGIN
					DELETE TrainingPlans WHERE Id = @Id and UserId = @UserId
				END
			 END
        ";

        public const string GetById = @"
            SELECT 
				T.Id 
				,T.UserId 
				,T.EndDate 
				,T.StartDate
			FROM 
				TrainingPlans T
			WHERE
				T.Id = @Id
				AND	T.UserID = @UserId
        ";

        public const string GetAll = @"
			SELECT 
				T.Id 
				,T.UserId 
				,T.EndDate 
				,T.StartDate
				,P.Id
				,P.TrainingPlanId
				,P.Repetitions
				,P.Sets
				,P.Weight
				,E.Id
				,E.Name
				,E.Description
				,E.ImagemUrl
			FROM 
				TrainingPlans T
			LEFT JOIN 
				PlannedExercises P
				ON T.Id = P.TrainingPlanId
			LEFT JOIN 
				Exercises E
				ON E.Id = P.ExerciseId
			WHERE
				T.UserID = @UserId
        ";
    }
}
