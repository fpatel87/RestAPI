using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);

        Task<OrderDetail?> GetByIdAsync(int id);

        Task<OrderDetail> AddAsync(OrderDetail orderDetail);

        Task UpdateAsync(OrderDetail orderDetail);

        Task DeleteAsync(int id);
    }
}