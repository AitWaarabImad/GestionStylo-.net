using BLL.Dto;
using DAL;
using DAL.Entities;
using Microsoft.CodeAnalysis.Editing;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        public readonly MyDbContext _db;

        public UserService(MyDbContext db)
        {
            _db = db;
        }

        public User Sign(User user)
        {
            bool ok = true;
            List<User> list = _db.users.ToList();
            foreach (var u in list)
            {
                if (u.UserName.Equals(user.UserName))
                {
                    ok = false;
                    return null;
                }
            }
            if (ok)
            {
                _db.users.Add(user);
                _db.SaveChanges();
                return user;
            }
            return null;

        }
        public User Login(Login login)
        {
            User user = null;
            bool ok = false;
            List<User> list = _db.users.ToList();
            foreach (var u in list)
            {
                if (u.UserName.Equals(login.UserName) && u.UserPassword.Equals(login.UserPassword))
                {
                    user = u;
                    ok = true;
                    break;
                }

            }
            if (ok)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
