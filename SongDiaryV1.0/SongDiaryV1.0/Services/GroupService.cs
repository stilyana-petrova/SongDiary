using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class GroupService:IGroupService
    {
        private readonly ApplicationDbContext _context;
        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, string description, string place)
        {
            Group group = new Group
            {
                Name = name,
                Description = description,
                Place = place,
            };
            _context.Groups.Add(group);
            return _context.SaveChanges() != 0;
        }

        public Group GetGroupById(int groupId)
        {
            return _context.Groups.Find(groupId);
        }

        public List<Group> GetGroups()
        {
            List<Group> groups = _context.Groups.ToList();
            return groups;
        }

        public List<Group> GetGroups(string searchStringByGroupName)
        {
            List<Group> groups = _context.Groups.ToList();

            if (!String.IsNullOrEmpty(searchStringByGroupName))
            {
                groups = groups.Where(x => x.Name.ToLower().Contains(searchStringByGroupName.ToLower())).ToList();
            }
            return groups;
        }

        public bool RemoveGroupById(int groupId)
        {
            var group = GetGroupById(groupId);
            if (group == default(Group))
            {
                return false;
            }
            _context.Remove(group);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int groupId, string name, string description, string place)
        {
            var group = GetGroupById(groupId);
            if (group == default(Group))
            {
                return false;
            }
            group.Name = name;
            group.Description = description;
            group.Place = place;

            _context.Update(group);
            return _context.SaveChanges() != 0;
        }
    }
}
