using System.Threading.Tasks;
using Structures;

namespace Data
{
    public interface IGiftRepository
    {
        public Task<string> GetName();
    }
}