namespace MuSe.Common.Models
{
    using Newtonsoft.Json;
    public class HelpType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("helpDirectories")]
        public object HelpDirectories { get; set; }
    }
}