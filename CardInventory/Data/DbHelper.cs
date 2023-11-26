using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace CardInventory.Data
{
    public static class DbHelper
    {
        private static string DB_FILEPATH = Path.Combine(Application.StartupPath, "maindata.db");
        private static int DB_VERSION = 0;//NOTE: Increment by 1 for any/all database modification done. Eg: Create table, alter table, etc.

        private static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection($"Data Source={ DB_FILEPATH }; Version = 3;");
            // Open the connection:
            sqlite_conn.Open();

            return sqlite_conn;
        }
        private static Tuple<bool, int> ExecNonQuery(string _sql)
        {
            SQLiteConnection conn = null;
            int rows_affected = 0;
            try
            {
                conn = CreateConnection();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _sql;
                    rows_affected = cmd.ExecuteNonQuery();
                }
                return Tuple.Create(true, rows_affected);
            }
            catch (Exception ex)
            {
                //TODO: Handle err
                return Tuple.Create(false, rows_affected);
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
            }
        }
        private static Tuple<bool, int> ExecNonQueryTransaction(ICollection<string> _sqls)
        {
            SQLiteConnection conn = null;
            SQLiteTransaction tran = null;
            int rows_affected = 0;
            try
            {
                conn = CreateConnection();
                tran = conn.BeginTransaction();
                foreach (string sql in _sqls)
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteScalar();
                    }
                }
                tran.Commit();
                return Tuple.Create(true, rows_affected);
            }
            catch (Exception ex)
            {
                //TODO: Handle err
                tran?.Rollback();
                return Tuple.Create(false, rows_affected);
            }
            finally
            {
                tran?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }
        private static DataTable ExecReader(string _sql)
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

        /// Public methods
        public static bool InitializeTables()
        {
            int current_version = 0;
            try
            {
                var queries = new string[]
                {
                    $@" CREATE TABLE IF NOT EXISTS `appconfig` (
                        `id` INTEGER NOT NULL UNIQUE,
                        `name` TEXT NOT NULL,
                        `value` TEXT NOT NULL,
                        `ticks_created`	DATETIME DEFAULT CURRENT_TIMESTAMP,
                        `ticks_updated`	DATETIME DEFAULT CURRENT_TIMESTAMP,
                        `active` SMALLINT NOT NULL DEFAULT 1,
                        PRIMARY KEY(`id` AUTOINCREMENT)
                    );",
                    $@" INSERT INTO `app_config` ( `name`, `value` )
                        VALUES ( 'test', 'dummy' )
                        ON CONFLICT(`name`) DO NOTHING;
                    "
                };
                ExecNonQueryTransaction(queries);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Handle err db
                return false;
            }
        }
        public static string BuildQuery_AppConfig(string _name, string _value, bool _isUpdate)
        {
            string result = $@"
                INSERT INTO `app_config` ( `name`, `value` )
                VALUES ( 'test', 'dummy' )
                ON CONFLICT(`name`) DO ";

            if (_isUpdate)
                result += $"UPDATE SET `_name` = { _value }, `ticks_updated` = CURRENT_TIMESTAMP ;";
            else
                result += "NOTHING ;";

            return result;
        }
    }
}
