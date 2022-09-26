using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Structures;

namespace Business.Services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _igiftRepository;
        public GiftService(IGiftRepository igiftRepository)
        {
            _igiftRepository = igiftRepository;
        }

        public Task<IEnumerable<Gift>> GetGiftByIdAsync(List<long> ids)
        {
            return _igiftRepository.GetGiftByIdAsync(ids);
        }

        public Task AddGiftAsync(Gift gift)
        {
            return _igiftRepository.AddGiftAsync(gift);
        }
    }
}