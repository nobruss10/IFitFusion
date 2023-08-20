using IFitFusion.Application.Interfaces;
using IFitFusion.Application.Models.Request;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Auth;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IFitFusion.Service.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TrainingPlanController : MainController
    {
        private readonly ITrainingPlanAppService _trainingPlanAppService;
        public TrainingPlanController(
            IDomainNotifier notificador,
            IUserLogged appUser,
            ITrainingPlanAppService trainingPlanAppService)
            : base(notificador, appUser)
        {
            _trainingPlanAppService = trainingPlanAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await _trainingPlanAppService.GetAll(AppUser.Id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrainingPlanRequestModel request)
        {
            await _trainingPlanAppService.Add(AppUser.Id, request);
            return CustomResponse();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _trainingPlanAppService.Delete(AppUser.Id, id);
            return CustomResponse();
        }

        [HttpDelete]
        [Route("{id}/plan-exercise/{planExerciseId}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int planExerciseId)
        {
            await _trainingPlanAppService.DeletePlanExercise(AppUser.Id, id, planExerciseId);
            return CustomResponse();
        }

        [HttpGet]
        [Route("exercises")]
        public async Task<IActionResult> GetExercise()
        {
            return CustomResponse(await _trainingPlanAppService.GetAllExercises());
        }

        [HttpPost]
        [Route("{id}/planned-exercises")]
        public async Task<IActionResult> AddPlannedExercises([FromRoute] int id, [FromBody] List<PlannedExerciseRequestModel> plannedExercises)
        {
            await _trainingPlanAppService.AddPlannedExercises(AppUser.Id, id, plannedExercises);
            return CustomResponse();
        }

        [HttpPost]
        [Route("{id}/planned-exercise")]
        public async Task<IActionResult> AddPlannedExercise([FromRoute] int id, [FromBody] PlannedExerciseRequestModel plannedExercises)
        {
            return CustomResponse(await _trainingPlanAppService.AddPlannedExercise(AppUser.Id, id, plannedExercises)); ;
        }
    }
}
