using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Pressure.Model.Database
{
    public class DBSender
    {
        public string Safe { private get; set; }
        public string Type { private get; set; }

        public void SendToDB()
        {
            SqlConnection SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlConnection.Open();
            SqlCommand send = new SqlCommand("INSERT INTO [PressureTable] VALUES (@Values, @Type)", SqlConnection);
            send.Parameters.AddWithValue("Values", Safe);
            send.Parameters.AddWithValue("Type", Type);
            var resultOfCommand = send.ExecuteNonQuery();
            MessageBox.Show("База данных обновлена. Результат: " + resultOfCommand.ToString());
        }
    }
}
