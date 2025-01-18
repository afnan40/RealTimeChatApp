namespace RealTimeChatApp_Project1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public string? ProfilePicture { get; set; }

        public ICollection<GroupMember> GroupMemberships { get; set; }
        public ICollection<Message> MessagesSent { get; set; }


    }
}
