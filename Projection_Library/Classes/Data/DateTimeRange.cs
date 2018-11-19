using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projection_Library.Classes
{
    [Serializable]
    public class DateTimeRange
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool Intersects(DateTimeRange test)
        {
            if (Start > End || test.Start > test.End)
                throw new Exception();

            if (Start == End || test.Start == test.End)
                return false; // No actual date range

            if (Start == test.Start || End == test.End)
                return true; // If any set is the same time, then by default there must be some overlap. 

            if (Start < test.Start)
            {
                if (End > test.Start && End < test.End)
                    return true; // Condition 1

                if (End > test.End)
                    return true; // Condition 3
            }
            else
            {
                if (test.End > Start && test.End < End)
                    return true; // Condition 2

                if (test.End > End)
                    return true; // Condition 4
            }

            return false;
        }
    }
}
