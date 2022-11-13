using Alura.WebApi.Models;

namespace Alura.WebApi.Data.DTOs.Sessao
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
