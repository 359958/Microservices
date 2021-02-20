using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAvaliblity.Models
{
    public class TicketAval
    {
        public string ShowId { get; set; }
        public int? SeatId { get; set; }
        public string RowID { get; set; }
        public int? Rownumber { get; set; }
    }
}