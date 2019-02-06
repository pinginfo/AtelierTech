/*
 *  Author      : Guillaume Pin 
 *  Date        : 24-01-2019
 *  Project     : AnalyseRealTime
 *  Version     : 1.0
 *  File        : PictureData.cs
 *  description : 
 */

using System.Drawing;

namespace RobotMoveWForm
{
    public class PictureData
    {
        private const string DEFAULT_NAME = "Default name";

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
        public PictureData(Bitmap pPicture, int pNumberCase, string pNameCase = DEFAULT_NAME)
        {
            this.Picture = pPicture;
            this.NumberCase = pNumberCase;
            this.NameCase = pNameCase;
        }
        #endregion

    }
}
