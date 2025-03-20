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
    public class MessageViewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessageViewController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateMessageView([FromBody] MessageView messageView)
        {
            if (messageView == null)
            {
                return BadRequest("Invalid message view data");
            }

            messageView.Id = Guid.NewGuid();
            messageView.ViewedAt = DateTime.UtcNow;

            _context.MessageViews.Add(messageView);
            await _context.SaveChangesAsync();

            var response = new
            {
                id = messageView.Id,
                message_id = messageView.MessageId,
                viewer_id = messageView.ViewerId,
                viewed_at = messageView.ViewedAt
            };

            return Created("https://localhost:5000/api/message_views", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetMessageViews([FromQuery] Guid message_id)
        {
            var messageViews = await _context.MessageViews
                .Where(mv => mv.MessageId == message_id)
                .Select(mv => new
                {
                    id = mv.Id,
                    message_id = mv.MessageId,
                    viewer_id = mv.ViewerId,
                    viewed_at = mv.ViewedAt
                }).ToListAsync();

            return Ok(messageViews);
        }
    }
}
