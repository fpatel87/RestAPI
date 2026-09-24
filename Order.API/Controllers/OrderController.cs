using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Services;
using OrderEntity = Order.ApplicationCore.Entities.Order;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(orders);
        }

        // GET: api/Order/customer/1
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);

            return Ok(orders);
        }

        // GET: api/Order/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderEntity order)
        {
            var createdOrder = await _orderService.AddOrderAsync(order);

            return CreatedAtAction(
                nameof(GetOrderById),
                new { id = createdOrder.Id },
                createdOrder);
        }

        // PUT: api/Order/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(
            int id,
            [FromBody] OrderEntity order)
        {
            if (id != order.Id)
            {
                return BadRequest("Order ID does not match.");
            }

            var existingOrder = await _orderService.GetOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            await _orderService.UpdateOrderAsync(order);

            return NoContent();
        }

        // DELETE: api/Order/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(id);

            return NoContent();
        }
    }
}