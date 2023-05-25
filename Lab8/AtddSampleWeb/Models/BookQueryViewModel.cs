using System.Collections.Generic;
using AtddSampleWeb.Models.DataModels;

namespace AtddSampleWeb.Models
{
    public class BookQueryViewModel
    {
        public string Name { get; set; }
        public string ISBN { get; set; }

        public IEnumerable<BookViewMoel> Books { get; set; }
    }
}