using System.Runtime.Serialization;

namespace ModelService.Hypercare
{
    public class HypercareTaskSchedulerMap
    {
        [DataMember]
        public long HcTsId { get; set; }
        [DataMember]
        public int HcTaskId { get; set; }
        [DataMember]
        public int HcSchId { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedUser { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
