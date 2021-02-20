using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CheckAvaliblity.Models;
using CheckAvaliblity.Service;

namespace CheckAvaliblity.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Tickets, TicketAval>();
        }
    }
}
