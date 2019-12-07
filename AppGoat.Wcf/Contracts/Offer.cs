using System.Runtime.Serialization;

namespace AppGoat.Wcf.Contracts
{
    [DataContract]
    public class Offer
    {
        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ColorCode { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}