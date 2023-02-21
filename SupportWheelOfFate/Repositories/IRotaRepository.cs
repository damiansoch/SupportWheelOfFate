using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public interface IRotaRepository
    {
        Task<IEnumerable<Engineer>>CreateRota();
    }
}
