using CafePilot.Server.Models;

namespace CafePilot.Server.Interface
{
    public interface IOrderService
    {
        List<Order> GetOrdersByCafeId(Guid Id);
    }
}
