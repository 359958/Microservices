using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogInService.Entities;
using UserLogInService.Model;
using UserLogInService.UserinfoDbContext;

namespace UserLogInService.Services
{
    public class UserService : IUserService
    {
        private LoginDbContext _context;
        public UserService(LoginDbContext context)
        {
            _context = context;
        }
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> userdate = _context.UserInfo.AsEnumerable();
            return userdate;
        }
        
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
