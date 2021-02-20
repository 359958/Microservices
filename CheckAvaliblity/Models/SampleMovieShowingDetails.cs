using System;
using System.Collections.Generic;

namespace CheckAvaliblity.Models
{
    public partial class SampleMovieShowingDetails
    {
        public SampleMovieShowingDetails()
        {
            SampleReservedSeats = new HashSet<SampleReservedSeats>();
        }

        public string ShowId { get; set; }
        public int? MovieId { get; set; }

        public virtual SampleMovie Movie { get; set; }
        public virtual ICollection<SampleReservedSeats> SampleReservedSeats { get; set; }
    }
}
