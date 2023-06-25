using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp.UserManagment
{
    public class UserManagement
    {
        public bool IsAccountExist(string Email, string Password)
        {
            using (var db = new OrganizerDbContext())
            {
                var userValue = db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);

                if (userValue != null)
                {
                    return true;
                }

            }

            return false;
        }

        public bool IsAccountExist(string Email)
        {
            using (var db = new OrganizerDbContext())
            {
                var userValue = db.Users.FirstOrDefault(x => x.Email == Email);

                if (userValue != null)
                {
                    return true;
                }
            }

            return false;
        }

        public void registerAccount(string username, string email, string password)
        {
            using (var db = new OrganizerDbContext())
            {

                var newUser = new User
                {
                    Name = username,
                    Email = email,
                    Password = password
                };

                db.Add(newUser);
                db.SaveChanges();
            }
        }

        public string GetUserParameters(string email, string password)
        {
            using (var db = new OrganizerDbContext())
            {
                var userValue = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password); ;

                return userValue.Name;
            }

        }


    }
}
