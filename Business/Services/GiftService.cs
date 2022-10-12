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

        public async Task<GiftOutResp> GetGiftByIdAsync(IdRequest id)
        {
            return await _igiftRepository.GetGiftByIdAsync(id);
        }

        public async Task<GiftResp> AddGiftAsync(GiftReq gift)
        {
            IEnumerable<GiftOutResp> userGifts = await _igiftRepository.GetGiftByUserIdAsync(new IdUserIdRequest()
            {
                Id = gift.UserId
            });
            bool isExist = false;
            foreach (var g in userGifts)
            {
                if (g.Title.Equals(gift.Title) && g.Url.Equals(gift.URL))
                {
                    isExist = true;
                }
            }
            if (isExist)
            {
                return new GiftResp
                {
                    Id = -1
                };
            }
            return await _igiftRepository.AddGiftAsync(gift);
        }

        public async Task<IEnumerable<GiftOutResp>> GetGiftByUserIdAsync(IdUserIdRequest r)
        {
            return await _igiftRepository.GetGiftByUserIdAsync(r);
        }
    }
}