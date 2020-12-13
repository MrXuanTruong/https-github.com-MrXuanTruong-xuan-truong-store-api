using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Entity;
using Store.Entity.Domains;
using Store.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(DatabaseContext context,
            ILogger<OrderService> logger) :
            base(context)
        {
            _logger = logger;
        }

        public Task<bool> Detete(long entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            return
                context.Orders
                .Include(x => x.OrderStatus)
                .AsNoTracking();
        }

        public Task<Order> GetById(long id)
        {
            return context.Orders
                .Include(order => order.OrderStatus)
                .Include(order => order.PaymentMethod)
                .Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Color)
                .Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product)
                .Where(x => x.OrderId == id)
                //.AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(Order order)
        {
            var result = true;
            try
            {
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(OrderService));
            }

            return result;
        }

        public Task<List<Order>> Orders()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Order order)
        {
            var result = true;
            try
            {
                context.Orders.Update(order);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = false;
                _logger.LogError(ex, nameof(OrderService));
            }

            return result;
        }
    }

    
}
