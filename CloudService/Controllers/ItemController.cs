using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Structures;

namespace CloudService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public ItemController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpPost]
        public async Task<IEnumerable<Gift>> GetGiftByIdAsync(List<long> ids)
        {
            return await _giftService.GetGiftByIdAsync(ids);
        }
        
        [HttpPost]
        public async Task AddGiftAsync(Gift gift)
        {
            await _giftService.AddGiftAsync(gift);
        }
    } 
}