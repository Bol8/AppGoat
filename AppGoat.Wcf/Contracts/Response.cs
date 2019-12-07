using System.Runtime.Serialization;

namespace AppGoat.Wcf.Contracts
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string[] Errors { get; set; }
    }
}