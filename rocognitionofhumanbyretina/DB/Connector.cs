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

        public Human GetHumansInfo(int id)
        {

            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Human> peo = db.GetTable<Human>();
            
            IQueryable<Human> custQuery =
            from cust in peo
            where cust.HumanId == id
            select cust;
            int i = 0;
            Human tempHumanStorage = new Human();
            foreach (Human cust in custQuery)
            {
                tempHumanStorage=cust;
                custQuery.GetEnumerator().MoveNext();
                i++;
            }
            db.Connection.Close();
            return tempHumanStorage;
        }

        public Peoples GetImagesDataByHumanID(int id)
        {

            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Peoples> peo = db.GetTable<Peoples>();

            IQueryable<Peoples> custQuery =
            from cust in peo
            where cust.id == id
            select cust;
            int i = 0;
            Peoples tempPeoplesStorage = new Peoples();
            foreach (Peoples cust in custQuery)
            {
                tempPeoplesStorage = cust;
                custQuery.GetEnumerator().MoveNext();
                i++;
            }
            db.Connection.Close();
            return tempPeoplesStorage;
        }


        public Human GetHumansInfoBySecondName(string secondName)
        {

            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Human> peo = db.GetTable<Human>();

            IQueryable<Human> custQuery =
            from cust in peo
            where cust.SecondName == secondName
            select cust;
            int i = 0;
            Human tempHumanStorage = new Human();
            foreach (Human cust in custQuery)
            {
                tempHumanStorage = cust;
                custQuery.GetEnumerator().MoveNext();
                i++;
            }
            db.Connection.Close();
            return tempHumanStorage;
        }


        public List<Peoples> GetAllImages()
        {

            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Peoples> peo = db.GetTable<Peoples>();

            IQueryable<Peoples> custQuery =
            from cust in peo
            select cust;
            int i = 0;
            List<Peoples> tempHumanStorage = new List<Peoples>();
            foreach (Peoples cust in custQuery)
            {
                tempHumanStorage.Add(cust);
                custQuery.GetEnumerator().MoveNext();
                i++;
            }
            db.Connection.Close();
            return tempHumanStorage;
        }

        public List<Human> GetAllHumansInfo()
        {

            // Use a connection string.
            DataContext db = new DataContext(System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");

            // Get a typed table to run queries.
            Table<Human> peo = db.GetTable<Human>();

            IQueryable<Human> custQuery =
            from cust in peo
            select cust;
            int i = 0;
            List<Human> tempHumanStorage = new List<Human>();
            foreach (Human cust in custQuery)
            {
                tempHumanStorage.Add(cust);
                custQuery.GetEnumerator().MoveNext();
                i++;
            }
            
            db.Connection.Close();
            return tempHumanStorage;
        }

        public void addNewHumanInfoToDB(Int32 HumanID, Image imageOne, Image imageTwo, byte[] valToken1DOne, byte[] valToken1DTwo, byte[] valToken2DOne, byte[] valToken2DTwo, string EyeType)
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
            newCust.ImageFull = (byte[])bArrOne;
            newCust.ImagePart = (byte[])bArrTwo;
            newCust.Token1D_AttrOne = valToken1DOne;
            newCust.Token2D_AttrOne = valToken2DOne;
            newCust.Token1D_AttrTwo = valToken1DTwo;
            newCust.Token2D_AttrTwo = valToken2DTwo;
            newCust.EyeType = EyeType;
            newCust.HumanId = HumanID;
            Table<Peoples> peo = db.GetTable<Peoples>();
            peo.InsertOnSubmit(newCust);
            db.SubmitChanges();
            db.Connection.Close();
        }

        public void addNewHumanToDB(String fName, String sName, String surName)
        {
            DataContext db = new DataContext
            (System.Windows.Forms.Application.StartupPath + "\\resources\\PeopleDB.mdf");
            Human newCust = new Human();
            newCust.Name = fName;
            newCust.SecondName = sName;
            newCust.SurName = surName;
            Table<Human> hum = db.GetTable<Human>();
            hum.InsertOnSubmit(newCust);
            db.SubmitChanges();
            db.Connection.Close();
        }
    }
}
