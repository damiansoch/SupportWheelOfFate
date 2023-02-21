using SupportWheelOfFate.Models;

namespace SupportWheelOfFate.Repositories
{
    public interface IEngineerRepository
    {
        Task<IEnumerable<Engineer>> GetAllAsync();
    }
}
