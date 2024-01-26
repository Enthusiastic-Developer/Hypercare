using System.Runtime.Serialization;

namespace ModelService.Dashboard
{
    public class IssueStatistics
    {
        [DataMember]
        public int TotalIssueCountOverall { get; set; }
        [DataMember]
        public int TotalIssueCountToday { get; set; }
        [DataMember]
        public int BusinessCriticalCount { get; set; }
        [DataMember]
        public int WarningCount { get; set; }
    }

}
