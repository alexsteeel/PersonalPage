using System.Collections.Generic;

namespace PersonalPage.Data.Entities
{
    public class Author
    {
        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
