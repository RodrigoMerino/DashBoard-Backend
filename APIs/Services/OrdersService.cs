using APIs.Custom_entities;
using APIs.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Services
{

    public class OrdersService : IOrdersService
    {
        private readonly DashBoardContext _Context;
        public OrdersService(DashBoardContext context)
        {
            _Context = context;
        }

        public async Task<List<OrderCustomEntity>> GetByState()
        {
            var orders = await _Context.Order.Include(x => x.CustomerIdNavigation).ToListAsync();

            var groupResult = orders.GroupBy(x => x.CustomerId)
                .ToList()
                .Select(group => new OrderCustomEntity
                //crear una entity custom para poder machear,si no me dara un error de cannot implicyt
                {
                    State = _Context.Customer.Find(group.Key).State,
                    // State = _Context.Customer.Find(group.Key).State,
                    Total = group.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                .ToList();

            return groupResult;
        }
        public async Task<List<OrderCustomEntity>> GetByCustomer(int id)
        {
            var orders = await _Context.Order.Include(x => x.CustomerIdNavigation).ToListAsync();

            var groupResult = orders.GroupBy(x => x.CustomerId)
                .ToList()
                .Select(group => new OrderCustomEntity
                //crear una entity custom para poder machear,si no me dara un error de cannot implicyt
                {
                    Name = _Context.Customer.Find(group.Key).Name,
                    // State = _Context.Customer.Find(group.Key).State,
                    Total = group.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                .Take(id)
                .ToList();

            return groupResult;
        }
        public PagedList<Order> GetOrders(int PageNumber, int PageSize)
        {
            var orders = _Context.Order.ToList();

            var pagedOrders = PagedList<Order>.Create(orders, PageNumber, PageSize);
            return pagedOrders;
        }

        public async Task<Order> GetOrder(int id)
        {
        var order = await    _Context.Order.Include(x => x.CustomerIdNavigation).FirstOrDefaultAsync(x => x.OrderId == id);

            if (order == null)
            {
                throw new Exception("No found");
            }
            return order;
        }
    }
}
