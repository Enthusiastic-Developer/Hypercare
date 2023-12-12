using System.Runtime.Serialization;

namespace ModelService.Hypercare
{
    public class HyperCareTracker
    {
        [DataMember]
        public long HcId { get; set; }
        [DataMember]
        public long HcTaskId { get; set; }
        [DataMember]
        public long HcSchId { get; set; }
        [DataMember]
        public string ResponsibleTeam { get; set; }
        [DataMember]
        public DateTime ExecutionDate { get; set; }
        [DataMember]
        public TimeSpan ExecutionTime { get; set; }
        [DataMember]
        public int RecordCount { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedUser { get; set; }
        [DataMember]
        public bool IsEmailSent { get; set; }
        [DataMember]
        public bool IsIncidentCreated { get; set; }
        [DataMember]
        public bool IsThresholdCrossing { get; set; }
        [DataMember]
        public string RecordDescr { get; set; }
    }
}
