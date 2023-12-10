using SongDiaryV1._0.Abstraction;
using SongDiaryV1._0.Data;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Services
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string eventName, string eventDescription, DateTime strartDate, DateTime endDate, string eventPlace)
        {
            Event eventi = new Event
            {
                EventName = eventName,
                EventDescription = eventDescription,
                StartDate = strartDate,
                EndDate = endDate,
                EventPlace = eventPlace
            };
            _context.Events.Add(eventi);
            return _context.SaveChanges() != 0;
        }

        public Event GetEventById(int eventId)
        {
            return _context.Events.Find(eventId);
        }

        public List<Event> GetEvents()
        {
            List<Event> eventi = _context.Events.ToList();
            return eventi;
        }


        public List<Event> GetEvents(string searchStringByEventName)
        {
            List<Event> eventi = _context.Events.ToList();
            if (!String.IsNullOrEmpty(searchStringByEventName))
            {
                eventi = eventi.Where(x => x.EventName.ToLower().Contains(searchStringByEventName.ToLower())).ToList();
            }
            return eventi;
        }

        public bool RemoveEventById(int eventId)
        {
            var eventi = GetEventById(eventId);
            if (eventi == default(Event))
            {
                return false;
            }
            _context.Remove(eventi);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int eventId, string eventName, string eventDescription, DateTime strartDate, DateTime endDate, string eventPlace)
        {
            var eventi = GetEventById(eventId);
            if (eventi == default(Event))
            {
                return false;
            }
            eventi.EventName = eventName;
            eventi.EventDescription = eventDescription;
            eventi.StartDate = strartDate;
            eventi.EndDate = endDate;
            eventi.EventPlace = eventPlace;

            _context.Update(eventi);
            return _context.SaveChanges() != 0;
        }
    }
}
