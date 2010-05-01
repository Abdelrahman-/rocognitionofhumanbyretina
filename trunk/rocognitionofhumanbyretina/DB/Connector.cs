using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;

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


            //sqlCommand.CommandText = string.Format("UPDATE test SET figureCornea=@imOne,figureDeployedCornea=@imTwo where id=2");

            //sqlCommand = new SqlCommand("UPDATE test SET figureCornea=@imOne where id=2", con);
            //sqlCommand.Connection = con;
            sqlCommand = new SqlCommand(string.Format("INSERT INTO test(id,firstName,secondName,figureCornea,figureDeployedCornea,tokenOne,tokenTwo) values({0},'{1}','{2}',@imOne,@imTwo,{3},{4})", id, fName, sName, valFirst, valSecond), con);
            //sqlCommand.CommandText =string.Format("INSERT INTO test(id,firstName,secondName,figureCornea,figureDeployedCornea,tokenOne,tokenTwo) values({0},'{1}','{2}',@imOne,@imTwo,{3},{4})",
              //  id,fName,sName, valFirst,valSecond);
            con.Open();            
            sqlCommand.Parameters.AddWithValue("@imOne", bArrOne);
            sqlCommand.Parameters.AddWithValue("@imTwo", bArrTwo);           
            //sqlCommand.Parameters.Add("@imOne",SqlDbType.Image).Value=bArrOne;
            //sqlCommand.Parameters.Add("@imTwo",SqlDbType.Image).Value=bArrTwo; 
            
            MessageBox.Show(sqlCommand.ExecuteNonQuery().ToString());
            MessageBox.Show(con.Database);
            con.Close();
            return false;
        }

        public List<Peoples> ConnectLinqDBInterface()
        {
            // Use a connection string.
            DataContext db = new DataContext
                (@"c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Peoples> peo = db.GetTable<Peoples>();
            IQueryable<Peoples> custQuery =
            from cust in peo //where cust.Name == "Труш"
            select cust;
            int i=0;
            List<Peoples> tempPeoplesStorage = new List<Peoples>();
            foreach (Peoples cust in custQuery)
            {
            tempPeoplesStorage.Add(cust);
            custQuery.GetEnumerator().MoveNext();
                i++;
            }
            db.Connection.Close();
            return tempPeoplesStorage;
        }
        public void AddRecordLinqToSQL(String fName, String sName,String surName, System.Drawing.Image imageOne, System.Drawing.Image imageTwo, double valFirst, double valSecond)
        {
            DataContext db = new DataContext
                (@"c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\PeopleDB.mdf");
            Peoples newCust = new Peoples();

            MemoryStream msOne = new MemoryStream();
            byte[] bArrOne = null;
            imageOne.Save(msOne, System.Drawing.Imaging.ImageFormat.Jpeg);
            bArrOne = msOne.GetBuffer();
            MemoryStream msTwo = new MemoryStream();
            byte[] bArrTwo = null;
            imageTwo.Save(msTwo, System.Drawing.Imaging.ImageFormat.Jpeg);
            bArrTwo = msTwo.GetBuffer();
            
            newCust.Name = fName;
            newCust.SecondName = sName;
            newCust.SurName = surName;
            newCust.ImageFull = (byte[])bArrOne;
            newCust.ImagePart = (byte[])bArrTwo;
            newCust.Token1D = 1;
            newCust.Token2D = 1;
            Table<Peoples> peo = db.GetTable<Peoples>();
            // Add the customer to the Customers table.
            peo.InsertOnSubmit(newCust);            
            db.SubmitChanges();
            db.Connection.Close();
        }
    }
}
