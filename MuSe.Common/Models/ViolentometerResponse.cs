namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class ViolentometerResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reliability")]
        public string Reliability { get; set; }

        [JsonProperty("incidents")]
        public object? Incidents { get; set; }
    }
}
