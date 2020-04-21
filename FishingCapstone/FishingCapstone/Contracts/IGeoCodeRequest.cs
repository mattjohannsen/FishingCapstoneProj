using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishingCapstone.Models;

namespace FishingCapstone.Contracts
{
    public interface IGeoCodeRequest
    {
        Task<GeoLocation> GetGeoLocation(string address);
    }
}
