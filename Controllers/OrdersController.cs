using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Queue;
using OrderService.Repository;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : Controller
    {

        private readonly OrderContext context;
        private readonly ILogger<OrdersController> logger;
        private readonly IMessageQueue queue; // our simulated message queue

        public OrdersController(OrderContext context, ILogger<OrdersController> logger, IMessageQueue queue)
        {
            this.context = context;
            this.logger = logger;
            this.queue = queue;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null) 
                return NotFound();
            
            return order; 
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            // Log the creation
            logger.LogInformation("Order {OrderId} created at {Time}", order.Id, DateTime.UtcNow);

            // Publish an order confirmation event (to in-memory queue)
            var evt = $"OrderCreated:{order.Id}";
            queue.Publish(evt);


            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
    }
}