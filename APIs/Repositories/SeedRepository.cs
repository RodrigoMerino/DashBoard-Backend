using APIs.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Repositories
{
    public class SeedRepository
    {
        private readonly DashBoardContext _Context;
        public SeedRepository(DashBoardContext context)
        {
            _Context = context;
        }
        public void SeedData(int nCustomers, int nOrders) {
            if (!_Context.Customer.Any())
            {
                SeedCustomerRandomData(nCustomers);
                _Context.SaveChanges();
            }

            if (!_Context.Order.Any())
            {
                SeedOrdersRandomData(nOrders);
                _Context.SaveChanges();
            }
            if (!_Context.Server.Any())
            {
                SeedServerRandomData();
                _Context.SaveChanges();
            }

        }
        //Create seed for customer



        //calling build customer seed
        private void SeedCustomerRandomData(int n)
        {
            //generating randomsed base on this-->
            List<Customer> customers =  BuildCustomerRandomList(n);
            foreach (var customer in customers)
            {
                _Context.Customer.Add(customer);
            }

        }

        //calling build Order seed
        private void SeedOrdersRandomData(int n)
        {
            //generating randomsed base on this-->
            List<Order> orders = BuilOrdersRandomList(n);
            foreach (var order in orders)
            {
                _Context.Order.Add(order);
            }

        }
        private void SeedServerRandomData()
        {
            //generating randomsed base on this-->
            IEnumerable<Server> servers = BuilServerRandomList();
            foreach (var server in servers)
            {
                _Context.Server.Add(server);
            }

        }

        private IEnumerable <Server> BuilServerRandomList()
        {
            var servers = new List<Server>() {
            new Server{
                Name ="Dev",
                IsOnline = true

            },
            new Server{
                Name ="Dev web",
                IsOnline = true

            },
                new Server{
                Name ="Dev aws",
                IsOnline = false

            },new Server{
                Name ="web ats",
                IsOnline = true

            },new Server{
                Name ="simply Dest",
                IsOnline = false

            }

            };
            return servers;
        }

        private List<Customer> BuildCustomerRandomList(int nCustomers) {
            var customers = new List<Customer>();
            var names = new List<string>();
            for (int i = 1; i <= nCustomers; i++)
            {
                //parsing the data that wed like to use
                var name = Helpers.MakeUniqueCustomersName(names);
                names.Add(name);

                customers.Add(new Customer
                {
                    Name = name,
                    Email = Helpers.GetRandomEmail(name),
                    State = Helpers.GetRandomStates()

                   
                });
            }
            return customers;
        }



        private List<Order> BuilOrdersRandomList(int nOrders)
        {
            var orders = new List<Order>();
            var rand = new Random();

            for (int i = 1; i < nOrders; i++)
            {
                
                var RandomCustomerId = rand.Next(1,_Context.Customer.Count());
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrderCompleted(placed);

                orders.Add(new Order
                {
                    OrderId = i,
                    CustomerIdNavigation = _Context.Customer.First(x => x.CustomerId == RandomCustomerId),
                    Total = Helpers.GetRandomTotal(),
                    Placed = placed,
                    Completed = completed


                }) ;;
            }
            return orders;

        }
        
    }
}
