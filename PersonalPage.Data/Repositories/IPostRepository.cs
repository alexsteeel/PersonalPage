using PersonalPage.Data.Entities;

namespace PersonalPage.Data.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Post GetById(int id);
    }
}