using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Structures;

namespace CloudService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly IProcessItem _processItem;
        public ItemController(IProcessItem processItem)
        {
            _processItem = processItem;
        }
        
        [HttpPost]
        public async Task<ActionResult<long>> Add(Item item)
        {
            return await _processItem.AddItem(item);
        }
    }
}