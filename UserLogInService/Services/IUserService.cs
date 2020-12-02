﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogInService.Entities;
using UserLogInService.Model;

namespace UserLogInService.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
