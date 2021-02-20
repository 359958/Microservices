using System;
using System.Collections.Generic;

namespace CheckAvaliblity.Models
{
    public partial class SampleSeatsetup
    {
        public SampleSeatsetup()
        {
            SampleReservedSeats = new HashSet<SampleReservedSeats>();
        }

        public int SeatId { get; set; }
        public string RowId { get; set; }
        public int? RowNumber { get; set; }

        public virtual ICollection<SampleReservedSeats> SampleReservedSeats { get; set; }
    }
}
