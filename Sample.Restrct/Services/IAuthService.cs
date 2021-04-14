using Sample.Restrct.Models;

namespace Sample.Restrct.Services
{
    public interface IAuthService
    {
        LoginResponse Login(UserModel user);
    }
}
