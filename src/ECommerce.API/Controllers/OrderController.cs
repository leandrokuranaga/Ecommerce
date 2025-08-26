using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Application.Queries.Order;

namespace ECommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(GetOrderByIdQueryHandler getByIdHandler) : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize] // This will return 401 for unauthenticated requests
        public async Task<IActionResult> Get(int id)
        {
            var order = await getByIdHandler.Handle(id);
            return order is null ? NotFound() : Ok(order);
        }
    }
}
