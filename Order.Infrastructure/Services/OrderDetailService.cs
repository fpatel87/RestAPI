using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces.Repositories;
using Order.ApplicationCore.Services;

namespace Order.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return await _orderDetailRepository.GetByOrderIdAsync(orderId);
        }

        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _orderDetailRepository.GetByIdAsync(id);
        }

        public async Task<OrderDetail> AddAsync(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.AddAsync(orderDetail);
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.UpdateAsync(orderDetail);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderDetailRepository.DeleteAsync(id);
        }
    }
}