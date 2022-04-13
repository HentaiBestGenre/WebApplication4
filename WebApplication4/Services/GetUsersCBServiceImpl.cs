using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Services
{
    public class GetUsersCBServiceImpl : GetUsersCBService
    {
        private readonly ApplicationDbContext _db;

        public GetUsersCBServiceImpl(ApplicationDbContext db) => _db = db;
        public List<UserCheckBox> GetUsersCB()
        {
            List<User> UsersDb = _db.Users.ToList();
            List<UserCheckBox> UsersCB = new List<UserCheckBox>();
            foreach (var user in UsersDb) { UsersCB.Add(new UserCheckBox() { Id = user.Id, Login = user.Login, Password = user.Password, IsBlock = user.IsBlock, IsCheck = false }); }
            return UsersCB;
        }
    }
}
