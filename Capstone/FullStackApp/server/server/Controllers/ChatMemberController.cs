using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMemberController : ControllerBase
    {
        private readonly ChatDbContext _context;

        public ChatMemberController(ChatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<object>> AddChatMember([FromBody] ChatMember chatMember)
        {
            if (chatMember == null)
            {
                return BadRequest("Invalid chat member data");
            }

            chatMember.Id = Guid.NewGuid();
            chatMember.JoinedAt = DateTime.UtcNow;

            _context.ChatMembers.Add(chatMember);
            await _context.SaveChangesAsync();

            var response = new
            {
                id = chatMember.Id,
                chat_id = chatMember.ChatId,
                user_id = chatMember.UserId,
                joined_at = chatMember.JoinedAt
            };

            return Created("https://localhost:5000/api/chat_members", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetChatMembers([FromQuery] Guid chat_id)
        {
            var members = await _context.ChatMembers
                .Where(cm => cm.ChatId == chat_id)
                .Select(cm => new
                {
                    id = cm.Id,
                    chat_id = cm.ChatId,
                    user_id = cm.UserId,
                    joined_at = cm.JoinedAt
                })
                .ToListAsync();

            return Ok(members);
        }
    }
}
