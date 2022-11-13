using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.WebApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        [JsonIgnore]
        public List<Sessao> Sessoes { get; set; }
    }
}
