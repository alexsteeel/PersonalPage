using Microsoft.EntityFrameworkCore;
using PersonalPage.Data.Entities;
using System.Linq;

namespace PersonalPage.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }

        public Post GetById(int id)
        {
            var post = Context.Posts
                .Where(x => x.Id == id)
                .Include(x => x.Comments)
                .FirstOrDefault();

            return post;
        }
    }
}
