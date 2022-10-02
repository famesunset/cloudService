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

        public Task<Gift> GetGiftByIdAsync(IdRequest id)
        {
            return _igiftRepository.GetGiftByIdAsync(id);
        }

        public Task<GiftResp> AddGiftAsync(Gift gift)
        {
            return _igiftRepository.AddGiftAsync(gift);
        }

        public Task<IEnumerable<Gift>> GetGiftByUserIdAsync(IdRequest r)
        {
            return _igiftRepository.GetGiftByUserIdAsync(r);
        }
    }
}