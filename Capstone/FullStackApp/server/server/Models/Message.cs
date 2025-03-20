using System;

namespace ChatApp.Models
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid SenderId { get; set; }
        public string MessageText { get; set; }
        public string MediaUrl { get; set; }
        public bool IsViewOnce { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public Conversation Conversation { get; set; }
        public User Sender { get; set; }
    }
}
