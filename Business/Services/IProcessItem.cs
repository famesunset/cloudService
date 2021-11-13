using System.Threading.Tasks;
using Structures;

namespace Business.Services
{
    public interface IProcessItem
    {
        public Task<long> AddItemAsync(Item item);
        public Task<Item> GetByIdAsync(long id);
    }
}