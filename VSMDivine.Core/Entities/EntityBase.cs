namespace VSMDivine.Core.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public int TotalCount { get; set; }
    }
}
