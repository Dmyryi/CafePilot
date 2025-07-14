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
                        Code = 1001,
                        Message = "Кав'ярні не знайдено"
                    }
                };

                return NotFound(error);
            }

            return Ok(cafes);
           
        }
    }
}
