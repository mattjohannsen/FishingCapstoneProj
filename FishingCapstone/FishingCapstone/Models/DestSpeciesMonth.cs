using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class DestSpeciesMonth
    {
        public int DestSpeciesMonthId { get; set; }
        [ForeignKey("Destination")]
        public int DSMDestinationId { get; set; }
        public Destination Destination { get; set; }
        [ForeignKey("Species")]
        public int DSMSpeciesId { get; set; }
        public Species Species { get; set; }
        [ForeignKey("Month")]
        public int DSMMonthId { get; set; }
        public Month Month { get; set; }
        [ForeignKey("Rating")]
        public int DSMRatingId { get; set; }
        public Rating Rating { get; set; }
    }
}
