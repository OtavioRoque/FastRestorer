using System.Data;
using System.Windows;
using FastRestorer.Config;
using Microsoft.Data.SqlClient;

#pragma warning disable CS8603

namespace FastRestorer.Services
{
    /// <summary>
    /// Contains utility methods to access the database.
    /// Useful for not having to open a SqlConnection manually.
    /// </summary>
    /// 
    /// <remarks>
    /// Use with the alias SQL.MethodName().
    /// </remarks>
    public static class SqlExecutor
    {
        private static readonly string _connectionString = ConfigLoader.GetConnectionString();

        /// <summary>
        /// Read data from the database and fill a DataTable with the results.
        /// </summary>
        /// 
        /// <param name="sql">
        /// The query command to be executed.
        /// </param>
        /// 
        /// <returns>
        /// A DataTable filled with the query results.
        /// </returns>
        public static DataTable FillDataTable(string sql)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(sql, conn);
                using var adapter = new SqlDataAdapter(cmd);

                var tabela = new DataTable();
                adapter.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Executes a command that does not return any data (INSERT, DELETE, RESTORE).
        /// </summary>
        /// 
        /// <param name="sql">
        /// The non query command to be executed.
        /// </param>
        /// 
        /// <returns>
        /// 1 if the command was executed successfully, -1 if there was an error.
        /// </returns>
        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(sql, conn);

                cmd.CommandTimeout = 0;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
