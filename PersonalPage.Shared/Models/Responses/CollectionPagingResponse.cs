using System.Collections.Generic;

namespace PersonalPage.Shared.Models
{
    public class CollectionPagingResponse<T> : BaseAPIResponse
    {
        public IList<T> Records { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; } = 1;

        public int? NextPage { get; set; }

        public int Count { get; set; }
    }
}
