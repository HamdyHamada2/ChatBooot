using Microsoft.AspNetCore.Mvc;
using AI_ChatBot.Services;
using AI_ChatBot.Data;
using AI_ChatBot.Models;

namespace AI_ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ChatBotService _chatBotService;

        public ChatBotController(ApplicationDbContext context, ChatBotService chatBotService)
        {
            _context = context;
            _chatBotService = chatBotService;
        }

        [HttpPost("ask")]
        public IActionResult Ask([FromBody] ChatMessage message)
        {
            var response = _chatBotService.GetResponse(message.UserMessage); // ✅ تم التعديل هنا
            return Ok(new { response });
        }
    }
}
