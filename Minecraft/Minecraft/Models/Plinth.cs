using System.Text.Json.Serialization;

namespace Minecraft.Models
{
    public class Plinth
    {
        public Plinth()
        {
           // Orders = new HashSet<Order>();
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("width")]
        public float Width { get; set; }

        [JsonPropertyName("height")]
        public float Height { get; set; }

        [JsonPropertyName("length")]
        public float Length { get; set; }

        [JsonPropertyName("scalex")]
        public float Scalex { get; set; }

        [JsonPropertyName("scaley")]
        public float Scaley { get; set; }

        [JsonPropertyName("scalez")]
        public float Scalez { get; set; }

        [JsonPropertyName ("volume")]

        public float Volume { get; set; }

        [JsonPropertyName("price")]

        public float Price { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

      

    }

    
}
