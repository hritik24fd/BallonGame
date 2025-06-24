using BallonGame.Data;
using BallonGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BallonGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalloonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BalloonController(ApplicationDbContext context) {
            _context = context;
        }



        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] Users users)
        {
            if (users == null)
            {
                return BadRequest("User data is null");
            }

            _context.Users.Add(users);
            _context.SaveChanges();

            return Ok(users);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            if (users == null || !users.Any())
            {
                return NotFound("No users found!");
            }
            var topUsers = users
         .GroupBy(u => u.Email)
         .Select(g => g.OrderByDescending(u => u.score).First())
         .OrderByDescending(u => u.score)
         .ToList();

            return Ok(topUsers);
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found!");
            }

            return Ok(user);
        }
    }
}
