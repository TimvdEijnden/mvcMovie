using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MvcMovie.Responses {
    public class Movies
    {
        public int page  { get; set; }
        public List<TMdbMovie> results { get; set; }

    }

    public class TMdbMovie
    {
        public string title  { get; set; }
        public string poster_path  { get; set; }
        public string overview  { get; set; }
        public double rating  { get; set; }
        [DataType(DataType.Date)]
        public DateTime? release_date { get; set; }
    }
}