using System.ComponentModel.DataAnnotations;

namespace CafePilot.Server.Models
{
    public class CafeCreateDto
    {
        [Required(ErrorMessage = "Місто є обов'язковим")]
        public string City { get; set; }

        [Required(ErrorMessage = "Вулиця є обов'язковою")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Широта є обов'язковою")]
        public string Geolat { get; set; }

        [Required(ErrorMessage = "Довгота є обов'язковою")]
        public string Geolon { get; set; }

        [Required(ErrorMessage = "Фото є обов'язковим")]
        public Foto FotoCafe { get; set; }

        [Required(ErrorMessage = "Номер телефону є обов'язковим")]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Невірний формат номера телефону")]
        public string PhoneNumber { get; set; }
    }
}
