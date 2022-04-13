using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Services
{
    public interface UserService {
        public User Login(string login);
        public void Reg(string login, string password);
    }

    // CB - check box
    public interface GetUsersCBService { public List<UserCheckBox> GetUsersCB(); }
}
