namespace CafePilot.Server.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CafeId { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public double TotalPrice { get; set; }
        public StatusEnum Status { get; set; }
        public Feedback Feedback { get; set; }
    }

}
