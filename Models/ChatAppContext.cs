using Microsoft.EntityFrameworkCore;

namespace RealTimeChatApp_Project1.Models
{
    public class ChatAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupMember>().HasKey(gm => new { gm.GroupId, gm.UserId });

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Messages)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.Members)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}