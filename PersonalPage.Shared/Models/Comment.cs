using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("authorId")]
        public int AuthorId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("parentCommentId")]
        public int ParentCommentId { get; set; }

        [JsonProperty("comments")]
        public IList<object> Comments { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }
    }
}
