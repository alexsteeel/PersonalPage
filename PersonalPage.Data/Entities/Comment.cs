using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalPage.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int? PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string Content { get; set; }

        public int? ParentCommentId { get; set; }

        [ForeignKey("CommentId")]
        public Comment ParentComment { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public bool Approved { get; set; }
    }
}
