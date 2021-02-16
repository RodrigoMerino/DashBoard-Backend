using APIs.Custom_entities;
using APIs.Data;
using APIs.Responses;
using APIs.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DashBoardContext _Context;

        private readonly IOrdersService _OrderService;
        public OrderController(IOrdersService ordersService, DashBoardContext context)
        {
            _OrderService = ordersService;
            _Context = context;
        }
        /*
        [HttpGet]
        public IActionResult getorderss() {
          var orders =  _Context.Order.ToList();
            return Ok(orders);
        }
        */

        [HttpGet]
        public IActionResult GetOrders(int PageNumber, int PageSize)
        {
            var orders = _OrderService.GetOrders(PageNumber, PageSize);


            var metadata = new Metadata()
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                CurrentPage = orders.CurrentPage,
                TotalPages = orders.TotalPages

            };

            var response = new ApiResponse<IEnumerable<Order>>(orders)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            return Ok(response);
        }

        [HttpGet("ByState")]
        public async Task  <IActionResult> ByState()
        {
            //problema de statemachine con awaiter
            /*
            var orders =  _Context.Order.Include(x => x.CustomerIdNavigation).ToList();

            var groupResult = orders.GroupBy(x => x.CustomerId)
                .ToList()
                .Select(group => new OrderCustomEntity
                {
                    State = group.Key,
                    Total = group.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                .ToList();

            return Ok(groupResult);
            */

            var orders = await _OrderService.GetByState();

            var response = new ApiResponse<List<OrderCustomEntity>>(orders) { };

            return Ok(response);
        }
        [HttpGet("ByCustomer/{id}")]
        public async Task<IActionResult> ByCustomer(int id)
        {
            //problema de statemachine con awaiter
            /*
            var orders =  _Context.Order.Include(x => x.CustomerIdNavigation).ToList();

            var groupResult = orders.GroupBy(x => x.CustomerId)
                .ToList()
                .Select(group => new OrderCustomEntity
                {
                    State = group.Key,
                    Total = group.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                .ToList();

            return Ok(groupResult);
            */
            var orders = await _OrderService.GetByCustomer(id);

            var response = new ApiResponse<List<OrderCustomEntity>>(orders) { };

            return Ok(response);
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<IActionResult> getorder(int id) {

            var order = await _OrderService.GetOrder(id);
            var response = new ApiResponse<Order>(order);

            return Ok(response);
        }
    }
}
