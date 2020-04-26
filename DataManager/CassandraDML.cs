/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace EventQuery.DataPersistance
{
    internal class CassandraDML
    {
        internal static string GetEventDetailsByEventId = "SELECT EventDetails from EventData WHERE EventId=(?);";

        internal static string GetEventIdsByUserId = "SELECT EventId FROM EventParticipantMapping WHERE UserId = (?);";

        internal static string GetEventsByEventIds = "SELECT EventDetails FROM EventData WHERE EventId IN (?);";

        internal static string GetEventsByUserId = "SELECT epm.EventDetails FROM EventData ed INNER JOIN EventParticipantMapping epm ON epm.EventId = ed.EventId WHERE epm.UserId=(?);";
    }


}