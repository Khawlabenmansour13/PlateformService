using PlateformService.Data;
using PlateformService.Models;

namespace PlateformService.Repositories
{
    public class PlateformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlateformRepository(AppDbContext context)
        {
            _context = context;
        }


        public void CreatePlatform(Plateform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public IEnumerable<Plateform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Plateform GetPlatFormById(int id)
        {
            return _context.Platforms.FirstOrDefault(p=> p.Id == id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
