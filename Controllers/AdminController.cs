using Microsoft.AspNetCore.Mvc;
using AI_ChatBot.Data;  // المكان اللي فيه تعريف ApplicationDbContext
using AI_ChatBot.Models;

namespace AI_ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPost("add-knowledge")]
        public IActionResult AddKnowledge([FromBody] KnowledgeEntry entry)
        {
            _context.KnowledgeEntries.Add(entry);
            _context.SaveChanges();
            return Ok(entry);
        }
    }

}