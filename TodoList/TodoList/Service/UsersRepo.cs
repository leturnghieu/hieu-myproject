using System.Linq;
using TodoList.Data;
using TodoList.DTOs;

namespace TodoList.Service
{
    public class UsersRepo : IUsers
    {
        private readonly MyDbContext _context;

        public UsersRepo(MyDbContext context)
        {
            _context = context;
        }

        public Register Add(Register user)
        {
            var query = _context.users.SingleOrDefault(u => u.UserName == user.UserName);
            var UserAdd = new Users();
            if (query == null)
            {
                UserAdd.UserName = user.UserName;
                UserAdd.Password = user.Password;
                _context.Add(UserAdd);
                _context.SaveChanges();
                return user;
            }
            return null;

        }
    }
}
