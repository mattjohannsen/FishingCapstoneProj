using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class CalendarByMonthRow
    {
        public Month Month { get; set; }
        public Rating Rating { get; set; }
        public Destination Destination { get; set; }
        public List<Species> BestSpeciesForMonth { get; set; }

        public string[] SpeciesRatings { get; set; }
    }
}
