using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAvaliblity.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckAvaliblity.Repository
{
    public class TicketCheckRepos : ITicketRepository
    {
        private readonly MovieContext _movieContext;
        public TicketCheckRepos(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public  IEnumerable<SampleSeatsetup> GetSeat()
        {
            var Seat = _movieContext.SampleSeatsetup
                .AsEnumerable();
            return Seat;
        }

        public IQueryable<int?> GetReserverd(string showID)
        {
            var Reserverd = _movieContext.SampleReservedSeats
              .Where(x => x.ShowId == showID).Select(y => y.SeatId).AsQueryable();
            return Reserverd;
        }

       
    }
}
