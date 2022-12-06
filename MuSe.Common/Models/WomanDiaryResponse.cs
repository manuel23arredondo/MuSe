namespace MuSe.Common.Models
{
    using Newtonsoft.Json;
    using System;
    public class WomanDiaryResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("diaryDate")]
        public DateTime DiaryDate { get; set; }

        [JsonProperty("mood")]
        public string Mood { get; set; }

        [JsonProperty("woman")]
        public string? WomanUserId { get; set; }
    }
}
