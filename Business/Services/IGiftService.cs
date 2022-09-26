using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Business.Services
{
    public interface IGiftService
    {
        public Task<IEnumerable<Gift>> GetGiftByIdAsync(List<long> id);
        public Task AddGiftAsync(Gift gift);
    }
}