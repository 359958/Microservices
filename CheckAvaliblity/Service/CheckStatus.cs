using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAvaliblity.Models;
using CheckAvaliblity.Repository;


namespace CheckAvaliblity.Service
{
    public class CheckStatus : ICheckStatus
    {
        private readonly ITicketRepository _ticketRepository;
        public CheckStatus(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public List<Tickets> CheckTicketAvaliblity(string showId)
        {
            var Seat = _ticketRepository.GetSeat().ToList();
            List<int?> reserved = _ticketRepository.GetReserverd(showId).ToList();

            var avalseat = Seat.Where(x => !reserved.Contains(x.SeatId));
            var result = (from s in avalseat
                          
                          select new Tickets
                          {
                              ShowID = showId,
                              SeatId = s.SeatId,
                               RowID= s.RowId,
                              RowNumber = s.RowNumber
                          }).ToList();

            return result;

        }
    }
}
