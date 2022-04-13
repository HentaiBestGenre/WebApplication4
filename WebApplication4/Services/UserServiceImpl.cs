using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly ApplicationDbContext _db;

        public UserServiceImpl(ApplicationDbContext db) => _db = db;
        public User Login(string login) // find row
        {
            var users = _db.Users.Where(x => EF.Functions.Like(x.Login, $"%{login}%")).ToList();
            foreach (var user in users) { if (user.Login == login) { return user; } }
            return null;
        }
        public void Reg(string login, string password)
        {
            User NewUser = new User() { Login = login, Password = password };
            _db.Users.Add(NewUser);
            _db.SaveChanges();
        }


    }
}
