using System;
using System.Collections.Generic;

namespace CheckAvaliblity.Models
{
    public partial class SampleReservedSeats
    {
        public int Sno { get; set; }
        public string ShowId { get; set; }
        public int? SeatId { get; set; }
        public string Status { get; set; }

        public virtual SampleSeatsetup Seat { get; set; }
        public virtual SampleMovieShowingDetails Show { get; set; }
    }
}
       