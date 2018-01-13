using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using zaliczenie_ld_308.Entities;

namespace zaliczenie_ld_308.Controller
{
    class MSA : Controller
    {
        public MSA()
        {
            string myConnectionString = "Database="+this.database+";Data Source="+this.host+";User Id="+this.username+";Password="+this.password+"";
            this.connection = new MySqlConnection(myConnectionString);
            try
            {
                this.connection.Open();
            }
            catch (Exception ex)
            {
                this.CatchException(ex);
            }
        }
        ~MSA()
        {
            this.Close();
        }

        private MySqlConnection connection;

        public void Close()
        {
            this.connection.Close();
        }
        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, this.connection);
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                this.CatchException(ex);
                return null;
            }
        }
        public bool ExecuteNonQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, this.connection);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                this.CatchException(ex);
                return false;
            }
        }
    }
}
