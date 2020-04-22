using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        [Display(Name = "Destination")]
        public string DestinationName { get; set; }
        [Display(Name = "Lattitude")]
        public string DestinationLat { get; set; }
        [Display(Name = "Longitude")]
        public string DestinationLong { get; set; }
        [NotMapped]
        public List<Species> AvailableSpecies { get; set; }
        [NotMapped]
        public List<DestSpeciesMonth> DSMCalender { get; set; }
        [NotMapped]
        public List<Month> Month { get; set; }
        [NotMapped]
        public List<Rating> Rating { get; set; }
        [NotMapped]
        public CalendarByDestination Calendar { get; set; }
        [NotMapped]
        public DestinationComparision DestinationComparision { get; set; }
        [NotMapped]
        public int MonthId { get; set; }
        [NotMapped]
        public int DestinationToCompare { get; set; }

    }
}
