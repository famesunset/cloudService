using System;
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
        public async Task<Gift> GetGiftByIdAsync(IdRequest id)
        {
            return await _giftService.GetGiftByIdAsync(id);
        }
        
        [HttpPost]
        public async Task<IEnumerable<Gift>> GetGiftByUserIdAsync(IdRequest r)
        {
            return await _giftService.GetGiftByUserIdAsync(r);
        }

        [HttpPost]
        public async Task<ActionResult<GiftResp>> AddGiftAsync(Gift gift)
        {
            return Ok(await _giftService.AddGiftAsync(gift));
        }

        [HttpPost]
        public async Task AddName(Item item)
        {
            Console.WriteLine(item.Name);
            int a = 3;
        }
} 
}