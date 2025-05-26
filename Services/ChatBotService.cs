using AI_ChatBot.Data;
using AI_ChatBot.Models;
using System.Linq;

namespace AI_ChatBot.Services
{
    public class ChatBotService
    {
        private readonly ApplicationDbContext _context;

        public ChatBotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "من فضلك أدخل سؤالاً مفهوماً.";

            // بحث بسيط في الأسئلة من قاعدة البيانات
            var match = _context.KnowledgeEntries
                .FirstOrDefault(k =>
                    userInput.Contains(k.Question, StringComparison.OrdinalIgnoreCase) ||
                    k.Question.Contains(userInput, StringComparison.OrdinalIgnoreCase));

            if (match != null)
            {
                // تسجيل السؤال والرد في جدول ChatMessages
                _context.ChatMessages.Add(new ChatMessage
                {
                    UserMessage = userInput,
                    BotResponse = match.Answer
                });
                _context.SaveChanges();

                return match.Answer;
            }

            return "أنا آسف، لم أفهم سؤالك. هل يمكنك إعادة صياغته؟";
        }
    }
}
