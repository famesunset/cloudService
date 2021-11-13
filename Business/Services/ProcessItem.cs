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
        public async Task<long> AddItem(Item item)
        {
            return await _iitemRepository.SaveToDb(item);
        }
    }
}