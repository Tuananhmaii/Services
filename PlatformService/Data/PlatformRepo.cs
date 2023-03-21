using PlatformService.Model;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly ApplicationDbContext _db;

        public PlatformRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _db.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _db.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _db.Platforms.FirstOrDefault(n => n.Id == id);
        }

        public bool SaveChanges()
        {
            return (_db.SaveChanges() >= 0);
        }
    }
}
