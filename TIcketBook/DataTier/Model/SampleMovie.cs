using System;
using System.Collections.Generic;

namespace TIcketBook.DataTier.Models
{
    public partial class SampleMovie 
    {
        public SampleMovie()
        {
            SampleMovieShowingDetails = new HashSet<SampleMovieShowingDetails>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }

        public virtual ICollection<SampleMovieShowingDetails> SampleMovieShowingDetails { get; set; }
    }
}
