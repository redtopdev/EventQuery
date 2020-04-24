using EventQuery.DataContract;
using System;
using System.Collections.Generic;

namespace EventQuery.Service
{
    public interface IEventManager
    {
        /// <summary>
        /// Gets registered contacts
        /// </summary>
        /// <param name="request">eventid</param>
        /// <returns>event</returns>
        Event GetEvent(Guid eventid);

        /// <summary>
        /// Gets events by userid
        /// </summary>
        /// <param name="userId">userid</param>
        /// <returns>list of events</returns>
        IEnumerable<Event> GetEventsByUserId(Guid userId);




    }
}
