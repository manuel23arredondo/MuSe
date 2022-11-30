namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class KindOfPlaceResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ownWomanPlaces")]
        public object? OwnWomanPlaces { get; set; }
    }
}
