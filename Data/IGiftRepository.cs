using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IGiftRepository
    {
        public Task<GiftOutResp> GetGiftByIdAsync(IdRequest id);
        public Task<GiftResp> AddGiftAsync(GiftReq gift);
        public Task<IEnumerable<GiftOutResp>> GetGiftByUserIdAsync(IdUserIdRequest r);
    }
}