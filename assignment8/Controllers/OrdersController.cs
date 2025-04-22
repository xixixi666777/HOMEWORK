using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _3_20_C_;
using OrderManagerEF;
using _3_20_C_;
using static _3_20_C_.OrderManager; // 引入嵌套类：Order、Customer、OrderDetails 等


namespace OrderManagerWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Details).ThenInclude(d => d.Item)
                .ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var order = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Details).ThenInclude(d => d.Item)
                .FirstOrDefault(o => o.OrderId == id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (_context.Orders.Any(o => o.OrderId == order.OrderId))
                return Conflict("订单已存在");
            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Order order)
        {
            if (id != order.OrderId) return BadRequest("ID 不一致");
            var exist = _context.Orders.Include(o => o.Details).FirstOrDefault(o => o.OrderId == id);
            if (exist == null) return NotFound();
            _context.Entry(exist).CurrentValues.SetValues(order);
            exist.Details.Clear();
            foreach (var detail in order.Details)
                exist.Details.Add(detail);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var order = _context.Orders.Include(o => o.Details).FirstOrDefault(o => o.OrderId == id);
            if (order == null) return NotFound();
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }
    }
}