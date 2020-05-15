using System;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class Post
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
