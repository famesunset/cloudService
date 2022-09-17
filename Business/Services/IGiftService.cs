using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGiftService
    {
        public Task<string> GetName();
    }
}