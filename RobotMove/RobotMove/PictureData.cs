using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMove
{
    public class PictureData
    {
        #region Variables
        private Bitmap _picture;
        private int _numberCase;
        private string _nameCase;
        #endregion

        #region Propertys
        public Bitmap Picture { get => _picture; set => _picture = value; }
        public int NumberCase { get => _numberCase; set => _numberCase = value; }
        public string NameCase { get => _nameCase; set => _nameCase = value; }
        #endregion

        #region Constructor
        public PictureData(Bitmap pPicture, int pNumberCase, string pNameCase)
        {
            this.Picture = pPicture;
            this.NumberCase = pNumberCase;
            this.NameCase = pNameCase;
        }
        #endregion

    }
}
