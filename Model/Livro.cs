﻿namespace Biblioteca_WebApi_ruan.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int FkCategoria { get; set; }
        public int Disponibilidade { get; set; }
    }
}
