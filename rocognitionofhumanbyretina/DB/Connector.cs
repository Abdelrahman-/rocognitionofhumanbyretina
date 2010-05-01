using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace rocognitionofhumanbyretina.DB
{
    class Connector
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public List<Peoples> ConnectLinqDBInterface()
        {
            
            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Peoples> peo = db.GetTable<Peoples>();
            IQueryable<Peoples> custQuery =
            from cust in peo //where cust.Name == "Труш"
            select cust;
            int i = 0;
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

        public void AddRecordLinqToSQL(String fName, String sName, String surName, System.Drawing.Image imageOne, System.Drawing.Image imageTwo, double valFirst, double valSecond)
        {
            
            DataContext db = new DataContext
                (System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");
            Peoples newCust = new Peoples();

            MemoryStream msOne = new MemoryStream();
            byte[] bArrOne = null;
            imageOne.Save(msOne, ImageFormat.Jpeg);
            bArrOne = msOne.GetBuffer();
            MemoryStream msTwo = new MemoryStream();
            byte[] bArrTwo = null;
            imageTwo.Save(msTwo, ImageFormat.Jpeg);
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
