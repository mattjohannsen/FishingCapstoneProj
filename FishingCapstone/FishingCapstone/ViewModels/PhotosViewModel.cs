using FishingCapstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishingCapstone.ViewModels
{
    public class PhotosViewModel
    {
        [Required(ErrorMessage = "Please choose image for Trip Album")]
        [Display(Name = "Photo for Trip Album:")]
        public IFormFile PhotoFile { get; set; }
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
