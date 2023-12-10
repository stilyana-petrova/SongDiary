using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class FolderService:IFolderService
    {
        private readonly ApplicationDbContext _context;
        public FolderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string folderName)
        {
            Folder folder = new Folder
            {
                FolderName = folderName
            };
            _context.Folders.Add(folder);
            return _context.SaveChanges() != 0;
        }

        public Folder GetFolderById(int folderId)
        {
            return _context.Folders.Find(folderId);
        }

        public List<Folder> GetFolders()
        {
            List<Folder> folder = _context.Folders.ToList();
            return folder;
        }

        public bool RemoveFolderById(int folderId)
        {
            var folder = GetFolderById(folderId);
            if (folder == default(Folder))
            {
                return false;
            }
            _context.Remove(folder);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int folderId, string folderName)
        {
            var folder = GetFolderById(folderId);
            if (folder == default(Folder))
            {
                return false;
            }
            folder.FolderName = folderName;

            _context.Update(folder);
            return _context.SaveChanges() != 0;
        }
    }
}
