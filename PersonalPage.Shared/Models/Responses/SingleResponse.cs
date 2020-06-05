namespace PersonalPage.Shared.Models
{
    public class SingleResponse<T> : BaseAPIResponse
    {
        public T Record { get; set; }
    }
}
