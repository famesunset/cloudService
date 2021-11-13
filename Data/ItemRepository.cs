using System.Threading.Tasks;
using Structures;

namespace Data
{
    public class ItemRepository : IItemRepository
    {
        public async Task<long> SaveToDb(Item item)
        {
            return 1;
        }
    }
}