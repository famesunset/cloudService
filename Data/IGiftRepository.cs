using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IGiftRepository
    {
        public Task<Gift> GetGiftByIdAsync(IdRequest id);
        public Task<GiftResp> AddGiftAsync(Gift gift);
        public Task<IEnumerable<Gift>> GetGiftByUserIdAsync(IdRequest r);
    }
}