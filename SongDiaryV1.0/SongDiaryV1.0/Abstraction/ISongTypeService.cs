using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface ISongTypeService
    {
        List<SongType> GetTypes();
        SongType GetSongTypeById(int typeId);
        List<Song> GetSongsByType(int typeId);

    }
}
