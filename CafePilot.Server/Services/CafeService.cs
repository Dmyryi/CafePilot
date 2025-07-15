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

        public Cafe PatchCafe(CafeUpdateDto dto)
        {
         List<Cafe> allCafes = GetAllCafes();
            var cafe = allCafes.FirstOrDefault(c => c.Id == dto.Id);

            if (cafe == null) return null;

            if (dto.City != null) cafe.City = dto.City;
            if (dto.CityId != null) cafe.CityId = dto.CityId.Value;
            if (dto.Street != null) cafe.Street = dto.Street;
            if (dto.Geolat != null) cafe.Geolat = dto.Geolat;
            if (dto.Geolon != null) cafe.Geolon = dto.Geolon;
            if (dto.FotoCafe != null) cafe.FotoCafe = dto.FotoCafe;
            if (dto.PhoneNumber != null) cafe.PhoneNumber = dto.PhoneNumber;
            if (dto.StartWork != null) cafe.StartWork = dto.StartWork.Value;
            if (dto.EndWork != null) cafe.EndWork = dto.EndWork.Value;
            if (dto.Rating != null) cafe.Rating = dto.Rating.Value;
            if (dto.WaitingTime != null) cafe.WaitingTime = dto.WaitingTime.Value;
            if (dto.IsOpen != null) cafe.IsOpen = dto.IsOpen.Value;
            if (dto.IsOpenDescription != null) cafe.IsOpenDescription = dto.IsOpenDescription;


            string updatedJson = JsonSerializer.Serialize(allCafes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, updatedJson);

            return cafe;
        }
    }

   
}
