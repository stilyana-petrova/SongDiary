using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface IFolderService
    {
        bool Create(string folderName);
        bool Update(int folderId, string folderName);
        List<Folder> GetFolders();

        Folder GetFolderById(int folderId);
        bool RemoveFolderById(int folderId);
    }
}
