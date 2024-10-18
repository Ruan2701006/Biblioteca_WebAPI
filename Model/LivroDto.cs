namespace Biblioteca_WebApi_ruan.Model
{
    public class LivroDto
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public DateOnly AnoPublicacao { get; set; }

        public int FkCategoria { get; set; }

        public int Disponibilidade { get; set; }
    }
}
