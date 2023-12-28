using System.Runtime.Serialization;

namespace ModelService.Hypercare
{
    public class HypercareResponsibleTeam
    {
        [DataMember]
        public int SNo { get; set; }
        [DataMember]
        public string Module { get; set; }
        [DataMember]
        public string ResponsibleTeam { get; set; }
        [DataMember]
        public string ActionType { get; set; }
        [DataMember]
        public int NumberOfTasks { get; set; }
        [DataMember]
        public string OnsiteTeam { get; set; }
        [DataMember]
        public string PrimaryResource { get; set; }
        [DataMember]
        public string SecondaryResource { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedUser { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        public string UpdatedUser { get; set; }
    }
}
