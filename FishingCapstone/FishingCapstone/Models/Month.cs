using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        [NotMapped]
        public CalendarByMonth CalendarByMonth { get; set; }
        [NotMapped]
        public List<Species> BestSpecies { get; set; }
    }
}
