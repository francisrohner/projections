using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projection_Library.Classes
{
    public class Constants
    {
        public static readonly string DEFAULT_TITLE = "Untitled";
        public enum ERROR_CODES
        {
            OK = 0,
            FAILURE = -1,
            FILE_NOT_FOUND = -2
        }
    }
}
