using System;
using Newtonsoft.Json;

namespace PokedexCustomVisionApp.Models
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        public byte[] Image { get; set; }

    }

    public class Sprites
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }
    }
}
