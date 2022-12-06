namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class OwnWomanPlaceResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("latitud")]
        public double Latitud { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("woman")]
        public string? WomanUserId { get; set; }

        [JsonProperty("kindOfPlace")]
        public string KindOfPlace { get; set; }
    }
}
