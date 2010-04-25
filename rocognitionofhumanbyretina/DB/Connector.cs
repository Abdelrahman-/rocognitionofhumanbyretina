using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace rocognitionofhumanbyretina.DB
{
    class Connector
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        
        public void init()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;"+
                "AttachDbFilename=|DataDirectory|\\Database1.mdf;" +
                "Integrated Security=True;"+
                "User Instance=True");
            con.Open();
            sqlCommand.CommandText = "SELECT * FROM test";
            sqlCommand.Connection = con;
          
            Database1DataSet dataSet = new Database1DataSet();
            dataAdapter.SelectCommand = sqlCommand;

            dataAdapter.Fill(dataSet, "test");
            DataTable dataTable = dataSet.Tables["test"];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MessageBox.Show("Id: " + dataRow["id"]+"Name: "+dataRow["name"]);
            }
        }
    }
}
