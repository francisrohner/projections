using Projection.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using static Projection_Library.Classes.Constants;

namespace Projection_Library.Classes
{
    [Serializable]
    public class ProjectionManager
    {
        private List<ProjectionObj> projections;
        private ProjectionObj defaultProjection;
        private string name;

        public ProjectionObj GetDefaultProjection()
        {
            return defaultProjection;
        }

        public ProjectionManager(bool testMode = false)
        {
            name = Environment.MachineName;
            projections = new List<ProjectionObj>();
        }

        public ProjectionManager(Image img)
        {
            name = Environment.MachineName;
            projections = new List<ProjectionObj>();            
            defaultProjection = new ProjectionObj(DateTime.Now, DateTime.MinValue, DateTime.MaxValue)
            {
                isDefault = true
            };
            defaultProjection.AddSlide(img);
        }

        public ProjectionManager(ProjectionObj proj)
        {
            projections = new List<ProjectionObj>();
            defaultProjection = proj;
        }

        private List<ProjectionObj> GetProjectionsForDate(DateTime date)
        {
            List<ProjectionObj> ret = new List<ProjectionObj>();
            foreach (ProjectionObj proj in projections)
                if (proj.scheduledDateTimes.First().Start.Date.Equals(date.Date))
                    ret.Add(proj);
            return ret;
        }

        public void DeleteProjection(ProjectionObj projection)
        {
            if (projection.isDefault)
                return;
            projections.Remove(projection);
        }

        public void AddProjection(ProjectionObj projection)
        {
            if (projection.isDefault)
            {
                defaultProjection = projection;
                Console.WriteLine("Default projection replaced");
            }
            else
                projections.Add(projection);
        }

        //Return the projection that is currently scheduled
        public ProjectionObj GetCurrentProjection()
        {
            DateTimeRange targetRange = new DateTimeRange(DateTime.Now, DateTime.Now.AddSeconds(1));
            foreach (ProjectionObj proj in projections)
            {
                if (proj.scheduledDateTimes.First().Intersects(targetRange))
                    return proj;
            }
            return null;
        }

        public bool HasOverlappingProjection(ProjectionObj projection)
        {
            foreach (ProjectionObj proj in projections)
            {
                if (projection.scheduledDateTimes.First().Intersects(proj.scheduledDateTimes.First()))
                    return true;
            }
            return false;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName() { return name;  }
        public bool Serialize(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                BinaryFormatter serializer = new BinaryFormatter();
                FileStream stream = new FileStream(filePath, FileMode.CreateNew);
                serializer.Serialize(stream, this);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public byte[] Serialize()
        {
            try
            {
                BinaryFormatter serizlizer = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                serizlizer.Serialize(stream, this);
                stream.Close();
                return stream.GetBuffer();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static ProjectionManager Deserialize(byte[] data)
        {
            try
            {
                MemoryStream stream = new MemoryStream(data);
                BinaryFormatter deserializer = new BinaryFormatter();
                ProjectionManager ret = (ProjectionManager)deserializer.Deserialize(stream);                
                stream.Close();
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public static ProjectionManager Deserialize(string filePath)
        {
            if (!File.Exists(filePath))
                return null; //no file to deserialize
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Open);
                BinaryFormatter deserializer = new BinaryFormatter();
                ProjectionManager ret = (ProjectionManager)deserializer.Deserialize(stream);                
                stream.Close();
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

    }
}
