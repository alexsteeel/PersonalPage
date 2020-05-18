using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Data.Entities
{
    public class Author
    {
        [Key]
        [MaxLength(450)]
        public string UserId { get; set; }

        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
