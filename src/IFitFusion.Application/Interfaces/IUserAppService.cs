namespace Sequenza.Pricefy.Application.Interfaces
{
    internal interface IUserAppService
    {
        public Task Register();
        public Task<bool> Authentication();
    }
}
