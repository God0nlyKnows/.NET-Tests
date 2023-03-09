using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab1.Models
{
    internal class ZipData
    {
        [JsonPropertyName("post code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
