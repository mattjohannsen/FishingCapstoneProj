using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class CalendarRow
    {
        public Destination Destination { get; set; }

        public Species Species { get; set; }

        public string[] MonthlyRatings { get; set; }
    }
}
