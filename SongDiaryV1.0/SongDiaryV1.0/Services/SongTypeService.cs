using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class SongTypeService : ISongTypeService
    {
        private readonly ApplicationDbContext _context;
        public SongTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Song> GetSongsByType(int typeId)
        {
            return _context.Songs.Where(x => x.SongTypeId == typeId).ToList();
        }

        public SongType GetSongTypeById(int typeId)
        {
            return _context.SongTypes.Find(typeId);
        }

        public List<SongType> GetTypes()
        {
            List<SongType> type = _context.SongTypes.ToList();
            return type;
        }
    }
}
