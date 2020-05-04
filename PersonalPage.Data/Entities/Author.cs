using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
