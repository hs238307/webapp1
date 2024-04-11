using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Interfaces
{
    public interface IEventService
    {
        List<EventTitles> GetEvents();
        EventTitles ViewEvent(int id);
        EventTitles ViewPublicEvent(int id, bool type);
        Task CreateEvent(EventTitles eventTitles);
        Task UpdateEvent(EventTitles eventTitles);
        List<EventTitles> MyEvents(int userId);
        List<EventTitles> AllEvents();
        //EventTitles 
        List<Comments> GetCommentsByEventId(int eventId);
        List<InvitedEvent> GetInvitedEventByUserId(int userId);
        public int GetMaxEventId();
        Task CreateInvitedEvent(InvitedEvent invitedEvent);
        EventTitles isEventExist(int userId, int Id);
        InvitedEvent isInvitedEventExist(int userId, int Id);
        List<InvitedEvent> GetInvitedEventsByEventId(int Id);
        public void RemoveInvitedEvents(List<InvitedEvent> invitedEvents);
    }
}
