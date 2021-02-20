using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAvaliblity.Service
{
    public class Tickets
    {
        public string ShowID { get; set; }
        public int SeatId { get; set; }

        public string RowID { get; set; }
        public int? RowNumber { get; set; }
    }
}
