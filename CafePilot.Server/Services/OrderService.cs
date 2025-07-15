using System.Text.Json;
using CafePilot.Server.Interface;
using CafePilot.Server.Models;

namespace CafePilot.Server.Services
{
    public class OrderService:IOrderService
    {
        private readonly string _filePath = "C:\\Users\\muzal\\source\\repos\\CafePilot\\CafePilot.Server\\AppData\\orders.json";

        public List<Order> GetAllOrders()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Order>();
            }
            string json = File.ReadAllText(_filePath);
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(json, new JsonSerializerOptions { 
            PropertyNameCaseInsensitive = true,
            });
            return orders ?? new List<Order>();
        }

        public List<Order> GetOrdersByCafeId(Guid cafeId)
        {
            List<Order> allOrders = GetAllOrders();
            return allOrders.Where(o => o.CafeId == cafeId).ToList();
        }

    }
}
