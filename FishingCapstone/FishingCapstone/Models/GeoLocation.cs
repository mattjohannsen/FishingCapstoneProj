
namespace FishingCapstone.Models
{

    public class GeoLocation
    {
        public GeoResult[] results { get; set; }
        public string status { get; set; }
    }

    public class GeoResult
    {
        public Address_Components[] address_components { get; set; }
        public string formatted_address { get; set; }
        public GeoGeometry geometry { get; set; }
        public string place_id { get; set; }
        public GeoPlus_Code plus_code { get; set; }
        public string[] types { get; set; }
    }

    public class GeoGeometry
    {
        public GeoLocation_Location location { get; set; }
        public string location_type { get; set; }
        public GeoViewport viewport { get; set; }
    }

    public class GeoLocation_Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class GeoViewport
    {
        public GeoNortheast northeast { get; set; }
        public GeoSouthwest southwest { get; set; }
    }

    public class GeoNortheast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class GeoSouthwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class GeoPlus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

}
