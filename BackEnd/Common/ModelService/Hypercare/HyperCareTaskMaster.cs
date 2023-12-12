using System.Runtime.Serialization;

namespace ModelService.Hypercare
{
    public class HyperCareTaskMaster
    {
        [DataMember]
        public int HcTaskId { get; set; }
        [DataMember]
        public string TaskName { get; set; }
        [DataMember]
        public string TaskDesc { get; set; }
        [DataMember]
        public int ThresholdFromRange { get; set; }
        [DataMember]
        public int ThresholdToRange { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedUser { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string UpdatedUser { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string Severity { get; set; }
        [DataMember]
        public string ModuleName { get; set; }
        [DataMember]
        public string Operations { get; set; }
        [DataMember]
        public string Purpose { get; set; }
        [DataMember]
        public string WhatToMonitor { get; set; }
        [DataMember]
        public string DependsOn { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string Threshold { get; set; }
        [DataMember]
        public string ResponsibleTeam { get; set; }
        [DataMember]
        public string Operator { get; set; }
        [DataMember]
        public string EmailTo { get; set; }
        [DataMember]
        public string EmailCC { get; set; }
        [DataMember]
        public string MonitoredBy { get; set; }
        [DataMember]
        public string Method { get; set; }
        [DataMember]
        public string Frequency { get; set; }
        [DataMember]
        public long FrequencyCount1 { get; set; }
        [DataMember]
        public long FrequencyCount2 { get; set; }
        [DataMember]
        public long MinuteCount1 { get; set; }
        [DataMember]
        public long MinuteCount2 { get; set; }
    }
}
