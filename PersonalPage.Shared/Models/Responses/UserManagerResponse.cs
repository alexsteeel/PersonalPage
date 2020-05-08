using System;

namespace PersonalPage.Shared.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public string[] Errors { get; set; }

    }
}
