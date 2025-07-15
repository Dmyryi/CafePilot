using CafePilot.Server.Interface;
using CafePilot.Server.Models;
using CafePilot.Server.Responses;
using CafePilot.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafePilot.Server.Controllers
{
    [ApiController]
    [Route("api/cafe/menu")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public ActionResult<List<MenuItem>> GetAll()
        {
            List<MenuItem> menu = _menuService.GetAll();
            if (menu == null || menu.Count == 0)
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

            return Ok(menu);

        }
    }
}
