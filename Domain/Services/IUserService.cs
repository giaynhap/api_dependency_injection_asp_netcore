

namespace apicore.Domain.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password); 
    }
}