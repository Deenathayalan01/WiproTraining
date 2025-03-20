using ChatApp.Models;
using System;
using System.Collections.Generic;

namespace ChatApp.Models
{
    public class Conversation
    {
        public Guid ConversationId { get; set; }
        public string ConversationName { get; set; }
        public bool IsGroup { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Participant> Participants { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
