using Projection.Classes.Utilities;
using System;
using System.Drawing;
using System.IO;

namespace Projection_Library.Classes.Data
{
    [Serializable]
    public class Slide
    {
        private string title;
        private byte[] img;

        public byte[] GetImageBytes() { return img; }
        public Image GetImage() { return Utility.BytesToImage(img); }

        public string GetTitle() { return title; }

        public Slide()
        {

        }
        public Slide(string title, byte[] img)
        {
            this.title = title;
            this.img = img;
        }
        public Slide(string title, string imgPath)
        {
            this.title = title;
            byte[] data = File.ReadAllBytes(imgPath);
            this.img = data;
        }
        public Slide(string title, Image img)
        {
            this.title = title;
            this.img = Utility.ImageToBytes(img);
        }
        public Slide(Image img)
        {
            title = "Untitled";
            this.img = Utility.ImageToBytes(img);
        }

        public Slide(byte[] img)
        {
            title = "Untitled";
            this.img = img;
        }
        public Slide(string filePath)
        {
            title = "Untitled";
            byte[] data = File.ReadAllBytes(filePath);
            this.img = data;
        }
    }
}
