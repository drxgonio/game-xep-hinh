using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    class ExtensionMethods
    {
        //Load an image from a Path
       public static Image GetImageFromFile(string path)
        {
             Image img = null;
             FileStream tempImg=null;
             tempImg = new FileStream(path, FileMode.Open);
             img = Image.FromStream(tempImg);
             tempImg.Close();
             tempImg.Dispose();         
            return img;
        }

        //Split an image to many picture as 3x3, 4x4
       public static List<Image> SplitPicture()
       {
           List<Image> listImage = new List<Image>();
           Image img = Resize(ExtensionMethods.GetImageFromFile(GameProperties.IMAGE_SOURCE));
           //Image img = Image.FromFile(GameProperties.IMAGE_SOURCE);
           
           int smallPictureWidth = (int)((double)img.Width / GameProperties.GAME_COLUMN);
           int slammPictureHeight = (int)((double)img.Height / GameProperties.GAME_ROW);
           Bitmap[,] bmps = new Bitmap[GameProperties.GAME_ROW, GameProperties.GAME_COLUMN];
           for (int i = 0; i < GameProperties.GAME_ROW; i++)
           {
               for (int j = 0; j < GameProperties.GAME_COLUMN; j++)
               {
                   bmps[i, j] = new Bitmap(smallPictureWidth, slammPictureHeight);
                   Graphics g = Graphics.FromImage(bmps[i, j]);
                   g.DrawImage(img, new Rectangle(0, 0, smallPictureWidth, slammPictureHeight), new Rectangle(j * smallPictureWidth, i * slammPictureHeight, smallPictureWidth, slammPictureHeight), GraphicsUnit.Pixel);
                   g.Dispose();
                   listImage.Add(bmps[i, j]);
               }
           }
           return listImage;
       }

       private static Image Resize(Image oldImage)
       {
           Bitmap newImage = new Bitmap(GameProperties.PANEL_WIDTH, GameProperties.PANEL_HEIGHT);
           Graphics g = Graphics.FromImage(newImage);
           g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
           g.DrawImage(oldImage, 0, 0, GameProperties.PANEL_WIDTH, GameProperties.PANEL_HEIGHT);
           return newImage;
       }
    }
   
}
