using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace rocognitionofhumanbyretina.DB
{
    [Table(Name = "Peoples")]
    class Peoples
    {
        private Int32 _id;
        [Column(IsDbGenerated=true,IsPrimaryKey = true,Storage = "_id")]
        public Int32 id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }

        }

        private Int32 _HumId;
        [Column(Storage = "_HumId",DbType="Int NOT NULL IDENTITY")]
        public Int32 HumId
        {
            get
            {
                return this._HumId;
            }
            set
            {
                this._HumId = value;
            }

        }

        private byte[] _ImageFull;
        [Column(Storage = "_ImageFull")]
        public byte[] ImageFull
        {
            
            get
            {
                try
                {
                    return this._ImageFull;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста при конферте байтов имейджа! - " + e.Message);
                }
                return this._ImageFull;
            }
            set
            {
                this._ImageFull = value;
            }
        
        }

        private byte[] _ImagePart;
        [Column(Storage = "_ImagePart")]
        public byte[] ImagePart
        {
            get
            {
                try
                {
                    return this._ImagePart;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста при конферте байтов имейджа! - " + e.Message);
                }
                return this._ImagePart;
            }
            set
            {
                this._ImagePart = value;
            }

        }

        private double _Token1D;
        [Column(Storage = "_Token1D")]
        public double Token1D
        {
            get
            {
                try
                {
                    return this._Token1D;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token1d! - " + e.Message);
                }
                return this._Token1D;
            }
            set
            {
                this._Token1D = value;
            }

        }

        private double _Token2D;
        [Column(Storage = "_Token2D")]
        public double Token2D
        {
            get
            {
                try
                {
                    return this._Token2D;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token2d! - " + e.Message);
                }
                return this._Token2D;
            }
            set
            {
                this._Token2D = value;
            }

        }

    }
}
