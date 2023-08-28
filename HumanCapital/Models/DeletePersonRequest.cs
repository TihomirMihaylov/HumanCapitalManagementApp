using System.Runtime.Serialization;

namespace HumanCapital.Models
{
    [DataContract]
    public class DeletePersonRequest
    {
        [DataMember]
        public int PersonId { get; set; }
    }
}
