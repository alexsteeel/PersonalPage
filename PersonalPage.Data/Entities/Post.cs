using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalPage.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Required]
        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
