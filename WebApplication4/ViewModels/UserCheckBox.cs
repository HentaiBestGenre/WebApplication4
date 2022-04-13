using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class UserCheckBox
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsBlock { get; set; }
        public bool IsCheck { get; set; }
    }
}
