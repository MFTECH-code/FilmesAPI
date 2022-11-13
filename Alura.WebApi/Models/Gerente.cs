using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.WebApi.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public List<Cinema> Cinemas { get; set; }
    }
}
