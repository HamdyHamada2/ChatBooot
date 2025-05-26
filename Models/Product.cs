namespace AI_ChatBot.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // هل لديك خاصية Category؟ إذا لا، أضفها:
        public string Category { get; set; } = string.Empty;
    }
}