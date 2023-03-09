using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("post code")]
        public string PostalCode { get; set; }
    }
}
