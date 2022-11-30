namespace MuSe.Common.Models
{
    using Newtonsoft.Json;

    public class MoodResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("womanDiaries")]
        public object? WomanDiaries { get; set; }
    }
}
