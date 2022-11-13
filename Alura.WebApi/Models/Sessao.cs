using System.ComponentModel.DataAnnotations;

namespace Alura.WebApi.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
