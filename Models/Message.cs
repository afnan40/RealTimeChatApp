namespace RealTimeChatApp_Project1.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

    }
}
