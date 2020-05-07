namespace PersonalPage.Core
{
    public abstract class UseCaseResponseMessage
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        protected UseCaseResponseMessage(bool isSuccess = false, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
