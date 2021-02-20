using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TIcketBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "T1", "T2", "T3" };

        }
    }
}