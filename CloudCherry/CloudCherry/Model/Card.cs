using System;
using Newtonsoft.Json;

namespace CloudCherry.Model
{
    public class Card
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }
    }
}