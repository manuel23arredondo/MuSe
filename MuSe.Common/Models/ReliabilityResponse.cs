namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class ReliabilityResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("violentometers")]
        public object? Violentometers { get; set; }
    }
}
