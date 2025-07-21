using System.Text.Json;
using CafePilot.Server.Interface;
using CafePilot.Server.Models;

namespace CafePilot.Server.Services
{
    public class MenuService:IMenuService
    {
        private readonly string _filePath = "C:\\Users\\muzal\\source\\repos\\CafePilot\\CafePilot.Server\\AppData\\menu.json";

        public List<MenuItem> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<MenuItem>();
            }
            string json = File.ReadAllText(_filePath);
            List<MenuItem> menu = JsonSerializer.Deserialize<List<MenuItem>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return menu ?? new List<MenuItem>();
        }
    }
}
