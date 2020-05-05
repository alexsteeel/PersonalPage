namespace PersonalPage.Core
{
    public class User
    {
        public string Id { get; }
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get; }

        internal User(string userName, string email, string id = null, string passwordHash = null)
        {
            Id = id;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}
