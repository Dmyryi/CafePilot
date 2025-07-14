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
            List<Cafe> allCaffe = JsonSerializer.Deserialize<List<Cafe>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return allCaffe ?? new List<Cafe>();
        }
        

        public Cafe GetCafeById(Guid id)
        {
            List<Cafe> allCaffe = GetAllCafes();

            return allCaffe.Find(x => x.Id == id);
            
        }

        public Cafe PostCafe(CafeCreateDto dto)
        {
            List<Cafe> allCaffe = GetAllCafes();
            Cafe newCafe = new Cafe
            {
                Id = Guid.NewGuid(),
                City = dto.City,
                CityId = Guid.NewGuid(),
                Street = dto.Street,
                Geolat = dto.Geolat,
                Geolon = dto.Geolon,
                FotoCafe = dto.FotoCafe,
                PhoneNumber = dto.PhoneNumber,
                StartWork = new TimeSpan(8, 0, 0),
                EndWork = new TimeSpan(20, 0, 0),
                Rating = 0,
                WaitingTime = 0,
                IsOpen = 1,
                IsOpenDescription = "Відчинено"
            };

            allCaffe.Add(newCafe);
            string updateJson = JsonSerializer.Serialize(allCaffe, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(_filePath, updateJson);
            return newCafe;
        }
    }

   
}
