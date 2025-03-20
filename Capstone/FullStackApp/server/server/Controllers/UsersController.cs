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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var response = new
            {
                id = user.Id,
                username = user.Username,
                email = user.Email,
                profile_picture = user.ProfilePicture,
                created_at = user.CreatedAt
            };

            return Created("https://localhost:5000/api/users", response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers()
        {
            var users = await _context.Users.Select(user => new
            {
                id = user.Id,
                username = user.Username,
                email = user.Email,
                profile_picture = user.ProfilePicture,
                created_at = user.CreatedAt
            }).ToListAsync();

            return Ok(users);
        }
    }
}
