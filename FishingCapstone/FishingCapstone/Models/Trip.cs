using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [ForeignKey("Explorer")]
        public int ExplorerId { get; set; }
        public Explorer Explorer { get; set; }
        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        [Display(Name = "Name of Trip")]
        public string TripName { get; set; }
        [Display(Name = "Guide Service")]
        public string TripGuideService { get; set; }
        [Display(Name = "Month")]
        [ForeignKey("Month")]
        public int TripMonthId { get; set; }
        public Month Month { get; set; }
        [Display(Name = "Trip Start Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? TripStart { get; set; }
        [Display(Name = "Trip Start Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? TripEnd { get; set; }
        [NotMapped]
        public List<Photos> TripPhotos { get; set; }

    }
}
