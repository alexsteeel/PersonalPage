namespace PersonalPage.Core
{
    public abstract class UseCaseResponseMessage
    {
        public int Status { get; }

        protected UseCaseResponseMessage(int status)
        {
            Status = status;
        }
    }
}
