﻿using System.ComponentModel.DataAnnotations;

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
    }
}
