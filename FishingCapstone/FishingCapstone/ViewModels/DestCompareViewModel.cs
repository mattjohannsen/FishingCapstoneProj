using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingCapstone.Models;

namespace FishingCapstone.ViewModels
{
    public class DestCompareViewModel
    {
        public Destination Destination1 { get; set; }
        public Destination Destination2 { get; set; }
        public Month Month { get; set; }
    }
}
