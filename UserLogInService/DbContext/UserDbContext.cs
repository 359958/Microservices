using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserLogInService.Entities;

namespace UserLogInService.UserinfoDbContext
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }
        public virtual DbSet<User> UserInfo { get; set; }
    }
}
