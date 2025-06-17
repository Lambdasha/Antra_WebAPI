using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Interfaces.Services;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderService orders) : ControllerBase
{
    private readonly IOrderService _orders = orders;

    // a. GET /api/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationCore.Entities.Order>>> GetAll()
        => Ok(await _orders.GetAllAsync());

    // b. POST /api/orders
    [HttpPost]
    public async Task<ActionResult<ApplicationCore.Entities.Order>> Create(ApplicationCore.Entities.Order order)
    {
        var created = await _orders.CreateAsync(order);
        return CreatedAtAction(nameof(GetByCustomer),
            new { customerId = created.CustomerId },
            created);
    }

    // c. GET /api/orders/customer/{customerId}
    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<IEnumerable<ApplicationCore.Entities.Order>>> GetByCustomer(int customerId)
    {
        var orders = await _orders.GetByCustomerAsync(customerId);
        return orders.Any() ? Ok(orders) : NotFound();
    }

    // d. DELETE /api/orders/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orders.DeleteAsync(id);
        return NoContent();
    }

    // e. PUT /api/orders/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ApplicationCore.Entities.Order order)
    {
        await _orders.UpdateAsync(id, order);
        return NoContent();
    }
}