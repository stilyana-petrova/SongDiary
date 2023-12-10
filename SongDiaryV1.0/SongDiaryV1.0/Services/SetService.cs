using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class SetService:ISetService
    {
        private readonly ApplicationDbContext _context;
        public SetService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, DateTime datefortheset)
        {
            Set item = new Set
            {
                Name = name,
                DateForTheSet = datefortheset
            };
            _context.Sets.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Set GetSetById(int setId)
        {
            return _context.Sets.Find(setId);
        }

        public List<Set> GetSets()
        {
            List<Set> sets = _context.Sets.ToList();
            return sets;
        }

        public List<Set> GetSets(string searchBySetName)
        {
            List<Set> sets = _context.Sets.ToList();

            if (!String.IsNullOrEmpty(searchBySetName))
            {
                sets = sets.Where(x => x.Name.ToLower().Contains(searchBySetName.ToLower())).ToList();
            }
            return sets;
        }

        public bool RemoveById(int setId)
        {
            var set = GetSetById(setId);
            if (set == default(Set))
            {
                return false;
            }
            _context.Remove(set);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int setId, string name, DateTime datefortheset)
        {
            var set = GetSetById(setId);
            if (set == default(Set))
            {
                return false;
            }
            set.Name = name;
            set.DateForTheSet = datefortheset;

            _context.Update(set);
            return _context.SaveChanges() != 0;
        }
    }
}
