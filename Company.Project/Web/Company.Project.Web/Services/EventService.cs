using Company.Project.Web.Interfaces;
using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _db;
        public EventService(AppDbContext db)
        {
            this._db = db;
        }
        public async Task CreateEvent(EventTitles eventTitles)
        {
            await _db.Event.AddAsync(eventTitles);
            await _db.SaveChangesAsync();
        }

        public List<Comments> GetCommentsByEventId(int eventId)
        {
            List<Comments> comments = _db.Comments.Where(c => c.eventId == eventId).OrderByDescending(co => co.Id).ToList();
            return comments;
        }

        public List<EventTitles> GetEvents()
        {
            List<EventTitles> events = _db.Event.Where(e => e.type == true).OrderByDescending(eo => eo.Id).ToList();
            return events;
        }

        public List<InvitedEvent> GetInvitedEventByUserId(int userId)
        {
            List<InvitedEvent> invitedEvents = _db.InvitedEvent.Where(i => i.userId == userId).OrderByDescending(ie => ie.Id).ToList();
            return invitedEvents;
        }

        public int GetMaxEventId()
        {
            return (int)_db.Event.Max(t => t.Id);
        }

        public List<EventTitles> MyEvents(int userId)
        {
            List<EventTitles> events = _db.Event.Where(e => e.userId == userId).OrderByDescending(eo => eo.Id).ToList();
            return events;
        }

        public async Task UpdateEvent(EventTitles model)
        {
            var eventTitles = _db.Event.FirstOrDefault(e => e.Id == model.Id);
            eventTitles.title = model.title;
            eventTitles.date = model.date;
            eventTitles.description = model.description;
            eventTitles.duration = model.duration;
            eventTitles.startTime = model.startTime;
            eventTitles.location = model.location;
            eventTitles.inviteByEmail = model.inviteByEmail;
            eventTitles.otherDetails = model.otherDetails;
            eventTitles.type = model.type;
            eventTitles.userId = model.userId;
            await _db.SaveChangesAsync();
        }

        public EventTitles ViewEvent(int id)
        {
            EventTitles eventTitles = _db.Event.FirstOrDefault(e => e.Id == id);
            return eventTitles;
        }

        public async Task CreateInvitedEvent(InvitedEvent invitedEvent)
        {
            await _db.InvitedEvent.AddAsync(invitedEvent);
            await _db.SaveChangesAsync();
        }

        public EventTitles isEventExist(int userId, int Id)
        {
            EventTitles ev = _db.Event.FirstOrDefault(ie => ie.userId == userId && ie.Id == Id);
            return ev;
        }

        public List<InvitedEvent> GetInvitedEventsByEventId(int Id)
        {
            List<InvitedEvent> invitedEvents = _db.InvitedEvent.Where(i => i.EventId == Id).ToList();
            return invitedEvents;
        }

        public void RemoveInvitedEvents(List<InvitedEvent> invitedEvents)
        {
            _db.InvitedEvent.RemoveRange(invitedEvents);
            _db.SaveChanges();
        }

        public List<EventTitles> AllEvents()
        {
            List<EventTitles> eventTitles = _db.Event.OrderByDescending(e => e.Id).ToList();
            return eventTitles;
        }

        public InvitedEvent isInvitedEventExist(int userId, int Id)
        {
            InvitedEvent invitedEvent = _db.InvitedEvent.FirstOrDefault(ie => ie.userId == userId && ie.EventId == Id);
            return invitedEvent;
        }

        public EventTitles ViewPublicEvent(int id, bool type)
        {
            EventTitles eventTitles = _db.Event.FirstOrDefault(e => e.Id == id && e.type == type);
            return eventTitles;
        }
    }
}
