using System.ComponentModel.DataAnnotations;

namespace BallonGame.Models
{
    public class Users
    {
        [Key]
        public int UId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int score { get; set; }
    }
}
