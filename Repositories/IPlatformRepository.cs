using PlateformService.Models;

namespace PlateformService.Repositories
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Plateform> GetAllPlatforms();
        Plateform GetPlatFormById(int id);
        void CreatePlatform(Plateform Plat);

      }  
}
