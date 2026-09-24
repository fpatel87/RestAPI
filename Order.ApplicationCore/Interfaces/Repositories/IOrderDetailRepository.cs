using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Interfaces.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);

        Task<OrderDetail?> GetByIdAsync(int id);

        Task<OrderDetail> AddAsync(OrderDetail orderDetail);

        Task UpdateAsync(OrderDetail orderDetail);

        Task DeleteAsync(int id);
    }
}