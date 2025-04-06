using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Commands.Product;
using Ecommerce.Application.Queries.Product;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(
        GetAllProductsQueryHandler getAllHandler,
        GetProductByIdQueryHandler getByIdHandler,
        AddProductCommandHandler addHandler,
        UpdateProductCommandHandler updateHandler,
        DeleteProductCommandHandler deleteHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await getAllHandler.Handle());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await getByIdHandler.Handle(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await addHandler.Handle(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != command.Id)
                return BadRequest();

            var result = await updateHandler.Handle(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await deleteHandler.Handle(id);
            return success ? NoContent() : NotFound();
        }
    }
}
