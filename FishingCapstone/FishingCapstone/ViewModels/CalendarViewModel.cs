using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingCapstone.Models;

namespace FishingCapstone.ViewModels
{
    public class CalendarViewModel
    {
        public Destination Destination {get; set;}
        public Species Species { get; set; }
        public Month Month { get; set; }
        public Rating Rating { get; set; }

    }
}
