using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace rocognitionofhumanbyretina.DB
{
    [Table(Name = "Human")]
    class Human
    {


        private EntitySet<Peoples> _Peoples;
        public Human()
        {
            this._Peoples = new EntitySet<Peoples>();
        }

        [Association(Storage = "_Peoples", OtherKey = "HumId")]
        public EntitySet<Peoples> Peoples
        {
            get { return this._Peoples; }
            set { this._Peoples.Assign(value); }
        }

        private string _Name;
        [Column(Storage = "_Name")]
        public string Name
        {
            get
            {
                try
                {
                    return this._Name;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Name! - " + e.Message);
                }
                return this._Name;
            }
            set
            {
                this._Name = value;
            }

        }

        private string _SecondName;
        [Column(Storage = "_SecondName")]
        public string SecondName
        {
            get
            {
                try
                {
                    return this._SecondName;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в SecondName! - " + e.Message);
                }
                return this._SecondName;
            }
            set
            {
                this._SecondName = value;
            }
        }

        private string _SurName;
        [Column(Storage = "_SurName")]
        public string SurName
        {
            get
            {
                try
                {
                    return this._SurName;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в SurName! - " + e.Message);
                }
                return this._SurName;
            }
            set
            {
                this._SurName = value;
            }
        }
    }
}
