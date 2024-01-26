using System.Runtime.Serialization;

namespace ModelService.Dashboard
{
    public class DailyCount
    {
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public string Operations { get; set; }
    }
}
