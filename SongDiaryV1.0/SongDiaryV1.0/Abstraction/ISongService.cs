using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface ISongService
    {
        bool Create(string title, string author, string youtubelink, string lyricschords, int capo);
        bool Update(int songId, string title, string author, string youtubelink, string lyricschords, int capo);
        List<Song> GetSongs();
        Song GetSongById(int songId);
        bool RemoveById(int songId);
        List<Song> GetSongs(string searchByTitle, string searchByLyrics, string searchByAuthor);
    }
}
