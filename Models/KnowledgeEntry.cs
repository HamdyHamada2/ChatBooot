using System;

namespace AI_ChatBot.Models
{
    public class KnowledgeEntry
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public DateTime AddedAt { get; set; } = DateTime.Now; // يعكس العمود الموجود في SQL
    }
}
