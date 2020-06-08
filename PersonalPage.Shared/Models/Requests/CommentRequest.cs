namespace PersonalPage.Shared.Models
{
    public class CommentRequest
    {
        public string Id { get; set; }

        public string AuthorId { get; set; }

        public string PostId { get; set; }

        public string ParentCommentId { get; set; }

        public string Content { get; set; }
    }
}
