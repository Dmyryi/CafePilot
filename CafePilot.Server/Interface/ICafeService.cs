using CafePilot.Server.Models;

namespace CafePilot.Server.Interface
{
    public interface ICafeService
    {
        List<Cafe> GetAllCafes();
        Cafe GetCafeById(Guid id);

        Cafe PostCafe(CafeCreateDto dto);
        Cafe PatchCafe(CafeUpdateDto dto);
    }
}
