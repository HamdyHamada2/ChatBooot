using AI_ChatBot.Data;
using AI_ChatBot.Models;
using System;
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

            // البحث في جدول المعرفة أولاً
            var knowledgeMatch = _context.KnowledgeEntries
                .FirstOrDefault(k =>
                    userInput.Contains(k.Question, StringComparison.OrdinalIgnoreCase) ||
                    k.Question.Contains(userInput, StringComparison.OrdinalIgnoreCase));

            if (knowledgeMatch != null)
            {
                _context.ChatMessages.Add(new ChatMessage
                {
                    UserMessage = userInput,
                    BotResponse = knowledgeMatch.Answer
                });
                _context.SaveChanges();

                return knowledgeMatch.Answer;
            }

            // البحث في جدول المنتجات
            var productMatch = _context.Products
                .FirstOrDefault(p =>
                    userInput.Contains(p.Name, StringComparison.OrdinalIgnoreCase) ||
                    p.Name.Contains(userInput, StringComparison.OrdinalIgnoreCase));

            if (productMatch != null)
            {
                var response = $"المنتج: {productMatch.Name}\n" +
                               $"الوصف: {productMatch.Description}\n" +
                               $"الفئة: {productMatch.Category}";

                _context.ChatMessages.Add(new ChatMessage
                {
                    UserMessage = userInput,
                    BotResponse = response
                });
                _context.SaveChanges();

                return response;
            }

            return "أنا آسف، لم أفهم سؤالك. هل يمكنك إعادة صياغته؟";
        }
    }
}
