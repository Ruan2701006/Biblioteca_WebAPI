﻿namespace Biblioteca_WebApi_ruan.Model
{
    public class Membro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public DateOnly DataCadastro { get; set; }
        public string TipoMembro { get; set; }
    }
}
