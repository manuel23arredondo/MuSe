namespace MuSe.Common.Models
{
    using Newtonsoft.Json;
    using System;

    public class IncidentResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("incidentDescription")]
        public string IncidentDescription { get; set; }

        [JsonProperty("agressorDescription")]
        public string AgressorDescription { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("incidentDate")]
        public DateTime IncidentDate { get; set; }

        [JsonProperty("woman")]
        public string? WomanUserId { get; set; }

        [JsonProperty("violentometer")]
        public string Violentometer { get; set; }
    }
}
