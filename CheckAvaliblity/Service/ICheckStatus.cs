using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckAvaliblity.Models;

namespace CheckAvaliblity.Service
{
    public interface ICheckStatus
    {
        List<Tickets> CheckTicketAvaliblity(string showId);
    }
}
