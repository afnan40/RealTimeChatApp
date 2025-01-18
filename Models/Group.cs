namespace RealTimeChatApp_Project1.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }

    public ICollection<GroupMember> Members { get; set; }
    public ICollection<Message> Messages { get; set; }
    }
}
