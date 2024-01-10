using System.Runtime.Serialization;

namespace ModelService.Common
{
    public class Pagination
    {
        [DataMember]
        public string SortColumn { get; set; }
        [DataMember]
        public short SortDirection { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int RecorddCount { get; set; }
    }
}
