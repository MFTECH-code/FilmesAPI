using System.ComponentModel.DataAnnotations;

namespace Alura.WebApi.Data.DTOs
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }    
        public int EnderecoId { get; set; }
    }
}
