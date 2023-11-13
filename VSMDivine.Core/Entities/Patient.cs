using Newtonsoft.Json;

namespace VSMDivine.Core.Entities
{
    public partial class Patient : EntityBase
    {
        [JsonProperty(nameof(PatientName))]
        public string PatientName { get; set; }

        public bool? Gender { get; set; }

        public int? MobileNumber { get; set; }

        public string EmailId { get; set; }

        public DateTime? Dob { get; set; }

        public string Address { get; set; }

        public int? Pincode { get; set; }
    }
}