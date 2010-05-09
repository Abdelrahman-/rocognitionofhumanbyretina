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

        private Int32 _HumanId;
        [Column(Storage = "_HumanId")]
        public Int32 HumanId
        {
            get
            {
                return this._HumanId;
            }
            set
            {
                this._HumanId = value;
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

        private double _Token1D_AttrOne;
        [Column(Storage = "_Token1D_AttrOne")]
        public double Token1D_AttrOne
        {
            get
            {
                try
                {
                    return this._Token1D_AttrOne;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token1d! - " + e.Message);
                }
                return this._Token1D_AttrOne;
            }
            set
            {
                this._Token1D_AttrOne = value;
            }

        }

        private double _Token2D_AttrOne;
        [Column(Storage = "_Token2D_AttrOne")]
        public double Token2D_AttrOne
        {
            get
            {
                try
                {
                    return this._Token2D_AttrOne;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token2d! - " + e.Message);
                }
                return this._Token2D_AttrOne;
            }
            set
            {
                this._Token2D_AttrOne = value;
            }

        }

        private double _Token1D_AttrTwo;
        [Column(Storage = "_Token1D_AttrTwo")]
        public double Token1D_AttrTwo
        {
            get
            {
                try
                {
                    return this._Token1D_AttrTwo;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token1d! - " + e.Message);
                }
                return this._Token1D_AttrTwo;
            }
            set
            {
                this._Token1D_AttrTwo = value;
            }

        }

        private double _Token2D_AttrTwo;
        [Column(Storage = "_Token2D_AttrTwo")]
        public double Token2D_AttrTwo
        {
            get
            {
                try
                {
                    return this._Token2D_AttrTwo;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в Token2d! - " + e.Message);
                }
                return this._Token2D_AttrTwo;
            }
            set
            {
                this._Token2D_AttrTwo = value;
            }

        }

        private string _EyeType;
        [Column(Storage = "_EyeType")]
        public string EyeType
        {
            get
            {
                try
                {
                    return this._EyeType;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка каста в EyeType! - " + e.Message);
                }
                return this._EyeType;
            }
            set
            {
                this._EyeType = value;
            }

        }
    }
}
