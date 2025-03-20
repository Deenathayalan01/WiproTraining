using ChatApp.Models;
using System;

namespace ChatApp.Models
{
    public class Participant
    {
        public Guid ParticipantId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public Conversation Conversation { get; set; }
        public User User { get; set; }
    }
}
