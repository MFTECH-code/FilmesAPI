using System.ComponentModel.DataAnnotations;

namespace Alura.WebApi.Data.DTOs.Cinema
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
