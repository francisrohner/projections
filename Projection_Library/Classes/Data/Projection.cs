using Projection_Library.Classes;
using Projection_Library.Classes.Data;
using Projection.Classes;
using Projection.Classes.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projection.Classes
{

    [Serializable]
    public class ProjectionObj
    {

        public int id;
        public List<DateTimeRange> scheduledDateTimes;
        public DateTime creationDt;
        private List<Slide> slides;

        public bool isDefault;
        public bool showOnce;
        public string title;
        public TimeSpan changeInterval;

        #region Serialization
        public static ProjectionObj Deserialize(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();                
                return (ProjectionObj)formatter.Deserialize(ms);
            }
            catch (Exception)
            {                
                return null;
            }
        }

        public static ProjectionObj Deserialize(out string ret, string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = File.Open(filePath, FileMode.Open);
                ret = "Success";
                return (ProjectionObj)formatter.Deserialize(fs);
            }
            catch (Exception ex)
            {
                ret = "Failure: " + ex.ToString();
                return null;
            }
        }

        public byte[] Serialize(string filePath = null)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                if (filePath != null)
                    File.WriteAllBytes(filePath, ms.ToArray());                
                return ms.ToArray();
            }
            catch (Exception)
            {                
                return null;
            }
        }
        #endregion Serialization

        //???
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool eq = true;
            ProjectionObj other = (ProjectionObj)obj;
            List<Image> otherSlides = other.GetImages();

            if (otherSlides.Count() != slides.Count())
                eq = false;
            if (!other.title.Equals(title))
                eq = false;

            if (!other.creationDt.Equals(creationDt))
                eq = false;
            if (!eq)
                Console.WriteLine("Mismatch");
            return eq;
        }

        public List<Image> GetImages()
        {
            List<Image> images = new List<Image>();
            for (int i = 0; i < slides.Count(); i++)
                images.Add(Utility.BytesToImage(slides[i].GetImageBytes()));
            return images;
        }

        #region Constructors
        public ProjectionObj(DateTime startDt, DateTime endDt)
        {
            this.title = Constants.DEFAULT_TITLE;
            this.scheduledDateTimes = new List<DateTimeRange>();
            scheduledDateTimes.Add(new DateTimeRange(startDt, endDt));
            changeInterval = new TimeSpan(0, 0, 20); //20s change interval default
            this.showOnce = true;
            this.creationDt = DateTime.Now;

            slides = new List<Slide>();
        }

        public ProjectionObj(DateTime creationDt, DateTime startDt, DateTime endDt)
        {
            title = Constants.DEFAULT_TITLE;
            scheduledDateTimes = new List<DateTimeRange>();
            scheduledDateTimes.Add(new DateTimeRange(startDt, endDt));
            changeInterval = new TimeSpan(0, 0, 20); //20s change interval default
            showOnce = true;
            this.creationDt = creationDt;

            slides = new List<Slide>();
        }


        public ProjectionObj(DateTime creationDt, DateTime startDt, DateTime endDt, List<Image> slides)
        {
            title = Constants.DEFAULT_TITLE;
            scheduledDateTimes.Add(new DateTimeRange(startDt, endDt));
            changeInterval = new TimeSpan(0, 0, 20); //20s change interval default
            this.creationDt = creationDt;
            this.slides = new List<Slide>();
            showOnce = true;
            //Retrieve bytes from Image object list
            for (int i = 0; i < slides.Count(); i++)
                this.slides.Add(new Slide(slides[i]));

        }
        //TODO_LATER finish
        public ProjectionObj(DateTime creationDt, DateTime startDt, DateTime endDt, List<string> slideFilePaths)
        {
            title = Constants.DEFAULT_TITLE;
            scheduledDateTimes.Add(new DateTimeRange(startDt, endDt));
            this.creationDt = creationDt;
            changeInterval = new TimeSpan(0, 0, 20); //20s change interval default
            slides = new List<Slide>();
            List<byte[]> lstImgBytes = new List<byte[]>();
            for (int i = 0; i < slideFilePaths.Count(); i++)
                if (!String.IsNullOrEmpty(slideFilePaths[i]) && File.Exists(slideFilePaths[i]))
                {
                    try
                    {
                        lstImgBytes.Add(File.ReadAllBytes(slideFilePaths[i]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            this.showOnce = true;
        }
        #endregion Constructors

        #region AddSlide
        public void AddSlide(string filePath)
        {
            //slides.Add(File.ReadAllBytes(filePath));
            byte[] data = File.ReadAllBytes(filePath);
            slides.Add(new Slide(Constants.DEFAULT_TITLE, data));
        }

        public void AddSlide(byte[] bytes)
        {         
            slides.Add(new Slide(Constants.DEFAULT_TITLE, bytes));
        }

        public void AddSlide(Image img)
        {            
            slides.Add(new Slide(Constants.DEFAULT_TITLE, img));
        }

        public void AddSlide(string title, Image img)
        {
            slides.Add(new Slide(title, img));
        }

        public void AddSlide(string title, byte[] img)
        {
            slides.Add(new Slide(title, img));
        }

        public void AddSlide(string title, string filePath)
        {            
            slides.Add(new Slide(title, filePath));
        }
        #endregion AddSlide

        public override string ToString()
        {
            //TODO IMPROVE
            string strOut = "Display Start: " + scheduledDateTimes.First().Start.ToString("yyyy/MM/dd hh:mm:ss");
            strOut += "\nDisplay End: " + scheduledDateTimes.First().End.ToString("yyyy/MM/dd hh:mm:ss");
            //strOut += "\nDisplay File: " + imgFilePath;
            return strOut;
        }
    }
}
