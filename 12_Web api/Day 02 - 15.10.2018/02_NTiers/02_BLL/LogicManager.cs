using _00_DAL;
using _01_BOL;
using System.Collections.Generic;
using System.Linq;

namespace _02_BLL
{
    public static class LogicManager
    {

        public static List<User> GetAllUsers()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return db.Users.Select(u => (new User
                {
                    Id = u.Id,
                    UserName = u.Name,
                    IsMale = u.IsMale,
                    Age = u.Age
                })).ToList();
            }

        }

        public static string GetUserName(int id)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                Users dbUser = db.Users.FirstOrDefault(u => u.Id == id);
                return (dbUser == null) ? null : dbUser.Name;

            }
        }

        public static bool RemoveUser(int id)
        {

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Users dbUser = db.Users.FirstOrDefault(u => u.Id == id);
                if (dbUser == null)
                    return false;

                db.Users.Remove(dbUser);


                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public static bool UpdateUser(User user)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                Users dbUser = db.Users.FirstOrDefault(u => u.Id == user.Id);

                if (dbUser == null)
                    return false;

                dbUser.Name = user.UserName;
                dbUser.Age = user.Age;
                dbUser.IsMale = user.IsMale;

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool AddUser(User user)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.Users.Add(new Users
                {
                    Id = user.Id,
                    Name = user.UserName,
                    IsMale = user.IsMale,
                    Age = user.Age
                });

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }


        }
    }
}
