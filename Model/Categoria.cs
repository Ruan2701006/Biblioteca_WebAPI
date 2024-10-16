using System.Text.Json.Serialization;

namespace Biblioteca_WebApi_ruan.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
