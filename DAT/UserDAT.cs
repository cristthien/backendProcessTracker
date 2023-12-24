using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Utility;
namespace DAT
{
    public class UserDAT
    {
        public static bool Insert(string username, string password) {
            AccountUtility  aUtility = new AccountUtility();
            password = aUtility.HashPassword(password);

            using (var dbcontext = new Context()) {
                try
                {
                    var existUser = dbcontext.users.Where(u => u.username == username).FirstOrDefault();
                    if (existUser != null ) {
                        return false;
                    }

                    var newuser = new User()
                    {
                        username = username,
                        hashPassword = password,
                    };

                    dbcontext.users.Add(newuser);
                    dbcontext.SaveChanges();

                    return true;

                }
                catch {
                    return false;
                }
            }
        }
        public static string GetUsername(int userID) {
            using (var dbcontext = new Context())
            {
                    User user = dbcontext.users.Where(u => u.id == userID).FirstOrDefault();
                try
                {
                    if (user != null)
                    {
                        return user.username;
                    }
                    else {
                        return "";
                    }
                }
                catch {
                    return "";
                }
            }
        }



        public int  CheckLogin(string username, string password) {
            AccountUtility aUtility = new AccountUtility();
            username = username.Trim();
            using (Context dbcontext = new Context())
            {
                var user = dbcontext.users.Where(u => u.username == username).FirstOrDefault();
                if (user == null)
                {
                    return -1;
                }

                if (aUtility.VerifyPassword(password, user.hashPassword))
                {
                    return user.id;

                }
                else { 
                    return -1;
                }
                

            }
        }

    }
}
