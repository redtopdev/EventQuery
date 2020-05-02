
using Engaze.Core.DataContract;
using EventQuery.DataPersistance;
using System;
using System.Collections.Generic;

namespace EventQuery.Service
{
    public class EventManager : IEventManager
    {
        private IEventRepository repo;
        public EventManager(IEventRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Gets registered contacts
        /// </summary>
        /// <param name="request">eventid</param>
        /// <returns>event</returns>
        public Event GetEvent(Guid eventId)
        {
            return repo.GetEvent(eventId);
        }

        /// <summary>
        /// Gets events by userid
        /// </summary>
        /// <param name="userId">userid</param>
        /// <returns>list of events</returns>
        public IEnumerable<Event> GetEventsByUserId(Guid userId)
        {
            return repo.GetEventsByUserId(userId);
        }

        /// <summary>
        /// Gets running events by userid
        /// </summary>
        /// <param name="userId">userid</param>
        /// <returns>list of events</returns>
        public IEnumerable<Event> GetRunningEventsByUserId(Guid userId)
        {
            return repo.GetRunningEventsByUserId(userId);
        }
    }
}
