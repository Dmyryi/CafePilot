using CafePilot.Server.Models;

namespace CafePilot.Server.Interface
{
    public interface IMenuService
    {
        List<MenuItem> GetAll();
    }
}
