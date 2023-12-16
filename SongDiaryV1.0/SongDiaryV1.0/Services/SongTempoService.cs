using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class SongTempoService : ISongTempoService
    {
        private readonly ApplicationDbContext _context;
        public SongTempoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Song> GetSongsByTempo(int tempoId)
        {
            return _context.Songs.Where(x => x.SongTempoId == tempoId).ToList();
        }

        public SongTempo GetTempoById(int tempoId)
        {
            return _context.SongTempos.Find(tempoId);
        }

        public List<SongTempo> GetTempos()
        {
            List<SongTempo> tempo = _context.SongTempos.ToList();
            return tempo;
        }
    }
}
