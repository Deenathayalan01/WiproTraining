using System;

namespace ChatApp.Models
{
    public class Token
    {
        public Guid TokenId { get; set; }
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
