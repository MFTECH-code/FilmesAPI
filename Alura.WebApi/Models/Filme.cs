using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.WebApi.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não deve ultrapassar 30 caractéres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ser de 1 á no máximo 600 minutos")]
        public int Duracao { get; set; }
        [JsonIgnore]
        public List<Sessao> Sessoes { get; set; }
    }
}
