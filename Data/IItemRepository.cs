using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IItemRepository
    {
        public Task<long> SaveToDbAsync(Item item);
        public Task<Item> GetByIdAsync(long id);
    }
}