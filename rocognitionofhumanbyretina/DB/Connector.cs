using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace rocognitionofhumanbyretina.DB
{
    class Connector
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private SqlConnection con;
        
        public void init()
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;"+
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

        public bool addRecordToDB(int id,String fName,String sName,System.Drawing.Image imageOne,System.Drawing.Image imageTwo,double valFirst,double valSecond)
        {
            MemoryStream msOne=new MemoryStream();
            Byte[] bArrOne=null;
            imageOne.Save(msOne,System.Drawing.Imaging.ImageFormat.Jpeg);
            bArrOne=msOne.GetBuffer();
            MemoryStream msTwo=new MemoryStream();
            Byte[] bArrTwo=null;
            imageTwo.Save(msTwo,System.Drawing.Imaging.ImageFormat.Jpeg);
            bArrTwo=msTwo.GetBuffer();

            con = new SqlConnection("Data Source=.\\SQLEXPRESS;" +
    "AttachDbFilename=|DataDirectory|\\Database1.mdf;" +
    "Integrated Security=True;" +
    "User Instance=True");
            
            sqlCommand.Connection = con;
            //sqlCommand=new SqlCommand("INSERT INTO test(id,firstName,secondName,figureCornea,figureDeployedCornea,tokenOne,tokenTwo) values({0},'{1}','{2}',{3},{4},{5},{6}",con);
            sqlCommand.CommandText =string.Format("INSERT INTO test(id,firstName,secondName,figureCornea,figureDeployedCornea,tokenOne,tokenTwo) values({0},'{1}','{2}',@imOne,@imTwo,{3},{4})",
                id,fName,sName, valFirst,valSecond);
            sqlCommand.Parameters.Add("@imOne",SqlDbType.Image).Value=bArrOne;
            sqlCommand.Parameters.Add("@imTwo",SqlDbType.Image).Value=bArrTwo;
            con.Open();
            
            sqlCommand.ExecuteNonQuery();
            
            con.Close();
            return false;
        }
    }
}
