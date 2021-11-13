using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IItemRepository
    {
        public Task<long> SaveToDb(Item item);
    }
}