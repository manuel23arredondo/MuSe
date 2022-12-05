namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class WomanResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ownWomanPlaces")]
        public object? OwnWomanPlaces { get; set; }

        [JsonProperty("incidents")]
        public object? Incidents { get; set; }

        [JsonProperty("womanDiaries")]
        public object? WomanDiaries { get; set; }
    }
}
