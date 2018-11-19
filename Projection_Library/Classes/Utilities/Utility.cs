using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Projection.Classes.Utilities
{

    public class Utility
    {
        public enum DataMarker
        {
            STRING,
            PROJECTION,
            FILE
        }
        public static byte[] PrepareData(byte[] data, DataMarker marker)
        {
            byte[] output = new byte[data.Length + 1];
            output[0] = (byte)marker;
            Array.Copy(data, 0, output, 1, data.Length);
            return output;
        }
        public static object Parse(byte[] data_full)
        {
            byte[] data = new byte[data_full.Length - 1];
            Array.Copy(data_full, 1, data, 0, data_full.Length - 1);
            if (data_full[0] == (byte)DataMarker.STRING)
                return Encoding.UTF8.GetString(data);
            else if (data_full[1] == (byte)DataMarker.FILE)
                return data;
            else return null;
        }

        public static byte[] ImageToBytes(Image img)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static Image BytesToImage(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                return Image.FromStream(ms);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor, bool bold = false)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(box.BackColor);
                // Draw text
                if (!bold)
                    g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                else
                {
                    bool needsDisposal = false;
                    Font boldFont = box.Font;
                    if (boldFont.Style != FontStyle.Bold)
                    {
                        boldFont = new Font(boldFont, FontStyle.Bold);
                        needsDisposal = true;
                    }
                    g.DrawString(box.Text, boldFont, textBrush, box.Padding.Left, 0);
                    if (needsDisposal) boldFont.Dispose();
                }
                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));

                borderPen.Dispose();
                borderBrush.Dispose();
                textBrush.Dispose();
                borderPen = null;
                borderBrush = null;
                textBrush = null;
            }
        }

        public static Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



    }
}
