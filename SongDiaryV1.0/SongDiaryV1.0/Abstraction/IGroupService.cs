
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface IGroupService
    {
        bool Create(string name, string description, string place);
        bool Update(int groupId, string name, string description, string place);
        List<Group> GetGroups();

        Group GetGroupById(int groupId);
        bool RemoveGroupById(int groupId);
        List<Group> GetGroups(string searchStringByGroupName);
    }
}
