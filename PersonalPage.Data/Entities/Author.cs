using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }

        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
