namespace RealTimeChatApp_Project1.Models
{
    public class GroupMember
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }  

        public string Role { get; set; }

    }
}
