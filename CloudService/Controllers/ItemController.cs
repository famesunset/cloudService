using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<string>> GetName()
        {
            return await _giftService.GetName();
        }
    } 
}