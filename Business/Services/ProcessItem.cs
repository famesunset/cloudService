using System.Threading.Tasks;
using Data;
using Structures;

namespace Business.Services
{
    public class ProcessItem : IProcessItem
    {
        private readonly IItemRepository _iitemRepository;
        public ProcessItem(IItemRepository iitemRepository)
        {
            _iitemRepository = iitemRepository;
        }
        public async Task<long> AddItemAsync(Item item)
        {
            return await _iitemRepository.SaveToDbAsync(item);
        }

        public async Task<Item> GetByIdAsync(long id)
        {
            return await _iitemRepository.GetByIdAsync(id);
        }
    }
}