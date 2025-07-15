using CafePilot.Server.Interface;
using CafePilot.Server.Models;
using CafePilot.Server.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cafe/{id}/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAll([FromRoute] Guid id)
    {
        List<Order> orders = _orderService.GetOrdersByCafeId(id);

        if (orders == null || orders.Count == 0)
        {
            var error = new ErrorResponse
            {
                Error = new ErrorDetail
                {
                    Message = "Замовлень не знайдено"
                }
            };

            return NotFound(error);
        }

        return Ok(orders);
    }
}
