using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string DestinationLat { get; set; }
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
        public Calendar Calendar { get; set; }

    }
}
