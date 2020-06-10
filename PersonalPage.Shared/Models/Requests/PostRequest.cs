namespace PersonalPage.Shared.Models
{
    public class PostRequest
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }
    }
}
