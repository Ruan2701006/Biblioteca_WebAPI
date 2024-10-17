using System.Text.Json.Serialization;

namespace Biblioteca_WebApi_ruan.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int FkLivros { get; internal set; }
        public int FkMenbros { get; internal set; }
        public DateOnly DataEmprestimo { get; internal set; }
        public DateOnly DataDevolucao { get; internal set; }
    }
}
