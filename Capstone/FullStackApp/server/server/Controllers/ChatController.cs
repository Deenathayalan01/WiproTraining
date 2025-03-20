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
    public class ChatController : ControllerBase
    {
        private readonly ChatDbContext _context;

        public ChatController(ChatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateChat([FromBody] Chat chat)
        {
            if (chat == null)
            {
                return BadRequest("Invalid chat data");
            }

            chat.Id = Guid.NewGuid();
            chat.CreatedAt = DateTime.UtcNow;

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            var response = new
            {
                id = chat.Id,
                chat_name = chat.ChatName,
                is_group = chat.IsGroup,
                created_at = chat.CreatedAt
            };

            return Created("https://localhost:5000/api/chats", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetChats()
        {
            var chats = await _context.Chats.Select(chat => new
            {
                id = chat.Id,
                chat_name = chat.ChatName,
                is_group = chat.IsGroup,
                created_at = chat.CreatedAt
            }).ToListAsync();

            return Ok(chats);
        }
    }
}
