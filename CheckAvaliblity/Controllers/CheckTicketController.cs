using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CheckAvaliblity.Service;
using AutoMapper;
using CheckAvaliblity.Models;


namespace CheckAvaliblity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckTicketController : ControllerBase
    {
        private readonly ICheckStatus _checkStatus;
        private readonly IMapper _mapper;
        public CheckTicketController(ICheckStatus checkStatus,IMapper mapper)
        {
            _checkStatus = checkStatus;
            _mapper = mapper;
                 
        }

        // GET: api/CheckTicket
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetTicket(string showID)
        {
            var bookedTickets = _checkStatus.CheckTicketAvaliblity(showID);
            List<TicketAval> booked = _mapper.Map<List<Tickets>, List<TicketAval>>(bookedTickets);
            return Ok(booked);
        }
    }
}
