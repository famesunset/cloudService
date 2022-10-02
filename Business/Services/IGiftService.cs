using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Business.Services
{
    public interface IGiftService
    {
        public Task<Gift> GetGiftByIdAsync(IdRequest id);
        public Task<GiftResp> AddGiftAsync(Gift gift);
        public Task<IEnumerable<Gift>> GetGiftByUserIdAsync(IdRequest r);
    }
}