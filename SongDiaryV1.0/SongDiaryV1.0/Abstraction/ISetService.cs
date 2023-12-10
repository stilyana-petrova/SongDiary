using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface ISetService
    {
        bool Create(string name, DateTime datefortheset);
        bool Update(int setId, string name, DateTime datefortheset);
        List<Set> GetSets();
        Set GetSetById(int setId);
        bool RemoveById(int setId);
        List<Set> GetSets(string searchBySetName);
    }
}
