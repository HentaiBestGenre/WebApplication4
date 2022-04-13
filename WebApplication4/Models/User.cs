using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string Password { get; set; }
        [Required] public bool IsBlock { get; set; } = false;
    }
}
