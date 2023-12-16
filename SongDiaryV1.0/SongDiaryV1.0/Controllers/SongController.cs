using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Domain;
using SongDiaryV1._0.Models.Song;
using SongDiaryV1._0.Models.Tempo;
using SongDiaryV1._0.Models.Type;

namespace SongDiaryV1._0.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        private readonly IFolderService _folderService;
        private readonly ISetService _setService;
        private readonly ISongTypeService _songTypeService;
        private readonly ISongTempoService _songTempoService;

        public SongController(ISongService songService, IFolderService folderService, ISetService setService, ISongTypeService songTypeService, ISongTempoService songTempoService)
        {
            _songService = songService;
            _folderService = folderService;
            _setService = setService;
            _songTypeService = songTypeService;
            _songTempoService = songTempoService;

        }

        // GET: SongController
        [AllowAnonymous]
        public ActionResult Index(string searchByTitle, string searchByLyrics, string searchByAuthor)
        {
            List<SongIndexVM> songs = _songService.GetSongs(searchByTitle, searchByLyrics, searchByAuthor)
                .Select(song => new SongIndexVM
                {
                    Id = song.Id,
                    Title = song.Title,
                    Author = song.Author,
                    SongTypeId=song.SongTypeId,
                    SongTypeName=song.SongType.Name,
                    SongTempoId=song.SongTempoId,
                    SongTempoName=song.SongTempo.Name,
                    YouTubeLink = song.YouTubeLink,
                    LyricsChords = song.LyricsChords,
                    Capo = song.Capo
                }).ToList();
            return View(songs);
        }

        // GET: SongController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Song s = _songService.GetSongById(id);
            if (s == null)
            {
                return NotFound();
            }
            SongIndexVM song = new SongIndexVM()
            {
                Id = s.Id,
                Title = s.Title,
                Author = s.Author,
                SongTypeId = s.SongTypeId,
                SongTypeName=s.SongType.Name,
                SongTempoId=s.SongTempoId,
                SongTempoName=s.SongTempo.Name,
                YouTubeLink = s.YouTubeLink,
                LyricsChords = s.LyricsChords,
                Capo = s.Capo
            };
            return View(song);
        }

        // GET: SongController/Create
        public ActionResult Create()
        {
            var song = new SongVM();
            song.SongTypes = _songTypeService.GetTypes().Select(x => new SongTypeVM()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            song.SongTempos = _songTempoService.GetTempos().Select(x => new SongTempoVM()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(song);
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] SongVM song)
        {
            if (ModelState.IsValid)
            {
                var created = _songService.Create(song.Title, song.Author, song.SongTypeId, song.SongTempoId, song.YouTubeLink, song.LyricsChords, song.Capo);
                if (created)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: SongController/Edit/5
        public ActionResult Edit(int id)
        {
            Song song = _songService.GetSongById(id);
            if (song == null)
            {
                return NotFound();
            }
            SongVM updatedSong = new SongVM()
            {
                Id = song.Id,
                Title = song.Title,
                Author = song.Author,
                SongTypeId = song.SongTypeId,
                SongTempoId = song.SongTempoId,
                YouTubeLink = song.YouTubeLink,
                LyricsChords = song.LyricsChords,
                Capo = song.Capo
            };
            updatedSong.SongTypes = _songTypeService.GetTypes()
                .Select(t => new SongTypeVM()
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToList();
            updatedSong.SongTempos = _songTempoService.GetTempos()
                .Select(s => new SongTempoVM()
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();
            return View(updatedSong);
        }

        // POST: SongController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SongVM song)
        {
            if (ModelState.IsValid)
            {
                var updated = _songService.Update(id, song.Title, song.Author, song.SongTypeId, song.SongTempoId, song.YouTubeLink, song.LyricsChords, song.Capo);
                if (updated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(song);
        }

        // GET: SongController/Delete/5
        public ActionResult Delete(int id)
        {
            Song s = _songService.GetSongById(id);
            if (s == null)
            {
                return NotFound();
            }
            SongIndexVM song = new SongIndexVM()
            {
                Id = s.Id,
                Title = s.Title,
                Author = s.Author,
                SongTypeId = s.SongTypeId,
                SongTypeName = s.SongType.Name,
                SongTempoId = s.SongTempoId,
                SongTempoName=s.SongTempo.Name,
                YouTubeLink = s.YouTubeLink,
                LyricsChords = s.LyricsChords,
                Capo = s.Capo
            };
            return View(song);
        }

        // POST: SongController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _songService.RemoveById(id);
            if (deleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
