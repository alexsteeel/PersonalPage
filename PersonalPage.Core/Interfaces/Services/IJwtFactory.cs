using System.Threading.Tasks;

namespace PersonalPage.Core
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
