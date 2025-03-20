using ChatApp.Models;
using System;

namespace ChatApp.Models
{
    public class ViewOnceStatus
    {
        public Guid ViewId { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

        public Message Message { get; set; }
        public User User { get; set; }
    }
}
