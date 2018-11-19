using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Projection_Library.Classes.Diagnostic
{
    public class FileLogger : LoggerBase
    {
        public enum FileType
        {
            PLAIN,
            XML, //TODO
            HTML //TODO
        }

        private string filePath = null;
        private FileType log_type;
        
        public FileLogger(string filePath, FileType fileType = FileType.PLAIN)
        {
            this.filePath = filePath;
        }
        public override void Log(LogLevel level, string line)
        {
            if (log_type == FileType.PLAIN)
                LogPlain(level, line);
            else if (log_type == FileType.XML)
                LogXml(level, line);
            else if (log_type == FileType.HTML)
                LogHtml(level, line);
        }        

        public void LogPlain(LogLevel level, string line)
        {
            string strOut = string.Format("");
            File.AppendAllText(filePath, line);
        }
        public void LogXml(LogLevel level, string line)
        {

        }
        public void LogHtml(LogLevel level, string line)
        {
            //System.Windows.Forms.HtmlElement el;
            //System.Windows.Forms.HtmlDocument htDoc = new System.Windows.Forms.HtmlDocument();
            
        }

    }
}
