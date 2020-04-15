using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Photos
    {
        public int PhotosId { get; set; }
        [ForeignKey("Trip")]
        public int PhotoTripId { get; set; }
        public Trip Trip { get; set; }
        public string PhotoCaption { get; set; }
        public string PhotoLat { get; set; }
        public string PhotoLong { get; set; }
        public int PhotoDate { get; set; }
        public string PhotoData { get; set; }

    }
}
