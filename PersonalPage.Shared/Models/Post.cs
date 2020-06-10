using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("comments")]
        public IList<Comment> Comments { get; set; }
    }
}
