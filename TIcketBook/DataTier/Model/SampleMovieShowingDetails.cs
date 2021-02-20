using System;
using System.Collections.Generic;

namespace TIcketBook.DataTier.Models
{
    public partial class SampleMovieShowingDetails
    {
        public string ShowId { get; set; }
        public int? MovieId { get; set; }

        public virtual SampleMovie Movie { get; set; }
    }
}
