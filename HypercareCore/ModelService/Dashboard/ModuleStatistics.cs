using System.Runtime.Serialization;

namespace ModelService.Dashboard
{
    public class ModuleStatistics
    {
        [DataMember]
        public string ModuleName { get; set; }
        [DataMember]
        public string Operations { get; set; }
        [DataMember]
        public string ResponsibleTeam { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }
}
