namespace CafePilot.Server.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public Foto Foto { get; set; }
        public double Price { get; set; }
    }
}
