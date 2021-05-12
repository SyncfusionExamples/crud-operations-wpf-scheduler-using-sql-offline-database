using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWPF
{
    public static class ConnectDB
    {
        public static string ConnectionString
        {
            get
            {
                string currentDir = System.Environment.CurrentDirectory;
                currentDir = currentDir.Substring(0, currentDir.Length - 10);
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + currentDir + @"\MeetingsDB.mdf;Integrated Security=True";
            }
        }
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public static DataTable GetDataTable(string SQL_Text)
        {
            SqlConnection cn_connection = GetDBConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);
            return table;
        }

        public static void ExecuteSQLQuery(string SQLQuery)
        {
            SqlCommand cmd_Command = new SqlCommand(SQLQuery, GetDBConnection());
            cmd_Command.ExecuteNonQuery();
        }

        public static void CloseDBConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
