using System.ComponentModel.DataAnnotations;

namespace Alura.WebApi.Data.DTOs
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não deve ultrapassar 30 caractéres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ser de 1 á no máximo 600 minutos")]
        public int Duracao { get; set; }
    }
}
