using AI_ChatBot.Models;
using AI_ChatBot.Data;

namespace AI_ChatBot.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { /* properties */ },
                    new Product { /* properties */ }
                );

                context.SaveChanges();
            }
        }
    }
}
