namespace HumanCapital.Data.Common
{
    public class BaseDeletableModel : BaseModel, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
