using TilbudsPlatform.Data;

namespace TilbudsPlatform.core.Services
{
    public class WorklogService
    {
        private readonly TilbudsPlatformContext _context;

        public WorklogService(TilbudsPlatformContext context)
        {
            _context = context;
        }
    }
}
