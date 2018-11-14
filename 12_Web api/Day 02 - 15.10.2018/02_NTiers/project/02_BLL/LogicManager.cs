using _00_DAL;
using _01_BOL;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _02_BLL
{
    public static class LogicManager
    {

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM [dbo].[Users]";

            Func<SqlDataReader, List<User>> func = (reader)=>{
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id =reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        IsMale = reader.GetBoolean(3),
                        Age = reader.GetInt32(2)
                    });
                }
                return users;
             };

            return DBAccess.RunReader(query, func);
        }

        public static string GetUserName(int id)
        {
            string query = $"SELECT Name FROM [dbo].[Users] WHERE Id={id}";
            return DBAccess.RunScalar(query).ToString();
        }

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM [dbo].[Users] WHERE Id={id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE [dbo].[Users] SET Name='{user.UserName}', Age={user.Age}  WHERE Id={user.Id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {
            string query = $"INSERT INTO [dbo].[Users] VALUES ('{user.UserName}',{user.Age},{Convert.ToByte(user.IsMale)})";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }
}
