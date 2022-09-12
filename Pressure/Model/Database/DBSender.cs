using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Pressure.Model.Database
{
    public class DBSender
    {
        public DBSender()
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlConnection.Open();
            if(SqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("DBSender");
            }
        }
        private SqlConnection SqlConnection = null;
        public string Safe { private get; set; }
        public string Type { private get; set; }

        public void SendToDB()
        {
            SqlCommand send = new SqlCommand($"INSERT INTO [PressureTable] (Values, Type) VALUES (@Values, @Type)", SqlConnection);
            send.Parameters.AddWithValue("Values", Safe);
            send.Parameters.AddWithValue("Type", Type);
            var resultOfCommand = send.ExecuteNonQuery();
            MessageBox.Show(resultOfCommand.ToString());
        }
    }
}
