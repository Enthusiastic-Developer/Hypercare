using System.Runtime.Serialization;

namespace ModelService.Hypercare
{
    public class HyperCareScheduler
    {
        [DataMember]
        public int HcSchId { get; set; }
        [DataMember]
        public string SchedulerName { get; set; }
        [DataMember]
        public string SchedulerDesc { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public DateTime ScheduleTime { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedUser { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string UpdatedUser { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string Frequency { get; set; }
        [DataMember]
        public byte FrequencyStartDay { get; set; }
        [DataMember]
        public byte FrequencyEndDay { get; set; }
        [DataMember]
        public string FrequencyStartDayName { get; set; }
        [DataMember]
        public bool IsOneOff { get; set; }
    }
}
