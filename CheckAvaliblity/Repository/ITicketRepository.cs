using System;
using System.Collections.Generic;
using System.Linq;
using CheckAvaliblity.Models;
using System.Threading.Tasks;

namespace CheckAvaliblity.Repository
{
    public interface ITicketRepository
    {
        public IEnumerable<SampleSeatsetup> GetSeat();
        public IQueryable<int?> GetReserverd(string showID);
    }
}
