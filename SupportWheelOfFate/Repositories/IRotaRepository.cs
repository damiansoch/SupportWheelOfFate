using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public interface IRotaRepository
    {
        Task<IEnumerable<Shift>> CreateRota();
        //Task<IEnumerable<Shift>> CreateRotaFullRandom();
    }
}
