using System.ComponentModel.DataAnnotations;

namespace Alura.UsuariosAPI.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
