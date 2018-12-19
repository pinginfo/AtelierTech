/*
 *  Author      : Guillaume Pin 
 *  Date        : 12-12-2018
 *  Project     : AnalyseRealTime
 *  Version     : 1.0
 *  File        : AnalyseFrame.cs
 *  description : 
 */

using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace RobotMove
{
    public class AnalysePicture
    {

        #region Constants
        const int DEFAUL_SIZE = 50;
        #endregion

        #region Variables
        private Image<Bgr, byte> pictureInput;
        private Image<Gray, byte> pictureOutput;
        private Size _size;
        private string[] _directionName = new string[] { "Haut à gauche", "Haut", "Haut à droite", "Gauche", "Milieu", "Droite", "Bas à gauche", "Bas", "Bas à droite" };
        #endregion

        #region Structures
        public struct InfoPicture
        {
            public string nameDirection;
            public int numberCell;
            public Bitmap picture;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Main constructor of this class
        /// </summary>
        /// <param name="size">Size of the picture to analyse</param>
        public AnalysePicture(Size size)
        {
            this._size = size;
        }
        public AnalysePicture() : this(new Size(DEFAUL_SIZE, DEFAUL_SIZE))
        {

        }
        #endregion

        #region methods
        /// <summary>
        /// Method for update the picture to analyse
        /// </summary>
        /// <param name="picture">new picture in Bitmap</param>
        public Image<Bgr, byte> setPicture(Bitmap picture)
        {
            return new Image<Bgr, byte>(new Bitmap((Image)picture, this._size));
        }

        /// <summary>
        /// Method for transforming the image into black and white
        /// </summary>
        /// <returns>A </returns>
        public Image<Gray, byte> transformPicture(Image<Bgr, byte> picture)
        {
            // Create a new picture 
            Image<Gray, byte> result = picture.Convert<Gray, byte>().ThresholdBinary(new Gray(150), new Gray(210));
            // Use the librairy for find the contours 
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat hier = new Mat();
            // Find the contours of picture
            CvInvoke.FindContours(result, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            // Create a new picture void
            Image<Gray, byte> imgout = new Image<Gray, byte>(result.Width, result.Height, new Gray(0));
            // Draw the contours of the picture
            CvInvoke.DrawContours(imgout, contours, -1, new MCvScalar(255, 0, 0), -1);
            // Return the picture in bitmap
            //return result.Bitmap;
            return result;
        }

        /// <summary>
        /// Method for find the position in the grid (3x3)
        /// </summary>
        /// <param name="pos">The position of the pixel</param>
        /// <returns>The number of the cell</returns>
        private int getIndexOfCase(Point pos)
        {
            int sizeOfCase = _size.Height / 3;
            return (pos.Y / sizeOfCase) * 3 + (pos.X / sizeOfCase);
        }

        /// <summary>
        /// Method for receive the number of white pixel in all cell
        /// </summary>
        /// <returns>A table with the number of the white pixel in all cell</returns>
        private int[] analyseTheGrid()
        {
            int size = this.pictureOutput.Width;
            int sizeZone = size / 3;
            int[] tableOfDirection = new int[9];
            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    Color pixelColor = this.pictureOutput.Bitmap.GetPixel(i, y);
                    if (pixelColor.G != 0)
                    {
                        int result = getIndexOfCase(new Point(i, y));
                        if (result >= 0 && result < 9) tableOfDirection[result]++;
                    }
                }
            }
            return tableOfDirection;
        }

        /// <summary>
        /// Method for find the cell with the maximum of white pixels
        /// </summary>
        /// <returns>The number of the cell</returns>
        public int getCellUsed(int[] tableCell)
        {
            int maxValue = tableCell.Max();
            int maxIndex = tableCell.ToList().IndexOf(maxValue);
            return maxIndex;
        }

        /// <summary>
        /// Return all info of the picture
        /// </summary>
        /// <param name="picture">The picture to analyse</param>
        /// <returns>All info from the picture</returns>
        public InfoPicture getDirection(Bitmap picture)
        {
            this.pictureInput = setPicture(picture);
            this.pictureOutput = transformPicture(this.pictureInput);
            int[] tableCell = analyseTheGrid();
            int CellUsed = getCellUsed(tableCell);
            return new InfoPicture() { nameDirection = _directionName[CellUsed], numberCell = CellUsed, picture = this.pictureOutput.Bitmap };
        }
        #endregion
    }
}
