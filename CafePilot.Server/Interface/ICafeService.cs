using CafePilot.Server.Models;

namespace CafePilot.Server.Interface
{
    public interface ICafeService
    {
        List<Cafe> GetAllCafes();
    }
}
