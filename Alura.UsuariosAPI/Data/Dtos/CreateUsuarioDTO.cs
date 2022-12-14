using System.ComponentModel.DataAnnotations;

namespace Alura.UsuariosAPI.Data.Dtos
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
