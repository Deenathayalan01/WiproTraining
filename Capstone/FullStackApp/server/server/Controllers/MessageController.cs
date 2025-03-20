using ChatApp.Models;
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
    public class MessageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> CreateMessage([FromBody] Message message)
        {
            if (message == null)
            {
                return BadRequest("Invalid message data");
            }

            message.Id = Guid.NewGuid();
            message.CreatedAt = DateTime.UtcNow;
            message.Viewed = false;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            var response = new
            {
                id = message.Id,
                chat_id = message.ChatId,
                sender_id = message.SenderId,
                message_text = message.MessageText,
                media_url = message.MediaUrl,
                media_type = message.MediaType,
                view_once = message.ViewOnce,
                viewed = message.Viewed,
                created_at = message.CreatedAt
            };

            return Created("https://localhost:5000/api/messages", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetMessages([FromQuery] Guid chat_id)
        {
            var messages = await _context.Messages
                .Where(m => m.ChatId == chat_id)
                .Select(message => new
                {
                    id = message.Id,
                    chat_id = message.ChatId,
                    sender_id = message.SenderId,
                    message_text = message.MessageText,
                    media_url = message.MediaUrl,
                    media_type = message.MediaType,
                    view_once = message.ViewOnce,
                    viewed = message.Viewed,
                    created_at = message.CreatedAt
                })
                .ToListAsync();

            return Ok(messages);
        }
    }
}
