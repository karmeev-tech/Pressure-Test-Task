using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Pressure.VM
{
    public class DatabaseVM : INotifyPropertyChanged
    {
        public class Item
        {
            public Item(string iD, string values, string type)
            {
                ID = iD;
                Values = values;
                Type = type;
            }

            public string ID { get; set; }
            public string Values { get; set; }
            public string Type { get; set; }
        }
        public DatabaseVM()
        {
            SqlDataReader dataReader = null;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PressureTable", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    DataGridDB.Add(new Item(Convert.ToString(dataReader["id"]),
                        Convert.ToString(dataReader["Values"]),
                        Convert.ToString(dataReader["Type"])));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка. Результат: " + ex);
            }
            finally
            {
                if(dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                OnPropertyChanged("DataGridDB");
            }
        }
        private List<Item> _dataGridDB = new List<Item>();
        public List<Item> DataGridDB
        {
            get { return _dataGridDB; }
            private set { _dataGridDB = value;}
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
