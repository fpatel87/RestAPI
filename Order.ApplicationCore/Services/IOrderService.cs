using OrderEntity = Order.ApplicationCore.Entities.Order;

namespace Order.ApplicationCore.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();

        Task<OrderEntity?> GetOrderByIdAsync(int id);

        Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(int customerId);

        Task<OrderEntity> AddOrderAsync(OrderEntity order);

        Task UpdateOrderAsync(OrderEntity order);

        Task DeleteOrderAsync(int id);
    }
}