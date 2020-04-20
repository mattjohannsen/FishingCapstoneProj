using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Photos
    {
        public int PhotosId { get; set; }
        [Display(Name = "Photo")]
        public string PhotoFile { get; set; }
        [Display(Name = "Trip Name")]
        [ForeignKey("Trip")]
        public int PhotoTripId { get; set; }
        public Trip Trip { get; set; }
        [Display(Name = "Caption")]
        public string PhotoCaption { get; set; }
        [Display(Name = "Lattitude")]
        public string PhotoLat { get; set; }
        [Display(Name = "Longitude")]
        public string PhotoLong { get; set; }
        [Display(Name = "Date Taken")]
        public int PhotoDate { get; set; }
        public string PhotoData { get; set; }

    }
}
