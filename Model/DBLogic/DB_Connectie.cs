using System;
using System.Data;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Model.DBLogic
{
    public class DB_Connectie
    {
        private MySqlDataReader rdr;
        private DataTable dt;
        private DataRow[] result;
        public DB_Connectie(string query)
        {
            string connStr = "server=localhost;user=root;database=nos;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                
                // rdr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                // var rows = dt.AsEnumerable().ToArray();
                this.result = dt.AsEnumerable().ToArray();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DataRow[] Get_Result()
        {
            return this.result;
        }
    }
}