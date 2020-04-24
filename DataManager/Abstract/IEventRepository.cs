/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.DataPersistance
{
    using EventQuery.DataContract;
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
        IEnumerable<Guid> GetEventsIdsByuserId(Guid userid);

       /// <summary>
       /// gets event by eventId
       /// </summary>
       /// <param name="eventId">eventId</param>
       /// <returns>event</returns>
        Event GetEvent(Guid eventId);

      /// <summary>
      /// gets events by eventIds
      /// </summary>
      /// <param name="eventIds">list of event Ids</param>
      /// <returns>list of event</returns>
        IEnumerable<Event> GetEvents(IEnumerable<Guid> eventIds);
    }
}
