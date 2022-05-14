using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Minecraft.Models
{
    public class Order
    {
        public Order()
        {
           
        }

        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        //public virtual Plinth Item{ get; set; }

        [Column]
        [JsonPropertyName("total")]
        public float Total { get; set; }

        public string PlinthId { get; set; }



        [JsonPropertyName("plinths")]
        public ICollection<Plinth> Plinths { get; set; } = new List<Plinth>();



    }
}
