using APIs.Custom_entities;
using APIs.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIs.Services
{
    public interface IOrdersService
    {
        PagedList<Order> GetOrders(int PageNumber, int PageSize);
        Task< List <OrderCustomEntity>> GetByState();
        Task<List<OrderCustomEntity>> GetByCustomer(int id);

        Task<Order> GetOrder(int id);
    }
}