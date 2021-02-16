using APIs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DashBoardContext _Context;
        public CustomerController(DashBoardContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllCustomers()
        {
            var Orders = await _Context.Customer.ToListAsync();

            return Ok(Orders);
        }
    }
}
