/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.DataPersistance
{
    using Cassandra;
    using Engaze.Core.Persistance.Cassandra;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Engaze.Core.DataContract;


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
        }

        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        public IEnumerable<Event> GetEventsByUserId(Guid userid)
        {
            try
            {
                return GetEventsByEventIds(GetEventIdsByUserId(userid));
            }
            catch (Exception ex)
            {
                logger.LogError("Error during GetEventsByUserId." + ex.ToString());
                throw;
            }
        }


        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        public IEnumerable<Guid> GetEventIdsByUserId(Guid userid)
        {
            try
            {
                var sessionL = sessionCacheManager.GetSession(keySpace);
                string query = "SELECT EventId FROM EventParticipantMapping WHERE UserId=" + userid.ToString() + ";";
                var preparedStatement = sessionL.Prepare(query);
                var resultSet = sessionL.Execute(preparedStatement.Bind());
                return resultSet.Select(row => row.GetValue<Guid>("eventid"));
            }
            catch (Exception ex)
            {
                logger.LogError("Error during GetEventsByUserId." + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// gets events by userId
        /// </summary>
        /// <param name="userid">userId</param>
        /// <returns>list of event</returns>
        public IEnumerable<Event> GetEventsByEventIds(IEnumerable<Guid> eventIds)
        {
            try
            {
                string query = "SELECT EventDetails FROM EventData WHERE EventId IN (" + string.Join(",", eventIds.ToList()) + ");";
                var sessionL = sessionCacheManager.GetSession(keySpace);
                var preparedStatement = sessionL.Prepare(query);
                var resultSet = sessionL.Execute(preparedStatement.Bind());
                return resultSet.Select(row => JsonConvert.DeserializeObject<Event>(row.GetValue<string>("eventdetails")));
            }
            catch (Exception ex)
            {
                logger.LogError("Error during GetEventsByUserId." + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// gets event by eventId
        /// </summary>
        /// <param name="eventId">eventId</param>
        /// <returns>event</returns>

        public Event GetEvent(Guid eventId)
        {
            try
            {
                string query = "SELECT EventDetails from EventData WHERE EventId="+ eventId.ToString() + ";";
                var sessionL = sessionCacheManager.GetSession(keySpace);
                var preparedStatement = sessionL.Prepare(query);
                var resultSet = sessionL.Execute(preparedStatement.Bind());                
                return JsonConvert.DeserializeObject<Event>(resultSet.First().GetValue<string>("eventdetails"));
            }
            catch (Exception ex)
            {
                logger.LogError("Error during GetEvent." + ex.ToString());
                throw;
            }
        }
    }
}
