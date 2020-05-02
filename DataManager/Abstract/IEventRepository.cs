/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.DataPersistance
{
    using Engaze.Core.DataContract;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DataAcces Abstract
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        IEnumerable<Event> GetEventsByUserId(Guid userid);

        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        IEnumerable<Event> GetRunningEventsByUserId(Guid userid);

       /// <summary>
       /// gets event by eventId
       /// </summary>
       /// <param name="eventId">eventId</param>
       /// <returns>event</returns>
        Event GetEvent(Guid eventId);
    }
}
