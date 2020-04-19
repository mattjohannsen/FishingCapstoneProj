using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }
        [Display(Name = "Species")]
        public string SpeciesName { get; set; }
    }
}
