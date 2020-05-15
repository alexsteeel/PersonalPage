using System;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public Post Post { get; set; }

        public DateTime CreateDate { get; set; }

        public string Content { get; set; }

        public int? ParentCommentId { get; set; }

        public Comment ParentComment { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public bool Approved { get; set; }
    }
}
