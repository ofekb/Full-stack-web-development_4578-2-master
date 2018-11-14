using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbManager
    {

        private static string GetSqlConnection()
        {
                string connectionString = "Data Source=.;Initial Catalog=BookStore;Integrated Security=True";

            return connectionString;
        }


        public static void ExecDb(string command)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(GetSqlConnection()))
                {

                    sql.Open();

                    SqlCommand query = new SqlCommand(command, sql);

                    query.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
