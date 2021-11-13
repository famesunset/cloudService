using System.Threading.Tasks;
using Structures;

namespace Business.Services
{
    public interface IProcessItem
    {
        public Task<long> AddItem(Item item);
    }
}