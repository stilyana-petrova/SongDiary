using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface ISongTempoService
    {
        List<SongTempo> GetTempos();
        SongTempo GetTempoById(int tempoId);
        List<Song> GetSongsByTempo(int tempoId);
    }
}
