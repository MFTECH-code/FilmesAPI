﻿namespace Alura.WebApi.Data.DTOs.Sessao
{
    public class CreateSessaoDTO
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
