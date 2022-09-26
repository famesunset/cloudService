using System.Collections.Generic;
using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IGiftRepository
    {
        public Task<IEnumerable<Gift>> GetGiftByIdAsync(List<long> ids);
        public Task AddGiftAsync(Gift gift);
    }
}