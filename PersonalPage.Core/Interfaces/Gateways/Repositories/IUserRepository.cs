using System.Threading.Tasks;

namespace PersonalPage.Core
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);

        Task<User> FindByName(string userName);

        Task<bool> CheckPassword(User user, string password);
    }
}
