using System.Threading.Tasks;
using cruddotnetcore.API.Domain.Models;

namespace cruddotnetcore.API.Domain.Repositories
{
  public interface IAuthRepository
  {
    Task<User> Register(User user, string password);

    Task<User> Login(string username, string password);

    Task<bool> UserExists(string username);
  }
}