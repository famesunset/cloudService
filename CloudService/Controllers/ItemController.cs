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
        public async Task<ActionResult<long>> AddAsync(Item item)
        {
            return await _processItem.AddItemAsync(item);
        }

        [HttpGet]
        public async Task<ActionResult<Item>> GetByIdAsync(long id)
        {
            return await _processItem.GetByIdAsync(id);
        }
    } 
}