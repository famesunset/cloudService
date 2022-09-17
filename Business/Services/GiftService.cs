using System.Threading.Tasks;
using Data;

namespace Business.Services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _igiftRepository;
        public GiftService(IGiftRepository igiftRepository)
        {
            _igiftRepository = igiftRepository;
        }

        public Task<string> GetName()
        {
            return _igiftRepository.GetName();
        }
    }
}