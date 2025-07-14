using System.Text.Json;
using System.Text.Json.Serialization;
using CafePilot.Server.Interface;
using CafePilot.Server.Models;

namespace CafePilot.Server.Services
{
    public class CafeService:ICafeService
    {
        private readonly string _filePath = "C:\\Users\\muzal\\source\\repos\\CafePilot\\CafePilot.Server\\AppData\\cafes.json";


        public List<Cafe> GetAllCafes()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Cafe>();
            }

           string json = File.ReadAllText(_filePath);
            List<Cafe> cafes = JsonSerializer.Deserialize<List<Cafe>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return cafes ?? new List<Cafe>();
        }
        

        public Cafe GetCafeById(int id)
        {
            List<Cafe> cafes = GetAllCafes();

            return cafes.Find(x => x.Id == id);
            
        }
    }
}
