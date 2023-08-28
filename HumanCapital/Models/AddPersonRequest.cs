using System.Runtime.Serialization;

namespace HumanCapital.Models
{
    [DataContract]
    public class AddPersonRequest
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public decimal Salary { get; set; }

        [DataMember]
        public string Department { get; set; }
    }
}
