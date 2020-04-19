using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        [Display(Name = "Species")]
        public string SpeciesName { get; set; }
        [NotMapped]
        public List<Destination> BestDestinations { get; set; }
        [NotMapped]
        public CalendarBySpecies Calendar { get; set; }
    }
}
