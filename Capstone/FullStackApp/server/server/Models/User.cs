using System;
using System.Collections.Generic;

namespace ChatApp.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Participant> Participants { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
