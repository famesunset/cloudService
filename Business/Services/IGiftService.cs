using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Business.Services
{
    public interface IGiftService
    {
        public Task<GiftOutResp> GetGiftByIdAsync(IdRequest id);
        public Task<GiftResp> AddGiftAsync(GiftReq gift);
        public Task<IEnumerable<GiftOutResp>> GetGiftByUserIdAsync(IdUserIdRequest r);
    }
}