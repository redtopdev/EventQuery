/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.DataPersistance
{
    using Cassandra;
    using Engaze.Core.Persistance.Cassandra;
    using EventQuery.DataContract;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Cassandra DB Handler
    /// </summary>
    public class EventRepository : IEventRepository
    {
        private readonly ILogger<EventRepository> logger;
        private CassandraSessionCacheManager sessionCacheManager;
        private string keySpace;
        private ISession session => session ?? sessionCacheManager.GetSession(keySpace);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionCacheManager"></param>
        /// <param name="cassandrConfig"></param>
        /// <param name="logger"></param>
        public EventRepository(CassandraSessionCacheManager sessionCacheManager, CassandraConfiguration cassandrConfig, ILogger<EventRepository> logger)
        {
            this.sessionCacheManager = sessionCacheManager;
            this.keySpace = cassandrConfig.KeySpace;
            this.logger = logger;
            //this.keySpace = 
        }

        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        public IEnumerable<Guid> GetEventsIdsByuserId(Guid userid)
        {

            var preparedStatement = session.Prepare(CassandraDML.SelectAllUserProfiles);
            var resultSet = session.Execute(preparedStatement.Bind());
            return resultSet.Select(row => row.GetValue<Guid>("eventId"));

        }

        /// <summary>
        /// gets event by eventId
        /// </summary>
        /// <param name="eventId">eventId</param>
        /// <returns>event</returns>

        public Event GetEvent(Guid eventId)
        {
            var preparedStatement = session.Prepare(CassandraDML.SelectAllUserProfiles);
            var resultSet = session.Execute(preparedStatement.Bind());
            return resultSet.First().GetValue<Event>("eventId");
        }

        /// <summary>
        /// gets events by eventIds
        /// </summary>
        /// <param name="eventIds">list of event Ids</param>
        /// <returns>list of event</returns>
        public IEnumerable<Event> GetEvents(IEnumerable<Guid> eventIds)
        {
            var preparedStatement = session.Prepare(CassandraDML.SelectAllUserProfiles);
            var resultSet = session.Execute(preparedStatement.Bind());
            return resultSet.Select(row => row.GetValue<Event>("event")); ;
        }      

    }
}
