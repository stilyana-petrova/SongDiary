using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Abstraction
{
    public interface IEventService
    {
        bool Create(string eventName, string eventDescription, DateTime strartDate, DateTime endDate, string eventPlace);
        bool Update(int eventId, string eventName, string eventDescription, DateTime strartDate, DateTime endDate, string eventPlace);
        List<Event> GetEvents();

        Event GetEventById(int eventId);
        bool RemoveEventById(int eventId);
        List<Event> GetEvents(string searchStringByEventName);
    }
}
