using IFitFusion.Service.Api.ApplicationModels.Internal;
using IFitFusion.Service.Api.ApplicationModels.Request;
using IFitFusion.Service.Api.ApplicationModels.Response;
using IFitFusion.Service.Api.Auth;
using IFitFusion.Service.Api.Domain.Entities;

namespace IFitFusion.Service.Api.Application.Adapters
{
    public static class DomainAdapter
    {
        public static User ToDomain(this UserRequestModel userModel)
        {
            return new User
            (
                name: userModel.Name,
                birthDate: userModel.BirthDate,
                gender: userModel.Gender,
                email: userModel.Email,
                phone: userModel.Phone,
                height: userModel.Height,
                weight: userModel.Weight,
                goal: userModel.Goal,
                password: userModel.Password
            );
        }

        public static TrainingPlan ToDomain(this TrainingPlanRequestModel model, int userId)
        {
            return new TrainingPlan
            {
                UserId = userId,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                PlannedExercises = model?.PlannedExercises?.ToDomain() ?? new(),
            };
        }

        public static List<PlannedExercise> ToDomain(this List<PlannedExerciseRequestModel> model)
        {
            return model.Select(x => x.ToDomain()).ToList();
        }


        public static PlannedExercise ToDomain(this PlannedExerciseRequestModel model)
        {
            return new PlannedExercise
            {
                ExerciseId = model.ExerciseId,
                Repetitions = model.Repetitions,
                Sets = model.Sets,
                Weight = model.Weight
            };
        }


        public static UserIdentityModel ToModel(this User user)
        {
            return new UserIdentityModel
            {
                Email = user.Email.Adreess,
                Id = user.Id,
                IsAuthenticated = true,
                Name = user.Name
            };
        }

        public static LoginResponseModel ToModel(this JwtToken token, User userResponse)
        {
            return new LoginResponseModel
            {
                AccessToken = token.Value,
                ExpiresIn = token.ExpiresIn,
                UserToken = new UserTokenResponseModel
                {
                    User = new UserResponseModel
                    {
                        Name = userResponse.Name,
                        Active = userResponse.Active,
                        Email = userResponse.Email.Adreess,
                        Gender = userResponse.Gender.ToString(),
                        BirthDate = userResponse.BirthDate,
                        Goal = userResponse.Goal,
                        Height = userResponse.Height,
                        Phone = userResponse.Phone,
                        Weight = userResponse.Weight
                    }
                }
            };
        }
    }
}
