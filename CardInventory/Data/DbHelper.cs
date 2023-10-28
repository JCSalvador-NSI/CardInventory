using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CardInventory.Data
{
    public static class DbHelper
    {
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            sqlite_conn.Open();

            return sqlite_conn;
        }

        static void ExecNonQuery(string _sql)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = CreateConnection();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //TODO: Handle err
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }

        static DataTable ExecReader(string _sql)
        {
            SQLiteConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = CreateConnection();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _sql;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                //TODO: Handle err
                return null;
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }
    }
}
