namespace AI_ChatBot.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }  // المفتاح الأساسي

        public string UserMessage { get; set; } = string.Empty;

        public string BotResponse { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
