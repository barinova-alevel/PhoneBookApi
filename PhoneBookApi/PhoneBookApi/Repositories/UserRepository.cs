using PhoneBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookApi.Repositories
{
    public class UserRepository
    {
        private List<User> userList = new List<User>
        {
            new User
            {
                Login = "garry",
                Password = "potter"
            },
            new User
            {
                Login = "lady",
                Password = "fox"
            },
        };
        public User Get(string login, string password)
        {
            return userList
                .SingleOrDefault(u => u.Login == login &&
                    u.Password == password);
        }
    }
}