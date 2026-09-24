using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces.Repositories;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repository
{
    public class OrderDetailRepository(OrderDbContext context) : IOrderDetailRepository
    {
        private readonly OrderDbContext _context = context;
       

        public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.Order_Id == orderId)
                .ToListAsync();
        }

        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();

            return orderDetail;
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.Id == id);

            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}