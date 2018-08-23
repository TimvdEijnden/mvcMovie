using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Responses {
    public class Series
    {
        public int page  { get; set; }
        public List<TMdbSerie> results { get; set; }

    }

    public class TMdbSerie
    {
        public string name  { get; set; }
        public string poster_path  { get; set; }
        public string overview  { get; set; }
        [DataType(DataType.Date)]
        public DateTime first_air_date { get; set; }
    }
}