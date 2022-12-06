namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class HelpDirectoryResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("organizationName")]
        public string OrganizationName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("insideNumber")]
        public string InsideNumber { get; set; }

        [JsonProperty("outsideNumber")]
        public string OutsideNumber { get; set; }

        [JsonProperty("colony")]
        public string Colony { get; set; }

        [JsonProperty("postCode")]
        public int PostCode { get; set; }

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("helpType")]
        public string HelpType { get; set; }
    }
}
