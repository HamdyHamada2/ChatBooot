using Microsoft.EntityFrameworkCore;
using AI_ChatBot.Models; // تأكد إن دا نفس namespace اللي فيه الموديلات

namespace AI_ChatBot.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // الجداول
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<KnowledgeEntry> KnowledgeEntries { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // صريح لكن اختياري
            modelBuilder.Entity<ChatMessage>().HasKey(c => c.Id);
        }
    }
}
