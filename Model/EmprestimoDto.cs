namespace Biblioteca_WebApi_ruan.Model
{
    public class EmprestimoDto
    {
        public DateOnly DataEmprestimo { get; set; }

        public DateOnly DataDevolucao { get; set; }

        public int FkMenbros { get; set; }

        public int FkLivros { get; set; }
        
    }
}
