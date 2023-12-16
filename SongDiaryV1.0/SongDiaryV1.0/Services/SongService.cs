using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class SongService:ISongService
    {
        private readonly ApplicationDbContext _context;
        public SongService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string title, string author, int songTypeId, int songTempoId, string youtubelink, string lyricschords, int capo)
        {
            Song item = new Song
            {
                Title = title,
                Author = author,
                SongTypeId = songTypeId,
                SongTempoId = songTempoId,
                YouTubeLink = youtubelink,
                LyricsChords = lyricschords,
                Capo = capo
            };
            _context.Songs.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Song GetSongById(int songId)
        {
            return _context.Songs.Find(songId);
        }

        public List<Song> GetSongs()
        {
            List<Song> songs = _context.Songs.ToList();
            return songs.ToList();
        }

        public List<Song> GetSongs(string searchByTitle, string searchByLyrics, string searchByAuthor)
        {
            List<Song> songs = _context.Songs.ToList();
            //3
            if (!String.IsNullOrEmpty(searchByTitle) && !String.IsNullOrEmpty(searchByLyrics) && !String.IsNullOrEmpty(searchByAuthor))
            {
                songs = songs.Where(x => x.Title.ToLower().Contains(searchByTitle.ToLower())
                && x.LyricsChords.Contains(searchByLyrics.ToLower())
                && x.Author.Contains(searchByAuthor.ToLower())).ToList();
            }

            //2
            else if (!String.IsNullOrEmpty(searchByTitle) && !String.IsNullOrEmpty(searchByLyrics))
            {
                songs = songs.Where(x => x.Title.ToLower().Contains(searchByTitle.ToLower())
                && x.LyricsChords.Contains(searchByLyrics.ToLower())).ToList();
            }
            //2
            else if (!String.IsNullOrEmpty(searchByTitle) && !String.IsNullOrEmpty(searchByAuthor))
            {
                songs = songs.Where(x => x.Title.ToLower().Contains(searchByTitle.ToLower())
                && x.Author.Contains(searchByAuthor.ToLower())).ToList();
            }
            //2
            else if (!String.IsNullOrEmpty(searchByLyrics) && !String.IsNullOrEmpty(searchByAuthor))
            {
                songs = songs.Where(x => x.LyricsChords.ToLower().Contains(searchByLyrics.ToLower())
                && x.Author.Contains(searchByAuthor.ToLower())).ToList();
            }

            //1
            else if (!String.IsNullOrEmpty(searchByTitle))
            {
                songs = songs.Where(x => x.Title.ToLower().Contains(searchByTitle.ToLower())).ToList();
            }
            //1
            else if (!String.IsNullOrEmpty(searchByLyrics))
            {
                songs = songs.Where(x => x.LyricsChords.ToLower().Contains(searchByLyrics.ToLower())).ToList();
            }
            //1
            else if (!String.IsNullOrEmpty(searchByAuthor))
            {
                songs = songs.Where(x => x.Author.ToLower().Contains(searchByAuthor.ToLower())).ToList();
            }
            return songs;

        }

        public bool RemoveById(int songId)
        {
            var song = GetSongById(songId);
            if (song == default(Song))
            {
                return false;
            }
            _context.Remove(song);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int songId, string title, string author, int songTypeId, int songTempoId, string youtubelink, string lyricschords, int capo)
        {
            var song = GetSongById(songId);
            if (song == default(Song))
            {
                return false;
            }
            song.Title = title;
            song.Author = author;
            song.SongTypeId = songTypeId;
            song.SongTempoId = songTempoId;
            song.YouTubeLink = youtubelink;
            song.LyricsChords = lyricschords;
            song.Capo = capo;

            _context.Update(song);
            return _context.SaveChanges() != 0;
        }
    }
}
