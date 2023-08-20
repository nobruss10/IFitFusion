using IFitFusion.Application.Adapters;
using IFitFusion.Application.Interfaces;
using IFitFusion.Application.Models.Request;
using IFitFusion.Application.Models.Response;
using IFitFusion.Domain.Entities;
using IFitFusion.Domain.Repositories;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Auth;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Interface;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.ValueObjects;

namespace IFitFusion.Application.ApplicationServices
{
    public class UserAppService : ApplicationBaseService, IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository, IDomainNotifier notificador)
            : base(notificador) 
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseModel?> Login(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.PasswordSignInAsync(loginRequest.email, PasswordVO.Encrypt(loginRequest.password));
            if (user is null)
            {
                NotificarErro("Credenciais inválidas: o nome de usuário ou a senha fornecidos não estão corretos.");
                return null;
            }
                
            return new AuthService().GenerateToken(user.ToModel()).ToModel(user);
        }

        public async Task Register(UserRequestModel userModel)
        {
            var user = userModel.ToDomain();
            if (await IsInvalid(user))
                return;

            await _userRepository.AddUser(userModel.ToDomain());
        }

        private async Task<bool> IsInvalid(User user)
        {
            if (!EmailVO.IsValid(user.Email.Adreess))
            {
                NotificarErro("E-mail Inválido");
                return true;
            }

            if (await _userRepository.CheckEmail(user.Email.Adreess))
            {
                NotificarErro("E-mail já cadastrado!");
                return true;
            }

            return false;               
        }
    }
}
