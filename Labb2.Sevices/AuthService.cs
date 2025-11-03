using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2.Models;

namespace Labb2.Services
{
    public class AuthService
    {
        private readonly Db _db;
        public AuthService(Db db) => _db = db;

        public User? Login(string email, string password)
        {
            var u = _db.GetUserByEmail(email);
            return u; 
        }

        public Student RegisterStudent(string name, string email, string password)
        {
            var s = new Student { FullName = name, Email = email, Password = password };
            _db.Users.Add(s);
            return s;
        }
    }
}    
