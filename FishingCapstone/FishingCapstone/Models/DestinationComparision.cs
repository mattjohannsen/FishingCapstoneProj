using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class DestinationComparision
    {
        public Destination Destination2 { get; set; }
        public Month MonthToCompare { get; set; }
        public List<Species> SpeciesList { get; set; }
        public CompareChart CompareChart { get; set; }
    }
}
