namespace Biblioteca_WebApi_ruan.Model
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }
        public int FkLivros { get; set; }
        public int FkMenbros { get; internal set; }
    }
}
