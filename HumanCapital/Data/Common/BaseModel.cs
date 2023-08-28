using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HumanCapital.Data.Common
{
    [DataContract]
    public abstract class BaseModel : IAuditInfo
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
