using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;
using OrderEntity = Order.ApplicationCore.Entities.Order;
using Order.ApplicationCore.Interfaces.Repositories;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository
{
    public class OrderRepository(OrderDbContext context) : IOrderRepository
    {
        private readonly OrderDbContext _context = context;
        
        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<OrderEntity?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<OrderEntity> AddOrderAsync(OrderEntity order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task UpdateOrderAsync(OrderEntity order)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                return;
            }

            existingOrder.Order_Date = order.Order_Date;
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.PaymentMethodId = order.PaymentMethodId;
            existingOrder.PaymentName = order.PaymentName;
            existingOrder.ShippingAddress = order.ShippingAddress;
            existingOrder.ShippingMethod = order.ShippingMethod;
            existingOrder.BillAmount = order.BillAmount;
            existingOrder.Order_Status = order.Order_Status;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}