using CafePilot.Server.Interface;
using CafePilot.Server.Models;
using CafePilot.Server.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafeController : Controller
    {
        private readonly ICafeService _cafeSerice;

        public CafeController(ICafeService cafeSerice)
        {
            _cafeSerice = cafeSerice;
        }

        [HttpGet]
        public ActionResult<List<Cafe>> GetAll()
        {
            List<Cafe> cafes = _cafeSerice.GetAllCafes();
            if (cafes == null || cafes.Count == 0)
            {
                var error = new ErrorResponse
                {
                    Error = new ErrorDetail
                    {
                       
                        Message = "Кав'ярні не знайдено"
                    }
                };

                return NotFound(error);
            }

            return Ok(cafes);

        }


        [HttpGet("{id}")]
        public ActionResult<Cafe> GetbyId(int id) { 
        Cafe cafe = _cafeSerice.GetCafeById(id);
            Console.WriteLine(cafe);
            if (cafe == null)
            {
                return NotFound(new { message = $"Кав’ярня з ID {id} не знайдена." });
            }

            return Ok(cafe);
        }
    }
}
